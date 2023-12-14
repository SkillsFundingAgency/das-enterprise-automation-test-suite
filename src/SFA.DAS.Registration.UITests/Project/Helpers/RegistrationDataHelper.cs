using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDataHelper
    {
        public RegistrationDataHelper(string[] tags, string emailaddress, AornDataHelper aornDataHelper)
        {
            var randomOrganisationNameHelper = new RandomOrganisationNameHelper(tags);
            var randomPersonNameHelper = new RandomPersonNameHelper();

            FirstName = randomPersonNameHelper.FirstName;
            LastName = randomPersonNameHelper.LastName;

            RandomEmail = emailaddress;
            AnotherRandomEmail = RandomDataGenerator.GenerateRandomEmail(emailaddress);
            AornNumber = aornDataHelper.AornNumber;
            InvalidGGId = RandomAlphaNumericString(10);
            InvalidGGPassword = RandomNumericString(10);
            InvalidCompanyNumber = RandomNumericString(10);
            CompanyTypeOrg = randomOrganisationNameHelper.GetCompanyTypeOrgName();
            CompanyTypeOrg2 = randomOrganisationNameHelper.GetCompanyTypeOrgName([CompanyTypeOrg]);
            CompanyTypeOrg3 = randomOrganisationNameHelper.GetCompanyTypeOrgName([CompanyTypeOrg, CompanyTypeOrg2]);
            PublicSectorTypeOrg = randomOrganisationNameHelper.GetPublicSectorTypeOrgName();
            CharityTypeOrg1 = randomOrganisationNameHelper.GetCharityTypeOrg();
            CharityTypeOrg2 = randomOrganisationNameHelper.GetCharityTypeOrg(CharityTypeOrg1);
            SetAccountNameAsOrgName = true;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string RandomEmail { get; }
        public string AnotherRandomEmail { get; }
        public string AornNumber { get; }
        public string InvalidGGId { get; }
        public string InvalidGGPassword { get; }
        public string InvalidCompanyNumber { get; }
        public string CompanyTypeOrg { get; }
        public bool SetAccountNameAsOrgName { get; set; }
        public string CompanyTypeOrg2 { get; }
        public string CompanyTypeOrg3 { get; }
        public string PublicSectorTypeOrg { get; }
        public string CharityTypeOrg1Number => CharityTypeOrg1.Number;
        public string CharityTypeOrg1Name => CharityTypeOrg1.Name;
        public string CharityTypeOrg1Address => CharityTypeOrg1.Address;
        public string CharityTypeOrg2Number => CharityTypeOrg2.Number;
        public string CharityTypeOrg2Name => CharityTypeOrg2.Name;
        public string CharityTypeOrg2Address => CharityTypeOrg2.Address;
        public static string InvalidPaye => $"{RandomNumericString(3)}/{RandomAlphaNumericString(7)}";

        private CharityTypeOrg CharityTypeOrg1 { get; }
        private CharityTypeOrg CharityTypeOrg2 { get; }
        private static string RandomAlphaNumericString(int length) => RandomDataGenerator.GenerateRandomAlphanumericString(length);
        private static string RandomNumericString(int length) => RandomDataGenerator.GenerateRandomNumber(length);
    }
}
