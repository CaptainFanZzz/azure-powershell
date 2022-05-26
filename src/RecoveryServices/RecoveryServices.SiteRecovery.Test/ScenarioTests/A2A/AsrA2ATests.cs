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

using Xunit;
using Xunit.Abstractions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.AsrV2ARcm.Test.ScenarioTests;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrA2ATests : AsrA2ATestRunner
    {
        public AsrA2ATests(
            ITestOutputHelper output) : base(output)
        {
            this.PowershellHelperFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\A2A\\A2ATestsHelper.ps1");

            this.PowershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests\\A2A\\AsrA2ATests.ps1");
            this.Initialize();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2ADiskReplicationConfig()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-NewA2ADiskReplicationConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2AManagedDiskReplicationConfig()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-NewA2AManagedDiskReplicationConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewA2AManagedDiskReplicationConfigWithCmk()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-NewA2AManagedDiskReplicationConfigurationWithCmk");
        }

//#if NETSTANDARD
//        [Fact(Skip = "Needs investigation, TestManagementClientHelper class wasn't initialized with the ResourceManagementClient client.")]
//#else
        [Fact]
//#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ANewAsrFabric()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-NewAsrFabric");
        }

//#if NETSTANDARD
//        [Fact(Skip = "Needs investigation, TestManagementClientHelper class wasn't initialized with the ResourceManagementClient client.")]
//#else
        [Fact]
//#endif
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ATestNewContainer()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-NewContainer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ARemoveReplicationProtectedItemDisk()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-RemoveReplicationProtectedItemDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AReplicateProximityPlacementGroupVm()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-ReplicateProximityPlacementGroupVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AVMNicConfig()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-VMNicConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AZoneToZoneRecoveryPlanReplication()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-ZoneToZoneRecoveryPlanReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ARecoveryPlanReplication()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-RecoveryPlanReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2AVMSSReplication()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-VMSSReplication");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void A2ACRGReplication()
        {
            TestRunner.RunTestScript(Constants.NewModel, "Test-CRGReplication");
        }
    }
}
