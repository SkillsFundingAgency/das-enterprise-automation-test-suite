using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ProviderShareApplicationNotificationBasePage : Raav2BasePage
    {
        protected static By NotificationBanner => By.CssSelector("#main-content > div.govuk-grid-row > div.govuk-grid-column-two-thirds.govuk-\\!-margin-bottom-6 > div > div.govuk-notification-banner__content > h3");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ProviderShareApplicationNotificationBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => $"{rAAV2DataHelper.CandidateFullName}'s application {_status} with employer";
        protected override string AccessibilityPageTitle => "Candidate application made page";

        public class ProviderApplicationSharePage(ScenarioContext context) : ProviderShareApplicationNotificationBasePage(context, "shared")
        {
        }
    }
}
