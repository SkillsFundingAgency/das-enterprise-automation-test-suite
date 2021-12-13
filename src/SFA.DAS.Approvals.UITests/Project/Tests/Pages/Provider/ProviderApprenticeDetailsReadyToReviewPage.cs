using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsReadyToReviewPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details ready for review";

        protected override bool TakeFullScreenShot => false;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderApprenticeDetailsReadyToReviewPage(ScenarioContext context) : base(context) => _context = context;


        public ProviderApproveApprenticeDetailsPage SelectViewCurrentCohortDetails()
        {
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderApproveApprenticeDetailsPage(_context);
        }        
    }
}