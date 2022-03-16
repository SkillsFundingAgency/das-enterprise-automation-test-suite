using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsReadyToReview : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        public ApprenticeRequestsReadyToReview(ScenarioContext context) : base(context)  { }

        public ApproveApprenticeDetailsPage SelectViewCurrentCohortDetails(string cohortRef = null)
        {
            if (cohortRef == null || cohortRef == "")
                tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            else
                tableRowHelper.SelectRowFromTableDescending("Details", cohortRef);

            return new ApproveApprenticeDetailsPage(context);
        }
    }
}

