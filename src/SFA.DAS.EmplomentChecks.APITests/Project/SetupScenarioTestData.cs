using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Models;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    public class SetupScenarioTestData
    {
        public static TestData SetData(int scenarioId)
        {
            var dataDictionary = new Dictionary<Tuple<int, string>, TestData>
            {
                { new Tuple<int, string>(1, "test"), new TestData() { ULN = 5000000284, AccountId = 48874, NationalInsuranceNumber = "AA678901C", PayeScheme = "111/AB00001" } },
                { new Tuple<int, string>(1, "test2"), new TestData() { ULN = 5000000284, AccountId = 17701, NationalInsuranceNumber = "AA678901C", PayeScheme = "111/AB00001" } },
                { new Tuple<int, string>(1, "pp"), new TestData() { ULN = 6456038986, AccountId = 230091, NationalInsuranceNumber = "LJ000000A", PayeScheme = "111/AB00001" } },

                { new Tuple<int, string>(2, "test"), new TestData() { ULN = 1000000019, AccountId = 48875, NationalInsuranceNumber = "AS960509A", PayeScheme = "840/HZ00064" } },
                { new Tuple<int, string>(2, "test2"), new TestData() { ULN = 1000000019, AccountId = 17702, NationalInsuranceNumber = "AS960509A", PayeScheme = "840/HZ00064" } },
                { new Tuple<int, string>(2, "pp"), new TestData() { ULN = 8162635792, AccountId = 230092, NationalInsuranceNumber = "LJ000000A", PayeScheme = "840/HZ00064" } },

                { new Tuple<int, string>(3, "test"), new TestData() { ULN = 56879432, AccountId = 48875, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064" } },
                { new Tuple<int, string>(3, "test2"), new TestData() { ULN = 56879432, AccountId = 17702, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064" } },
                { new Tuple<int, string>(3, "pp"), new TestData() { ULN = 56879432, AccountId = 230092, NationalInsuranceNumber = null, PayeScheme = "840/HZ00064" } },

                { new Tuple<int, string>(4, "test"), new TestData() { ULN = 4000000054, AccountId = -1, NationalInsuranceNumber = "SC111111A", PayeScheme = null } },
                { new Tuple<int, string>(4, "test2"), new TestData() { ULN = 4000000054, AccountId = -1, NationalInsuranceNumber = "SC111111A", PayeScheme = null } },
                { new Tuple<int, string>(4, "pp"), new TestData() { ULN = 6432664569, AccountId = -1, NationalInsuranceNumber = "LJ000000A", PayeScheme = null } },

                { new Tuple<int, string>(5, "test"), new TestData() { ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null } },
                { new Tuple<int, string>(5, "test2"), new TestData() { ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null } },
                { new Tuple<int, string>(5, "pp"), new TestData() { ULN = 56879435, AccountId = -1, NationalInsuranceNumber = null, PayeScheme = null } },


                { new Tuple<int, string>(6, "test"), new TestData() { ULN = 1000203602, AccountId = 48876, NationalInsuranceNumber = "PR555555A", PayeScheme = "923/EZ00059" } },
                { new Tuple<int, string>(6, "test2"), new TestData() { ULN = 1000203602, AccountId = 17703, NationalInsuranceNumber = "PR555555A", PayeScheme = "923/EZ00059" } },
                { new Tuple<int, string>(6, "pp"), new TestData() { ULN = 8048127198, AccountId = 230093, NationalInsuranceNumber = "LJ000000A", PayeScheme = "923/EZ00059" } },

                { new Tuple<int, string>(7, "test"), new TestData() { ULN = 5000000063, AccountId = 10211, NationalInsuranceNumber = "AA789012C", PayeScheme = "001/MP00176,001/MP00200,001/MP00231" } },
                { new Tuple<int, string>(7, "test2"), new TestData() { ULN = 5000000063, AccountId = 5030, NationalInsuranceNumber = "AA789012C", PayeScheme = "100/RAAUSER193,100/RAAUSER401,100/RAAUSER402" } },
                { new Tuple<int, string>(7, "pp"), new TestData() { ULN = 5805421088, AccountId = 49044, NationalInsuranceNumber = "LJ000000A", PayeScheme = "001/NK0005,101/LE35388" } },


                { new Tuple<int, string>(8, "test"), new TestData() { ULN = 7000000537, AccountId = 8090, NationalInsuranceNumber = "AA345678C", PayeScheme = "001/MP00185,001/MP00186" } },
                { new Tuple<int, string>(8, "test2"), new TestData() { ULN = 7000000537, AccountId = 2457, NationalInsuranceNumber = "AA345678C", PayeScheme = "001/MP00313,001/MP00376" } },
                { new Tuple<int, string>(8, "pp"), new TestData() { ULN = 4046783388, AccountId = 24314, NationalInsuranceNumber = "LJ000000A", PayeScheme = "001/MP00364,001/MP00366" } },

                { new Tuple<int, string>(9, "test"), new TestData() { ULN = 9000001500, AccountId = 28284, NationalInsuranceNumber = "AA890123C", PayeScheme = "001/SB034,001/SB035" } },
                { new Tuple<int, string>(9, "test2"), new TestData() { ULN = 9000001500, AccountId = 2680, NationalInsuranceNumber = "AA890123C", PayeScheme = "100/GDS00010,100/GDS00011" } },
                { new Tuple<int, string>(9, "pp"), new TestData() { ULN = 2771115661, AccountId = 12926, NationalInsuranceNumber = "LJ000000A", PayeScheme = "001/AC09013,100/GDS00001" } },

                { new Tuple<int, string>(10, "test"), new TestData() { AccountId = 8369 } },
                { new Tuple<int, string>(10, "test2"), new TestData() { AccountId = 1124 } },
                { new Tuple<int, string>(10, "pp"), new TestData() { AccountId = 153 } },

                { new Tuple<int, string>(11, "test"), new TestData() { ULN = 4000000054, AccountId = 777, NationalInsuranceNumber = "SC111111A", PayeScheme = null } },
                { new Tuple<int, string>(11, "test2"), new TestData() { ULN = 4000000054, AccountId = 777, NationalInsuranceNumber = "SC111111A", PayeScheme = null } },
                { new Tuple<int, string>(11, "pp"), new TestData() { ULN = 6432664569, AccountId = 777, NationalInsuranceNumber = "LJ000000A", PayeScheme = null } },

            };

            var data = new Tuple<int, string>(scenarioId, EnvironmentConfig.EnvironmentName);

            return dataDictionary[data];
        }
    }
}