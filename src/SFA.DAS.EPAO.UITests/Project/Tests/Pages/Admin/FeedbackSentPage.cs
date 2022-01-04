using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class FeedbackSentPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Feedback sent";

        public FeedbackSentPage(ScenarioContext context) : base(context) => VerifyPage();

        public OrganisationApplicationsPage ReturnToOrganisationApplications()
        {
            ReturnToApplications();
            return new OrganisationApplicationsPage(context);
        }

        public StandardApplicationsPage ReturnToStandardApplications()
        {
            ReturnToApplications();
            return new StandardApplicationsPage(context);
        }

        private void ReturnToApplications() => formCompletionHelper.ClickLinkByText("Return to applications");
    }
}