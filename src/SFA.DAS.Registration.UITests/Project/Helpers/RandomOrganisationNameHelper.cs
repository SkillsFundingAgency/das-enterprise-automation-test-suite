using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RandomOrganisationNameHelper
    {
        public static string GetOrganisationName(List<string> tags) => tags.Contains("donotuserandomorgname") ? GetScenarioSpecificOrgName(tags) : GetRandomOrgName();

        private static string GetScenarioSpecificOrgName(List<string> tags)
        {
            var listofScenarioSpecificOrg = ListofScenarioSpecificOrg();

            var key = tags.Where(x => listofScenarioSpecificOrg.Keys.ToList().Any(y => y == x)).ToList();

            listofScenarioSpecificOrg.TryGetValue(key.SingleOrDefault(), out string OrgName);

            return OrgName;
        }

        private static string GetRandomOrgName()
        {
            var listoforg = ListOfOrganisation();

            int randomvalue = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, listoforg.Count - 1);

            return listoforg[randomvalue];
        }

        private static Dictionary<string, string> ListofScenarioSpecificOrg() => new Dictionary<string, string>() { { "reodc01", "COVENTRY AIRPORT LIMITED" } };

        private static List<string> ListOfOrganisation() => new List<string>()
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
