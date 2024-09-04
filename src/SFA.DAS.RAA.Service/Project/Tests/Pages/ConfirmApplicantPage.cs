using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public abstract class ConfirmApplicantPage : RaaBasePage
    {
        protected static By NotificationBanner => By.CssSelector("#main-content > div:nth-child(1) > div:nth-child(1) > div > div.govuk-notification-banner__content > h3");

        protected override By PageHeader => NotificationBanner;

        private readonly string _status;

        public ConfirmApplicantPage(ScenarioContext context, string status) : base(context, false)
        {
            _status = status;

            VerifyPage();
        }
        protected override string PageTitle => $"{rAADataHelper.CandidateFullName}'s application status changed to '{_status}'.";
        protected override string AccessibilityPageTitle => "Candidate application made page";

        public class ProviderInteviewingApplicantPage(ScenarioContext context) : ConfirmApplicantPage(context, "interviewing")
        {
        }

        public class ProviderAndEmployerReviewingApplicantPage(ScenarioContext context) : ConfirmApplicantPage(context, "in review")
        {
        }

        public class EmployerInteviewingApplicantPage(ScenarioContext context) : ConfirmApplicantPage(context, "interviewing")
        {
        }
    }
}
