using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDataHelper : RandomElementHelper
    {
        private readonly RandomOrganisationNameHelper randomOrganisationNameHelper;

        public RegistrationDataHelper(string[] tags, string emailaddress, string password) : base()
        {
            randomOrganisationNameHelper = new RandomOrganisationNameHelper(tags);
            RandomEmail = emailaddress;
            AnotherRandomEmail = RandomDataGenerator.GenerateRandomEmail();
            AornNumber = $"A{GetDateTimeValue()}";
            Password = password;
            InvalidGGId = RandomAlphaNumericString(10);
            InvalidGGPassword = RandomNumericString(10);
            InvalidCompanyNumber = RandomNumericString(10);
            CompanyTypeOrg = randomOrganisationNameHelper.GetCompanyTypeOrgName();
            CompanyTypeOrg2 = randomOrganisationNameHelper.GetCompanyTypeOrganisationName(CompanyTypeOrg);
            PublicSectorTypeOrg = randomOrganisationNameHelper.GetPublicSectorTypeOrgName();
            CharityTypeOrg1 = randomOrganisationNameHelper.GetCharityTypeOrg();
            CharityTypeOrg2 = randomOrganisationNameHelper.GetCharityTypeOrg(CharityTypeOrg1);
            SetAccountNameAsOrgName = true;
        }

        public string FirstName => "AutoFirstName";
        public string LastName => "AutoLastName";
        public string FullName => $"{FirstName } {LastName}";
        public string RandomEmail { get; }
        public string AnotherRandomEmail { get; }
        public string AornNumber { get; }
        public string Password { get; }
        public string NewPassword => "Test1234";
        public string InvalidGGId { get; }
        public string InvalidGGPassword { get; }
        public string InvalidCompanyNumber { get; }
        public string CompanyTypeOrg { get; }
        public bool SetAccountNameAsOrgName { get; set; }
        public string CompanyTypeOrg2 { get; }
        public string PublicSectorTypeOrg { get; }
        public string CharityTypeOrg1Number => CharityTypeOrg1.Number;
        public string CharityTypeOrg1Name => CharityTypeOrg1.Name;
        public string CharityTypeOrg1Address => CharityTypeOrg1.Address;
        public string CharityTypeOrg2Number => CharityTypeOrg2.Number;
        public string CharityTypeOrg2Name => CharityTypeOrg2.Name;
        public string CharityTypeOrg2Address => CharityTypeOrg2.Address;
        public string InvalidPaye => $"{RandomNumericString(3)}/{RandomAlphaNumericString(7)}";
        public string InvalidAornNumber => $"A{GetDateTimeValue()}";

        private CharityTypeOrg CharityTypeOrg1 { get; }
        private CharityTypeOrg CharityTypeOrg2 { get; }
        private string RandomAlphaNumericString(int length) => RandomDataGenerator.GenerateRandomAlphanumericString(length);
        private string RandomNumericString(int length) => RandomDataGenerator.GenerateRandomNumber(length);
        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMyyHHmmss");
    }
}
