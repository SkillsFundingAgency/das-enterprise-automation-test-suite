using SFA.DAS.UI.Framework;

namespace SFA.DAS.ProviderFeedback.UITests.Project
{
    public class ProviderFeedbackConfig
    {
        public string ProviderFeedbackDbConnectionString { get; set; }

        public string ProviderFeedbackUrl => UrlConfig.ProviderFeedbackUrl;
    }
}
