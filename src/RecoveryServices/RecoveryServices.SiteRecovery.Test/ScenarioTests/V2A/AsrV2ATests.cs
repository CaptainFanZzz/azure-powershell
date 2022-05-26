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

using System;
using System.IO;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrV2ATests : SiteRecoveryTestRunner
    {
        public AsrV2ATests(
            ITestOutputHelper output) : base(output)
        {
            this.VaultSettingsFilePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "V2A", "V2A.VaultCredentials");
            this.PowershellFile = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "V2A", "AsrV2ATests.ps1");
            this.Initialize();
        }

        [Fact(Skip = "Needs investigation for linux.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AvCenterTest()
        {
            this.TestRunner.RunTestScript(
              Constants.NewModel,
              "Test-vCenter -vaultSettingsFilePath \"" +
              this.VaultSettingsFilePath +
              "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddvCenterTest()
        {
            this.TestRunner.RunTestScript(
              Constants.NewModel,
              "Test-AddvCenter -vaultSettingsFilePath \"" +
              this.VaultSettingsFilePath +
              "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AFabricTests()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "Test-SiteRecoveryFabricTest -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCMappingTest()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "Test-PCM -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APCTest()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "Test-PC -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APolicyTest()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "Test-SiteRecoveryPolicy -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AAddPI()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "Test-V2AAddPI -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ACreatePolicyAndAssociateTest()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "V2ACreatePolicyAndAssociate -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ACreateRPI()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "V2ACreateRPI -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
             Category.AcceptanceType,
             Category.CheckIn)]
        public void V2ATestResync()
        {
            this.TestRunner.RunTestScript(
             Constants.NewModel,
             "V2ATestResync -vaultSettingsFilePath \"" +
             this.VaultSettingsFilePath +
             "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdateMS()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdateMobilityService -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdateSP()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdateServiceProvider -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2ATFOJob()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ATestFailoverJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void V2AFailoverJob()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AFailoverJob -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestSwitchProtection()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ATestReprotectAzureToVmware -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestFailback()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ATestFailback -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2ATestReprotect()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ATestReprotectVMwareToAzure -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2APSSwitch()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ASwitchProcessServer -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void V2AUpdatePolicy()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdatePolicy -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void SetRPI()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-SetRPI -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithDES()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ACreateRPIWithDES -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithDESEnabledDiskInput()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ACreateRPIWithDESEnabledDiskInput -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithPPG()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ACreateRPIWithPPG -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithPPG()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdateRPIWithPPG -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithAvZone()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ACreateRPIWithAvZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithAvZone()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdateRPIWithAvZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2ACreateRPIWithAdditionalProperties()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2ACreateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
           Category.AcceptanceType,
           Category.CheckIn)]
        public void V2AUpdateRPIWithAdditionalProperties()
        {
            this.TestRunner.RunTestScript(
                Constants.NewModel,
                "V2AUpdateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }
    }
}
