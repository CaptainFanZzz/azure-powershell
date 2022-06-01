// ----------------------------------------------------------------------------------
// 
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using RuntimeSerialization = System.Runtime.Serialization;
using System.Xml;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Portal.RecoveryServices.Models.Common;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Commands.TestFx;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests
{
    public class SiteRecoveryTestRunner
    {
        protected readonly ITestRunner TestRunner;
        protected string VaultSettingsFilePath;
        protected string PowershellFile;
        private ASRVaultCreds _asrVaultCreds;
        private EnvironmentSetupHelper _helper;

        protected void Initialize()
        {
            try
            {
                if (FileUtilities.DataStore.ReadFileAsText(VaultSettingsFilePath).ToLower().Contains("<asrvaultcreds"))
                {
                    var serializer1 = new RuntimeSerialization.DataContractSerializer(typeof(ASRVaultCreds));
                    using (var s = new FileStream(VaultSettingsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        _asrVaultCreds = (ASRVaultCreds)serializer1.ReadObject(s);
                    }
                }
                else
                {
                    var serializer = new RuntimeSerialization.DataContractSerializer(typeof(RSVaultAsrCreds));
                    using (var s = new FileStream(VaultSettingsFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        var aadCreds = (RSVaultAsrCreds)serializer.ReadObject(s);
                        _asrVaultCreds = new ASRVaultCreds
                        {
                            ChannelIntegrityKey = aadCreds.ChannelIntegrityKey,
                            ResourceGroupName = aadCreds.VaultDetails.ResourceGroup,
                            Version = "2.0",
                            SiteId = aadCreds.SiteId,
                            SiteName = aadCreds.SiteName,
                            ResourceNamespace = aadCreds.VaultDetails.ProviderNamespace,
                            ARMResourceType = aadCreds.VaultDetails.ResourceType
                        };
                    }
                }
            }
            catch (XmlException xmlException)
            {
                throw new XmlException("XML is malformed or file is empty", xmlException);
            }
            _helper = new EnvironmentSetupHelper();
        }
        protected SiteRecoveryTestRunner(ITestOutputHelper output)
        {
            TestRunner = TestManager.CreateInstance(output)
                .WithNewPsScriptFilename($"{GetType().Name}.ps1")
                .WithProjectSubfolderForTests("ScenarioTests")
                .WithNewRmModules(helper => new[]
                {
                    PowershellFile,
                    helper.RMProfileModule,
#if !NETSTANDARD
                    helper.GetRMModulePath("Az.RecoveryServices.SiteRecovery.psd1"),
#endif
                    helper.GetRMModulePath("Az.RecoveryServices.psd1")
                })
                .WithNewRecordMatcherArguments(
                    userAgentsToIgnore: new Dictionary<string, string>
                    {
                        {"Microsoft.Azure.Management.Resources.ResourceManagementClient", "2016-02-01"}
                    },
                    resourceProviders: new Dictionary<string, string>
                    {
                        {"Microsoft.Resources", null},
                        {"Microsoft.Features", null},
                        {"Microsoft.Authorization", null},
                        {"Microsoft.Compute", null}
                    }
                ).WithManagementClients(
                    GetSiteRecoveryManagementClient
                )
                .Build();
        }

        private SiteRecoveryManagementClient GetSiteRecoveryManagementClient(MockContext context)
        {
            var client = context.GetServiceClient<SiteRecoveryManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
            client.ResourceGroupName = _asrVaultCreds.ResourceGroupName;
            client.ResourceName = _asrVaultCreds.ResourceName;

            return client;
        }

    }
}