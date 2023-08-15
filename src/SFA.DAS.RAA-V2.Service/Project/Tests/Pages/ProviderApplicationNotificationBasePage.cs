using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class ProviderApplicationNotificationBasePage : Raav2BasePage
    {
        protected static By NotificationBanner => By.CssSelector(".govuk-notification-banner");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ProviderApplicationNotificationBasePage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }

        protected override string PageTitle => $"{rAAV2DataHelper.CandidateFullName}'s application made {_status}.";
    }

    public class ProviderApplicationSuccessfulPage : ProviderApplicationNotificationBasePage
    {
        public ProviderApplicationSuccessfulPage(ScenarioContext context) : base(context, "successful")
        {

        }
    }

    public class ProviderApplicationUnsuccessfulPage : ProviderApplicationNotificationBasePage
    {
        public ProviderApplicationUnsuccessfulPage(ScenarioContext context) : base(context, "unsuccessful")
        {

        }
    }
}
