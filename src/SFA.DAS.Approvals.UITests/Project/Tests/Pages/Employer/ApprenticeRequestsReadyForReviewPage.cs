using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsReadyForReviewPage(ScenarioContext context) : ApprenticeRequestsSubPage(context)
    {
        protected override string PageTitle => "Review learner requests";

        protected override bool TakeFullScreenShot => false;

        public ApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ApproveApprenticeDetailsPage(context);
        }
        
        public ApproveApprenticeDetailsPage SelectSingleReadyForReviewRequestInTable()
        {
            SelectSingleRequestInTable();

            return new ApproveApprenticeDetailsPage(context);
        }
    }
}

