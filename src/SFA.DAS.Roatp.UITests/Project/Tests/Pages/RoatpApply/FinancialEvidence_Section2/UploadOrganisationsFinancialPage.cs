using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadOrganisationsFinancialPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's financial statements covering any period within the last 12 months";
      

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadOrganisationsFinancialPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UploadOrganisationsManagementAccountsPage UploadFinancialFileAndContinue()
        {
            UploadFile();
            return new UploadOrganisationsManagementAccountsPage(_context);
        }
    }
}
