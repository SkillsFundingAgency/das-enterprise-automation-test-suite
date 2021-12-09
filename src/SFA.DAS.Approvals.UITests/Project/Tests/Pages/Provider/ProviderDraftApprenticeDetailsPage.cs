using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderDraftApprenticeDetailsPage : ApprovalsBasePage
    {   
        protected override string PageTitle => "Draft apprentice details";

        protected override bool TakeFullScreenShot => false;


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderDraftApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(_context);
        }
    }
}
