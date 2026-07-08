using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class LearnerRequestDraftsPage(ScenarioContext context) : ApprenticeRequestsSubPage(context)
    {
        protected override string PageTitle => "Learner requests";

        protected override bool TakeFullScreenShot => false;

        public ApproveLearnerDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ApproveLearnerDetailsPage(context);
        }
    }
}

