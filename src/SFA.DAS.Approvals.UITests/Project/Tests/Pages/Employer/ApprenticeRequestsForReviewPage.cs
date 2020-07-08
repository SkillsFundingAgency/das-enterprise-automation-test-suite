using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestsReadyToReview : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeRequestsReadyToReview(ScenarioContext context) : base(context) => _context = context;

        public ReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ReviewYourCohortPage(_context);
        }
    }
}

