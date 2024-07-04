using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ProviderConfirmApplicantInterviewPage : RaaBasePage
    {
        protected static By NotificationBanner => By.CssSelector("#main-content > div.govuk-grid-row > div.govuk-grid-column-two-thirds.govuk-\\!-margin-bottom-6 > div > div.govuk-notification-banner__content > h3");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ProviderConfirmApplicantInterviewPage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => $"{rAADataHelper.CandidateFullName}'s application status changed to '{_status}'.";
        protected override string AccessibilityPageTitle => "Candidate application made page";

        public class ProviderInteviewingApplicantPage(ScenarioContext context) : ProviderConfirmApplicantInterviewPage(context, "interviewing")
        {
        }
    }
}
