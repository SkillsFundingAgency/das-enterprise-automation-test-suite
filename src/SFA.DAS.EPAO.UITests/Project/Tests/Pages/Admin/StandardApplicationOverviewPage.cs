using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StandardApplicationOverviewPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Application overview";

        public StandardApplicationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplyToAssessAStandardPage GoToApplyToAssessAStandardPage()
        {
            formCompletionHelper.ClickLinkByText("Evaluate apply to assess a standard");
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