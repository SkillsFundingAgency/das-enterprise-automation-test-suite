using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class CharityTypeOrg { public string Number; public string Name; public string Address; }

    public class RandomOrganisationNameHelper
    {
        private readonly string[] _tags;

        public RandomOrganisationNameHelper(string[] tags) => _tags = tags;

        public string GetCompanyTypeOrgName() => GetOrgName(OrgType.Company, null);

        public string GetCompanyTypeOrgName(string existingOrgName) => GetOrgName(OrgType.Company2, existingOrgName);

        public string GetPublicSectorTypeOrgName() => GetOrgName(OrgType.PublicSector, null);

        public CharityTypeOrg GetCharityTypeOrg() => GetCharityOrg(OrgType.Charity, null);

        public CharityTypeOrg GetCharityTypeOrg(CharityTypeOrg existingCharityTypeOrg) => GetCharityOrg(OrgType.Charity2, existingCharityTypeOrg);

        private CharityTypeOrg GetCharityOrg(OrgType orgType, CharityTypeOrg existingCharityTypeOrg) => DoNotUseRandomOrgname() ? GetCharityScenarioSpecificOrgName(orgType) 
            : GetRandomOrgName(ListOfCharityTypeOrgOrganisation().Where(x => x.Name != existingCharityTypeOrg?.Name).ToList());

        private CharityTypeOrg GetCharityScenarioSpecificOrgName(OrgType orgType) => ListOfCharityTypeOrgOrganisation().FirstOrDefault(x => x.Name == GetScenarioSpecificOrgName(orgType));

        private string GetOrgName(OrgType orgType, string existingOrgName)
            => DoNotUseRandomOrgname() ? GetScenarioSpecificOrgName(orgType) : orgType == OrgType.PublicSector ? GetRandomOrgName(ListOfPublicSectorTypeOrganisation(), existingOrgName) : GetRandomOrgName(ListOfCompanyTypeOrganisation(), existingOrgName);

        private string GetScenarioSpecificOrgName(OrgType expOrgType)
        {
            var listofScenarioSpecificOrg = ListofScenarioSpecificOrg();

            var key = _tags.ToList().Where(x => listofScenarioSpecificOrg.Keys.ToList().Any(y => y == x)).ToList();

            listofScenarioSpecificOrg.TryGetValue(key.SingleOrDefault(), out Dictionary<OrgType, string> value);

            value.TryGetValue(expOrgType, out string orgName);

            return orgName;
        }

        private static string GetRandomOrgName(List<string> listoforg, string existingOrgName) => GetRandomOrgName(listoforg.Where(x => x != existingOrgName).ToList());

        private static T GetRandomOrgName<T>(List<T> listoforg)
        {
            int randomvalue = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, listoforg.Count);

            return listoforg[randomvalue];
        }

        private bool DoNotUseRandomOrgname() => _tags.Contains("donotuserandomorgname");

        private static Dictionary<string, Dictionary<OrgType, string>> ListofScenarioSpecificOrg()
        {
            return new Dictionary<string, Dictionary<OrgType, string>>
            {
                { "reodc01", new Dictionary<OrgType, string>() { { OrgType.Company, "COVENTRY AIRPORT LIMITED" } } }
            };
        }

        private static List<CharityTypeOrg> ListOfCharityTypeOrgOrganisation() => new List<CharityTypeOrg>
        {
            new CharityTypeOrg {Number = "200895", Name = "ALLHALLOWS CHARITY", Address = "WBW Solicitors, 118 High Street, Honiton, EX14 1JP"},
            new CharityTypeOrg {Number = "202918", Name = "OXFAM", Address = "OXFAM, 2700 JOHN SMITH DRIVE, OXFORD BUSINESS PARK SOUTH, OXFORD, OX4 2JY"},
            new CharityTypeOrg {Number = "219348", Name = "CITY HOSPITAL NHS TRUST", Address = "LIFFORD HALL, TUNNEL LANE, KINGS NORTON, BIRMINGHAM, B30 3JN"},
            new CharityTypeOrg {Number = "509965", Name = "Friends of Nottingham University Hospitals NHS Trust", Address = "NOTTINGHAM, NG9 6AS"},
        };

        private static List<string> ListOfPublicSectorTypeOrganisation() => new List<string>
        {
            "Royal School Hampstead",
            "All Saints Centre",
            "Amersham Family Centre",
            "South Somerset East",
            "South Somerset West",
            "Taunton East",
            "Bromley Cross Start Well Link Site",
            "Barley Fields CC"
        };

        private static List<string> ListOfCompanyTypeOrganisation() => new List<string>()
        {
            "SURREY LIMITED",
            "CROYDON LIMITED",
            "TWO LTD",
            "TWO A ENTERPRISES LIMITED",
            "THREE LTD",
            "FOUR ACE LIMITED",
            "FOUR ACRE CHEM LTD",
            "FOUR ACRE FIELD LTD",
            "FOUR ACRE SITE LTD",
            "FIVE LIMITED",
            "FIVE A DAY LTD",
            "FIVE ACRE KOI SUPPLIES LTD",
            "FIVE ACRES LIMITED",
            "SIX LIMITED",
            "SIX ADRIAN SQUARE LIMITED",
            "SIX AND OUT LTD",
            "SEVEN LIMITED",
            "SEVEN ACRES FARM LTD",
            "SEVEN AIR LIMITED",
            "SEVEN AND FOUR LIMITED",
            "EIGHT ACCOUNTING LTD",
            "EIGHT AND FOUR LTD",
            "EIGHT BRANDS LIMITED",
            "NINE ALMINGTON LIMITED",
            "NINE BLESSINGS LIMITED",
            "NEXT IQ LTD",
            "TEN ALEXANDER LIMITED",
            "TEN BAT LTD"
        };
    }
}
