using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ProviderShareApplicationNotificationBasePage : RaaBasePage
    {
        protected static By NotificationBanner => By.CssSelector(".govuk-notification-banner__heading");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ProviderShareApplicationNotificationBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => "Application shared with employer.";
        protected override string AccessibilityPageTitle => "Candidate application made page";

        public class ProviderApplicationSharePage(ScenarioContext context) : ProviderShareApplicationNotificationBasePage(context, "shared")
        {
        }
    }
}
