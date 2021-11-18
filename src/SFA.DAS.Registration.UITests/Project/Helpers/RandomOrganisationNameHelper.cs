using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class CharityTypeOrg { public string Number; public string Name; public string Address; }

    public class RandomOrganisationNameHelper
    {
        private readonly List<string> _tags;

        public RandomOrganisationNameHelper(List<string> tags) => _tags = tags;

        public string GetCompanyTypeOrgName() => GetOrgName(OrgType.Company);

        public string GetPublicSectorTypeOrgName() => GetOrgName(OrgType.PublicSector);

        public CharityTypeOrg GetCharityTypeOrg() => GetRandomOrgName(ListOfCharityTypeOrgOrganisation());

        public CharityTypeOrg GetCharityTypeOrg(CharityTypeOrg existingCharityTypeOrg) => GetRandomOrgName(ListOfCharityTypeOrgOrganisation().Where(x => x.Name != existingCharityTypeOrg.Name).ToList());

        public string GetCompanyTypeOrganisationName(string existingOrgName) => GetRandomOrgName(ListOfCompanyTypeOrganisation().Where(x => x != existingOrgName).ToList());

        private string GetOrgName(OrgType orgType)
        {
            return _tags.Contains("donotuserandomorgname") ? GetScenarioSpecificOrgName(_tags) : orgType == OrgType.Company ? GetRandomCompanyTypeOrgName() : GetRandomPublicSectorTypeOrgName();
        }

        private static string GetScenarioSpecificOrgName(List<string> tags)
        {
            var listofScenarioSpecificOrg = ListofScenarioSpecificOrg();

            var key = tags.Where(x => listofScenarioSpecificOrg.Keys.ToList().Any(y => y == x)).ToList();

            listofScenarioSpecificOrg.TryGetValue(key.SingleOrDefault(), out string OrgName);

            return OrgName;
        }

        private static string GetRandomCompanyTypeOrgName() => GetRandomOrgName(ListOfCompanyTypeOrganisation());

        private static string GetRandomPublicSectorTypeOrgName() => GetRandomOrgName(ListOfPublicSectorTypeOrganisation());

        private static T GetRandomOrgName<T>(List<T> listoforg)
        {
            int randomvalue = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, listoforg.Count - 1);

            return listoforg[randomvalue];
        }

        private static Dictionary<string, string> ListofScenarioSpecificOrg() => new Dictionary<string, string>() { { "reodc01", "COVENTRY AIRPORT LIMITED" } };

        private static List<CharityTypeOrg> ListOfCharityTypeOrgOrganisation() => new List<CharityTypeOrg>
        {
            new CharityTypeOrg {Number = "200895", Name = "ALLHALLOWS CHARITY", Address = "WBW Solicitors, 118 High Street, Honiton, EX14 1JP"},
            new CharityTypeOrg {Number = "202918", Name = "OXFAM", Address = "OXFAM, 2700 JOHN SMITH DRIVE, OXFORD BUSINESS PARK SOUTH, OXFORD, OX4 2JY"}
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
