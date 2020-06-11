using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StandardApplicationOverviewPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Application overview";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public StandardApplicationOverviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplyToAssessAStandardPage GoToApplyToAssessAStandardPage()
        {
            formCompletionHelper.ClickLinkByText("Apply to assess a standard");
            return new ApplyToAssessAStandardPage(_context);
        }

        public StandardApplicationsPage ReturnToOrganisationApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to applications");
            return new StandardApplicationsPage(_context);
        }

        public AssessmentSummaryPage CompleteReview()
        {
            Continue();
            return new AssessmentSummaryPage(_context);
        }
    }
}