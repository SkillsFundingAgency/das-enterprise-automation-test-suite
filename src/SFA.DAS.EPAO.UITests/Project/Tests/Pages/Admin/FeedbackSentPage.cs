using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class FeedbackSentPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Feedback sent";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FeedbackSentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public OrganisationApplicationsPage ReturnToOrganisationApplications()
        {
            ReturnToApplications();
            return new OrganisationApplicationsPage(_context);
        }

        public StandardApplicationsPage ReturnToStandardApplications()
        {
            ReturnToApplications();
            return new StandardApplicationsPage(_context);
        }

        private void ReturnToApplications() => formCompletionHelper.ClickLinkByText("Return to applications");
    }
}