using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsReadyForReviewPage : ApprenticeRequestsSubPage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        public ApprenticeRequestsReadyForReviewPage(ScenarioContext context) : base(context) { }

        public ApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            SelectCurrentCohortDetailsFromTable();

            return new ApproveApprenticeDetailsPage(context);
        }
    }
}

