using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadOrganisationsManagementAccountsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's full management accounts for the last 12 months";


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
            UploadMultipleFiles(2);
            return new WhoPreparedAnswersAndUploadPage(_context);
        }
    }
}
