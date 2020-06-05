using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortsForReviewPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details ready for review";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CohortsForReviewPage(ScenarioContext context) : base(context) => _context = context;

        public ReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ReviewYourCohortPage(_context);
        }
    }
}

