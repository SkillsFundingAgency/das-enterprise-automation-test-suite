using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDatahelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RegistrationDatahelpers(string gatewayUsername, string password, RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            RandomEmail = $"{gatewayUsername}@mailinator.com";
            Password = password;
            InvalidGGId = RandomAlphaNumericString(10);
            InvalidGGPassword = RandomNumericString(10);
            InvalidCompanyNumber = RandomNumericString(10);
        }

        public string RandomEmail { get; }
        public string Password { get; }
        public string InvalidGGId { get; }
        public string InvalidGGPassword { get; }
        public string CompanyTypeOrg => "AUTOMATION & OPTIMISATION LTD";
        public string PublicSectorTypeOrg => "Royal School Hampstead";
        public string CharityTypeOrg => "ALLHALLOWS CHARITY";
        public string InvalidCompanyNumber { get; }

        private string RandomAlphaNumericString(int length) => _randomDataGenerator.GenerateRandomAlphanumericString(length);
        private string RandomNumericString(int length) => _randomDataGenerator.GenerateRandomNumber(length);
    }
}
