using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ApplyDataHelpers
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        public ApplyDataHelpers(RandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            CompanyNumber = randomDataGenerator.GenerateRandomNumber(8);
            CompanyName = $"{CompanyNumber}EnterpriseTestDemo";
            IocNumber = randomDataGenerator.GenerateRandomAlphanumericString(8);
            Website = $"www.company.co.uk";
        }

        public string CompanyNumber { get; }
        public string CompanyName { get; }
        public string IocNumber { get; }
        public string Website { get; }
        public string GenerateRandomNumber(int length) => _randomDataGenerator.GenerateRandomNumber(length);
        
    }
}
