using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeRequestDraftsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice requests";

        protected override bool TakeFullScreenShot => false;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeRequestDraftsPage(ScenarioContext context) : base(context) => _context = context;

        public ApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ApproveApprenticeDetailsPage(_context);
        }
    }
}

