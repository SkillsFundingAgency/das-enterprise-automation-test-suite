using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDataHelper : RandomElementHelper
    {
        public RegistrationDataHelper(string emailaddress, string password, string organisationName, RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            RandomEmail = emailaddress;
            AnotherRandomEmail = randomDataGenerator.GenerateRandomEmail();
            AornNumber = $"A{GetDateTimeValue()}";
            Password = password;
            InvalidGGId = RandomAlphaNumericString(10);
            InvalidGGPassword = RandomNumericString(10);
            InvalidCompanyNumber = RandomNumericString(10);
            CompanyTypeOrg = organisationName;
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
        public string CompanyTypeOrg2 => "TESCO PLC";
        public string PublicSectorTypeOrg => "Royal School Hampstead";
        public string CharityTypeOrg1Number => "200895";
        public string CharityTypeOrg1Name => "ALLHALLOWS CHARITY";
        public string CharityTypeOrg1Address => "Ford Simey, 118 High Street, Honiton, EX14 1JP";
        public string CharityTypeOrg2Number => "202918";
        public string CharityTypeOrg2Name => "OXFAM";
        public string CharityTypeOrg2Address => "OXFAM, 2700 JOHN SMITH DRIVE, OXFORD BUSINESS PARK SOUTH, OXFORD, OX4 2JY";
        public string InvalidPaye => $"{RandomNumericString(3)}/{RandomAlphaNumericString(7)}";
        public string InvalidAornNumber => $"A{GetDateTimeValue()}";
        private string RandomAlphaNumericString(int length) => randomDataGenerator.GenerateRandomAlphanumericString(length);
        private string RandomNumericString(int length) => randomDataGenerator.GenerateRandomNumber(length);
        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMyyHHmmss");
    }
}
