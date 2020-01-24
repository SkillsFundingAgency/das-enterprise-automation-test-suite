using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class UploadOrganisationsFinancialPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's financial statements covering any period within the last 12 months";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChooseFile => By.ClassName("govuk-file-upload");

        public UploadOrganisationsFinancialPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public UploadOrganisationsManagementAccountsPage UploadFinancialFileAndContinue()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + "Project\\Helpers\\UploadFiles\\" + "Sample.pdf";
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
            return new UploadOrganisationsManagementAccountsPage(_context);
        }

    }
}
