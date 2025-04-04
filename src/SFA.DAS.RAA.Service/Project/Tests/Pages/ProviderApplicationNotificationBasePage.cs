using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ProviderApplicationNotificationBasePage : RaaBasePage
    {
        protected static By NotificationBanner => By.CssSelector(".govuk-notification-banner__heading");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ProviderApplicationNotificationBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }

        protected override string PageTitle => $"Application made {_status}.";

        protected override string AccessibilityPageTitle => "Candidate application made page";
    }

    public class ProviderApplicationSuccessfulPage(ScenarioContext context) : ProviderApplicationNotificationBasePage(context, "successful")
    {
    }

    public class ProviderApplicationUnsuccessfulPage(ScenarioContext context) : ProviderApplicationNotificationBasePage(context, "unsuccessful")
    {
    }
} 
