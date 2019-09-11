using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.EAS.AutomatedApiTests.Database
{
    public class SeedData
    {
        public static List<SeedAccount> SeedAccounts = new List<SeedAccount>
        {
            new SeedAccount
            {
                AccountHashedId = "AABB7C",
                AccountPublicHashedId = "XXYY7Z",
                DateOfIncorporation = DateTime.Now.AddYears(-40),
                LegalEntityAddress = "Seed Street 1, Seed Village, Seed Town, SEED 1EF",
                LegalEntityCode = "00445790",
                LegalEntityName = "Seed Corp 1",
                LegalEntitySource = 1,
                LegalEntityStatus = "Active",
                PayeName = "NA",
                PayeRef = "111/ZZ00001",
                PublicHashId = "BBB123",
                UserFirstName = "James",
                UserLastName = "Smith",
                UserEmailAddress = "JamesSmithAutomatedTest@AccountApis.Com"
            },
            new SeedAccount
            {
                AccountHashedId = "AABB8D",
                AccountPublicHashedId = "XXYY8Z",
                DateOfIncorporation = DateTime.Now.AddYears(-40),
                LegalEntityAddress = "Seed Street 2, Seed Village, Seed Town, SEED 1EF",
                LegalEntityCode = "00445791",
                LegalEntityName = "Seed Corp 2",
                LegalEntitySource = 1,
                LegalEntityStatus = "Active",
                PayeName = "NA",
                PayeRef = "111/ZZ00002",
                PublicHashId = "BBB124",
                UserFirstName = "Thomas",
                UserLastName = "Jenkins",
                UserEmailAddress = "ThomasJenkinsAutomatedTest@AccountApis.Com"
            },
            new SeedAccount
            {
                AccountHashedId = "AABB9E",
                AccountPublicHashedId = "XXYY9Z",
                DateOfIncorporation = DateTime.Now.AddYears(-40),
                LegalEntityAddress = "Seed Street 3, Seed Village, Seed Town, SEED 1EF",
                LegalEntityCode = "00445792",
                LegalEntityName = "Seed Corp 3",
                LegalEntitySource = 1,
                LegalEntityStatus = "Active",
                PayeName = "NA",
                PayeRef = "111/ZZ00003",
                PublicHashId = "BBB125",
                UserFirstName = "Jennifer",
                UserLastName = "Lankton",
                UserEmailAddress = "JenniferLanktonAutomatedTest@AccountApis.Com"
            }
        };
    }
}
