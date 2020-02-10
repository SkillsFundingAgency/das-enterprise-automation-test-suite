using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationDatahelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public RegistrationDatahelpers(string gatewayUsername, string password)
        {
            _randomDataGenerator = new RandomDataGenerator();
            RandomEmail = $"{gatewayUsername}@mailinator.com";
            Password = password;
        }

        public string RandomEmail { get; }
        public string Password { get; }
        public string CompanyTypeOrg => "AUTOMATION & OPTIMISATION LTD";
        public string PublicSectorTypeOrg => "Royal School Hampstead";
        public string CharityTypeOrg => "ALLHALLOWS CHARITY";
        public string RandomAlphaNumericString(int length) => _randomDataGenerator.GenerateRandomAlphanumericString(length);
        public string RandomNumericString(int length) => _randomDataGenerator.GenerateRandomNumber(length);
    }
}
