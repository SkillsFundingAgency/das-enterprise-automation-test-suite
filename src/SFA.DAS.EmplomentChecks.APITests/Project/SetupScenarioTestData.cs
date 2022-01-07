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

            var dataDictionary = new Dictionary<Tuple<int, string>, TestData>();

            dataDictionary.Add(new Tuple<int, string>(1, "TEST"), new TestData(){ULN = 9000000601, AccountId = 48874, NationalInsuranceNumber = "LJ000000A", PayeScheme = "111/AB00001"});
            dataDictionary.Add(new Tuple<int, string>(1, "TEST2"), new TestData(){ULN = 9000000601, AccountId = 17701, NationalInsuranceNumber = "LJ000000A", PayeScheme = "111/AB00001"});
            dataDictionary.Add(new Tuple<int, string>(1, "PP"), new TestData(){ULN = 6456038986, AccountId = 230091, NationalInsuranceNumber = "LJ000000A", PayeScheme = "111/AB00001"});

            dataDictionary.Add(new Tuple<int, string>(2, "TEST"), new TestData() {ULN = 1000000019, AccountId = 48875, NationalInsuranceNumber = "AS960509A", PayeScheme = "840/HZ00064"});
            dataDictionary.Add(new Tuple<int, string>(2, "TEST2"), new TestData() {ULN = 1000000019, AccountId = 17702, NationalInsuranceNumber = "AS960509A", PayeScheme = "840/HZ00064"});
            dataDictionary.Add(new Tuple<int, string>(2, "PP"), new TestData() {ULN = 8162635792, AccountId = 230092, NationalInsuranceNumber = "LJ000000A", PayeScheme = "840/HZ00064"});

            dataDictionary.Add(new Tuple<int, string>(3, "TEST"), new TestData() {ULN = 56879432, AccountId = 48875, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064"});
            dataDictionary.Add(new Tuple<int, string>(3, "TEST2"), new TestData() {ULN = 56879432, AccountId = 17702, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064"});
            dataDictionary.Add(new Tuple<int, string>(3, "PP"), new TestData() {ULN = 56879432, AccountId = 230092, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064"});

            dataDictionary.Add(new Tuple<int, string>(4, "TEST"), new TestData() {ULN = 4000000054, AccountId = -1, NationalInsuranceNumber = "SC111111A", PayeScheme = null});
            dataDictionary.Add(new Tuple<int, string>(4, "TEST2"), new TestData() {ULN = 4000000054, AccountId = -1, NationalInsuranceNumber = "SC111111A", PayeScheme = null});
            dataDictionary.Add(new Tuple<int, string>(4, "PP"), new TestData() {ULN = 6432664569, AccountId = -1, NationalInsuranceNumber = "LJ000000A", PayeScheme = null});

            dataDictionary.Add(new Tuple<int, string>(5, "TEST"), new TestData() {ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null });
            dataDictionary.Add(new Tuple<int, string>(5, "TEST2"), new TestData() {ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null });
            dataDictionary.Add(new Tuple<int, string>(5, "PP"), new TestData() {ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null });


            dataDictionary.Add(new Tuple<int, string>(6, "TEST"), new TestData() {ULN = 1000203602, AccountId = 48876, NationalInsuranceNumber = "PR555555A", PayeScheme = "923/EZ00059"});
            dataDictionary.Add(new Tuple<int, string>(6, "TEST2"), new TestData() {ULN = 1000203602, AccountId = 17703, NationalInsuranceNumber = "PR555555A", PayeScheme = "923/EZ00059"});
            dataDictionary.Add(new Tuple<int, string>(6, "PP"), new TestData() {ULN = 8048127198, AccountId = 230093, NationalInsuranceNumber = "LJ000000A", PayeScheme = "923/EZ00059"});

            var data = new Tuple<int, string>(scenarioId, environment);

            return dataDictionary[data];
        }

    }
}
