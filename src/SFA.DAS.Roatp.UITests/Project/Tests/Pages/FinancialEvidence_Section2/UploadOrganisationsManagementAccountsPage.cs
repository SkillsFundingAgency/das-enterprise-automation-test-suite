using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.FinancialEvidence_Section2
{
    public class UploadOrganisationsManagementAccountsPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's management accounts covering the remaining period to date";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadOrganisationsManagementAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoPreparedAnswersAndUploadPage UploadManagementAccountsFileAndContinue()
        {
            UploadFile();
            return new WhoPreparedAnswersAndUploadPage(_context);
        }
    }
}
