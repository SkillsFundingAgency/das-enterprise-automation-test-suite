using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsDraftsPage : ApprovalsBasePage
    {   
        protected override string PageTitle => "Draft apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderCohortsDraftsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
