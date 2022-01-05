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
            return new ApplyToAssessAStandardPage(context);
        }

        public StandardApplicationsPage ReturnToOrganisationApplicationsPage()
        {
            formCompletionHelper.ClickLinkByText("Return to applications");
            return new StandardApplicationsPage(context);
        }

        public AssessmentSummaryPage CompleteReview()
        {
            Continue();
            return new AssessmentSummaryPage(context);
        }
    }
}