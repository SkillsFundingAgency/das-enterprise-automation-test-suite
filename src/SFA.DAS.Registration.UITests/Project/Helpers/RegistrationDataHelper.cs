using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RegistrationDataHelper(string gatewayUsername, string password, RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            RandomEmail = $"{gatewayUsername}@mailinator.com";
            AnotherRandomEmail = $"{gatewayUsername}_2@mailinator.com";
            AornNumber = $"A{GetDateTimeValue()}";
            Password = password;
            InvalidGGId = RandomAlphaNumericString(10);
            InvalidGGPassword = RandomNumericString(10);
            InvalidCompanyNumber = RandomNumericString(10);
            OrgNameForManualEntry = $"Manually Added Organisation_{DateTime.Now.ToString("ddMMMyyyy_HHmmss")}";
        }

        public string RandomEmail { get; }
        public string AnotherRandomEmail { get; }
        public string AornNumber { get; }
        public string Password { get; }
        public string InvalidGGId { get; }
        public string InvalidGGPassword { get; }
        public string InvalidCompanyNumber { get; }
        public string CompanyTypeOrg => "ESFA LTD";
        public string PublicSectorTypeOrg => "Royal School Hampstead";
        public string CharityTypeOrg1Number => "200895";
        public string CharityTypeOrg1Name => "ALLHALLOWS CHARITY";
        public string CharityTypeOrg1Address => "Ford Simey, 118 High Street, Honiton, EX14 1JP";
        public string CharityTypeOrg2Number => "202918";
        public string CharityTypeOrg2Name => "OXFAM";
        public string CharityTypeOrg2Address => "OXFAM, 2700 JOHN SMITH DRIVE, OXFORD BUSINESS PARK SOUTH, OXFORD, OX4 2JY";
        public string CharityTypeOrg3Number => "277444";
        public string CharityTypeOrg3Name => "OXFAM (INDIA) TRUST";
        public string OrgNameForManualEntry { get; }
        public string FirstLineAddressForManualEntry => "5 Quinton Road";
        public string CityNameForManualEntry => "Coventry";
        public string PostCodeForManualEntry => "CV1 2WT";
        public string InvalidPaye => $"{RandomNumericString(3)}/{RandomAlphaNumericString(7)}";
        public string InvalidAornNumber => $"A{GetDateTimeValue()}";

        private string RandomAlphaNumericString(int length) => _randomDataGenerator.GenerateRandomAlphanumericString(length);
        private string RandomNumericString(int length) => _randomDataGenerator.GenerateRandomNumber(length);
        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMyyHHmmss");
    }
}
