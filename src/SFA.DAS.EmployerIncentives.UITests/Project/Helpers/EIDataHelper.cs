using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public EIDataHelper(RandomDataGenerator randomDataGenerator) => _randomDataGenerator = randomDataGenerator;

        public string AddressLine1 => $"{_randomDataGenerator.GenerateRandomAlphabeticString(5)} {_randomDataGenerator.GenerateRandomAlphabeticString(5)}";

        public string Town => _randomDataGenerator.GenerateRandomAlphabeticString(8);

        public string Poscode => $"CV{_randomDataGenerator.GenerateRandomNumber(1)} {_randomDataGenerator.GenerateRandomNumber(1)}WT";

        public string BankName => _randomDataGenerator.GenerateRandomAlphabeticString(5);

        public string AccountNumber => $"2{_randomDataGenerator.GenerateRandomNumber(7)}";

        public string Sortcode => "000002";

        public string TelephoneNumber => $"012{_randomDataGenerator.GenerateRandomNumber(8)}";

        public string FirstName => _randomDataGenerator.GenerateRandomAlphabeticString(10);

        public string SurName => _randomDataGenerator.GenerateRandomAlphabeticString(10);
    }
}
