using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsWithTransferSendingEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details with transfer sending employers";

        protected override bool TakeFullScreenShot => false;


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderApprenticeDetailsWithTransferSendingEmployersPage(ScenarioContext context) : base(context) => _context = context;

        internal ProvideViewApprenticesDetailsPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProvideViewApprenticesDetailsPage(_context);
        }
    }
}

