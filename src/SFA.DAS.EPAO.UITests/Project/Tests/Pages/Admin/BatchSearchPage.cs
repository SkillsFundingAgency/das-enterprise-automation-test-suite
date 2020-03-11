using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class BatchSearchPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Batch search";

        protected override By PageHeader => By.CssSelector(".govuk-label--xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By BatchNumber => By.CssSelector("#BatchNumber");

        public BatchSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public BatchSearchResultsPage SearchBatches()
        {
            formCompletionHelper.EnterText(BatchNumber, ePAOAdminDataHelper.BatchSearch);
            Continue();
            return new BatchSearchResultsPage(_context);
        }
    }
}
