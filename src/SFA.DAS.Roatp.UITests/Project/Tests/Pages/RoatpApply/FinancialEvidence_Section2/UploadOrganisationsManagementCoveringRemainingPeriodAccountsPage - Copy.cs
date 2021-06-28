using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.FinancialEvidence_Section2
{
    public class UploadOrganisationsManagementCoveringRemainingPeriodAccountsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's management accounts covering the remaining period to date";


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public UploadOrganisationsManagementCoveringRemainingPeriodAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoPreparedAnswersAndUploadPage UploadRemainingPeriodManagementAccountsFileAndContinue()
        {
            UploadMultipleFiles(2);
            return new WhoPreparedAnswersAndUploadPage(_context);
        }
    }
}
