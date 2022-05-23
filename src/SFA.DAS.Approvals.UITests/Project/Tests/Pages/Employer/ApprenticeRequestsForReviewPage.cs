using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsReadyToReview : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        public ApprenticeRequestsReadyToReview(ScenarioContext context) : base(context)  { }

        public ApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());

            return new ApproveApprenticeDetailsPage(context);
        }
    }
}

