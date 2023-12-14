using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class CharityTypeOrg { public string Number; public string Name; public string Address; }

    public class RandomOrganisationNameHelper(string[] tags)
    {
        public string GetCompanyTypeOrgName() => GetOrgName(OrgType.Company, []);

        public string GetCompanyTypeOrgName(List<string> existingOrgName) => GetOrgName(OrgType.Company2, existingOrgName);

        public string GetPublicSectorTypeOrgName() => GetOrgName(OrgType.PublicSector, []);

        public CharityTypeOrg GetCharityTypeOrg() => GetCharityOrg(OrgType.Charity, null);

        public CharityTypeOrg GetCharityTypeOrg(CharityTypeOrg existingCharityTypeOrg) => GetCharityOrg(OrgType.Charity2, existingCharityTypeOrg);

        private CharityTypeOrg GetCharityOrg(OrgType orgType, CharityTypeOrg existingCharityTypeOrg) => DoNotUseRandomOrgname() ? GetCharityScenarioSpecificOrgName(orgType) 
            : GetRandomOrgName(ListOfCharityTypeOrgOrganisation().Where(x => x.Name != existingCharityTypeOrg?.Name).ToList());

        private CharityTypeOrg GetCharityScenarioSpecificOrgName(OrgType orgType) => ListOfCharityTypeOrgOrganisation().FirstOrDefault(x => x.Name == GetScenarioSpecificOrgName(orgType));

        private string GetOrgName(OrgType orgType, List<string> existingOrgName)
            => DoNotUseRandomOrgname() ? GetScenarioSpecificOrgName(orgType) : orgType == OrgType.PublicSector ? GetRandomOrgName(ListOfPublicSectorTypeOrganisation(), existingOrgName) : GetRandomOrgName(ListOfCompanyTypeOrganisation(), existingOrgName);

        private string GetScenarioSpecificOrgName(OrgType expOrgType)
        {
            var listofScenarioSpecificOrg = ListofScenarioSpecificOrg();

            var key = tags.ToList().Where(x => listofScenarioSpecificOrg.Keys.ToList().Any(y => y == x)).ToList();

            listofScenarioSpecificOrg.TryGetValue(key.SingleOrDefault(), out Dictionary<OrgType, string> value);

            value.TryGetValue(expOrgType, out string orgName);

            return orgName;
        }

        private static string GetRandomOrgName(List<string> listoforg, List<string> existingOrgName) => GetRandomOrgName(listoforg.Except(existingOrgName).ToList());

        private static T GetRandomOrgName<T>(List<T> listoforg) => RandomDataGenerator.GetRandomElementFromListOfElements(listoforg);
        
        private bool DoNotUseRandomOrgname() => tags.Contains("donotuserandomorgname");

        private static Dictionary<string, Dictionary<OrgType, string>> ListofScenarioSpecificOrg()
        {
            return new Dictionary<string, Dictionary<OrgType, string>>
            {
                { "reodc01", new Dictionary<OrgType, string>() { { OrgType.Company, "COVENTRY AIRPORT LIMITED" } } },
                { "flexijobapprenticeemployeraccount", new Dictionary<OrgType, string>() { { OrgType.Company, GetARandomOrganisationForFlexiJobApprentice() } } }
            };
        }

        private static string GetARandomOrganisationForFlexiJobApprentice() => GetRandomOrgName(ListOfListOfCompanyTypeOrganisationForFlexiJobApprentice());

        private static List<CharityTypeOrg> ListOfCharityTypeOrgOrganisation() => OrganisationNameHelper.ListOfCharityTypeOrgOrganisation();

        private static List<string> ListOfPublicSectorTypeOrganisation() => OrganisationNameHelper.ListOfPublicSectorTypeOrganisation();

        private static List<string> ListOfCompanyTypeOrganisation() => OrganisationNameHelper.ListOfCompanyTypeOrganisation();

        private static List<string> ListOfListOfCompanyTypeOrganisationForFlexiJobApprentice() => OrganisationNameHelper.ListOfListOfCompanyTypeOrganisationForFlexiJobApprentice();
    }
}
