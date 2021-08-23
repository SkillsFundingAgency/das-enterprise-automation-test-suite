using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsDataHelper : RandomElementHelper
    {
        public CampaignsDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            Firstname = randomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = randomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }
    }
}
