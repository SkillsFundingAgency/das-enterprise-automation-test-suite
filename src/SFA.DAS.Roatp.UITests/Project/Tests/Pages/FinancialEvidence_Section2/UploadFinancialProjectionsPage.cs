using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class UploadFinancialProjectionsPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's financial projections covering the remaining period";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadFinancialProjectionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoPreparedAnswersAndUploadPage UploadFinancialProjectionsAndContinue()
        {
            UploadFile();
            return new WhoPreparedAnswersAndUploadPage(_context);
        }
    }
}