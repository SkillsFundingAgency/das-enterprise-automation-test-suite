using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers
{
    public class ApplyDataHelpers
    {
        public ApplyDataHelpers(RandomDataGenerator randomDataGenerator)
        {
            CompanyNumber = randomDataGenerator.GenerateRandomNumber(8);
            CompanyName = $"{CompanyNumber}_EnterpriseTestDemo";
            IocNumber = randomDataGenerator.GenerateRandomAlphanumericString(8);
            Website = $"www.{CompanyName}.co.uk";
        }

        public string CompanyNumber { get; }
        public string CompanyName { get; }
        public string IocNumber { get; }
        public string Website { get; }
    }
}
