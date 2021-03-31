using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadUltimateParentCompanysFinancialsCoveringLastTwelveMonthsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your UK ultimate parent company's full financial statements covering the last 12 months";

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
            UploadMultipleFiles(1);
            return new ApplicationOverviewPage(_context);
        }
    }
}
