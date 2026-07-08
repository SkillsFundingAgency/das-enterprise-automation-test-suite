using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class LearnerRequestsReadyForReviewPage(ScenarioContext context) : ApprenticeRequestsSubPage(context)
    {
        protected override string PageTitle => "Learner requests";

        protected override bool TakeFullScreenShot => false;

        public ApproveLearnerDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ApproveLearnerDetailsPage(context);
        }
        
        public ApproveLearnerDetailsPage SelectSingleReadyForReviewRequestInTable()
        {
            SelectSingleRequestInTable();

            return new ApproveLearnerDetailsPage(context);
        }
    }
}

