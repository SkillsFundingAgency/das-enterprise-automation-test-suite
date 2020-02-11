using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your UK ultimate parent company's full financial statements covering the last 12 months";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage UploadFullFinancialStatementsForTwelveMonthsAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }
}
