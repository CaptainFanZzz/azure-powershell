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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Test.ScenarioTests;

namespace RecoveryServices.SiteRecovery.Test
{
    public class AsrB2ATests : SiteRecoveryTestRunner
    {
        public AsrB2ATests(
            ITestOutputHelper output) : base(output)
        {
            this.VaultSettingsFilePath = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "B2A.VaultCredentials");
            this.PowershellFile = System.IO.Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                "ScenarioTests", "B2A", "AsrB2ATests.ps1");
            this.Initialize();
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePolicy()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-CreatePolicy -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreatePCMap()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-CreatePCMap -vaultSettingsFilePath \"" + this.VaultSettingsFilePath + "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestEnableDR()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-SiteRecoveryEnableDR -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPI()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-UpdateRPI -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestTFO()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-TFO -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestPlannedFailover()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-PlannedFailover -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPIWithDES()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-UpdateRPIWithDiskEncryptionSetMap -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-CreateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPIWithAdditionalProperties()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-UpdateRPIWithAdditionalProperties -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestCreateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-CreateRPIWithAvailabilityZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }

        [Fact]
        [Trait(
            Category.AcceptanceType,
            Category.CheckIn)]
        public void TestUpdateRPIWithAvZone()
        {
            TestRunner.RunTestScript(
                Constants.NewModel,
                "Test-UpdateRPIWithAvailabilityZone -vaultSettingsFilePath \"" +
                this.VaultSettingsFilePath +
                "\"");
        }
    }
}
