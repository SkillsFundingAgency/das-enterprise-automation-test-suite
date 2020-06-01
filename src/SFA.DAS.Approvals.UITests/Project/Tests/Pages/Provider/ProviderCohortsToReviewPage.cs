using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsToReviewPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details ready for review";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderCohortsToReviewPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }        
    }
}