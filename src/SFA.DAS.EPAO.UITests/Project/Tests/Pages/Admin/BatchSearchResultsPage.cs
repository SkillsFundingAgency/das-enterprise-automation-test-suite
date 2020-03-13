using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class BatchSearchResultsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Search results";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By BatchDetailsHeader => By.CssSelector(".govuk-heading-l");

        public BatchSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public BatchSearchResultsPage VerifyingBatchDetails()
        {
            VerifyPage(BatchDetailsHeader, "Batch details");
            return new BatchSearchResultsPage(_context);
        }
    }

}
