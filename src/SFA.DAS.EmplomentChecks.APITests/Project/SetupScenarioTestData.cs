using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    public class SetupScenarioTestData
    {

        private string environment = EnvironmentConfig.EnvironmentName;

        public TestData SetData(int scenarioId)
        {

            TestData data = new TestData();
            switch (scenarioId)
            {
                case 1:
                    data.ULN = environment == "PP" ? 6456038986 : 9000000601;
                    data.AccountId = environment == "PP" ? 230091 : 17701;
                    data.NationalInsuranceNumber = "LJ000000A";
                    data.PayeScheme = "111/AB00001";
                    break;
                case 2:
                    data.ULN = environment == "PP" ? 8162635792 : 1000000019;
                    data.AccountId = environment == "PP" ? 230092 : 17702;
                    data.NationalInsuranceNumber= environment == "PP" ? "LJ000000A" : "AS960509A";
                    data.PayeScheme = "840/HZ00064";
                    break;
                case 3:
                    data.ULN = 56879432;
                    data.AccountId = environment == "PP" ? 230092 : 17702;
                    data.NationalInsuranceNumber = null;
                    data.PayeScheme = "840/HZ00064";
                    break;
            }

            return data;

        }

    }
}
