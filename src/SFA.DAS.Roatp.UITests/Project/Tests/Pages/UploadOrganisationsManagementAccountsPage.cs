using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{

    public class UploadOrganisationsManagementAccountsPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's management accounts covering the remaining period to date";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ChooseFile => By.ClassName("govuk-file-upload");

        public UploadOrganisationsManagementAccountsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhoPreparedAnswersAndUploadPage UploadManagementAccountsFileAndContinue()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + "Project\\Helpers\\UploadFiles\\" + "Sample.pdf";
            formCompletionHelper.EnterText(ChooseFile, File);
            Continue();
            return new WhoPreparedAnswersAndUploadPage(_context);
        }
    }
}
