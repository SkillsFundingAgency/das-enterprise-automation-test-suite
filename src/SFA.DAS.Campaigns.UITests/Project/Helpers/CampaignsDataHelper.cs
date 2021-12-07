using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsDataHelper
    {
        public CampaignsDataHelper()
        {
            Firstname = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = RandomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }
    }
}
