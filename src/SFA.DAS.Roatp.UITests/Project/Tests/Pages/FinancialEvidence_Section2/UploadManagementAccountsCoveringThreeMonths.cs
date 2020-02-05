using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class UploadManagementAccountsCoveringThreeMonths : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's management accounts covering at least 3 months within the last 12 months";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadManagementAccountsCoveringThreeMonths(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UploadFinancialProjectionsPage UploadManagementAccountsAndContinue()
        {
            UploadFile();
            return new UploadFinancialProjectionsPage(_context);
        }
    }
}
