using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection
{
    public class AP_FHA_FinancialHealthPage : EPAO_BasePage
    {
        protected override string PageTitle => "Financial health";
        private readonly ScenarioContext _context;

        #region Locators
        private By ChooseFileOption => By.Id("FHA-01");
        #endregion

        public AP_FHA_FinancialHealthPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AP_FHABasePage UploadFileAndContinueInFinancialHealthPage()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + "Project\\Helpers\\UploadFiles\\" + "Sample.pdf";
            formCompletionHelper.EnterText(ChooseFileOption, File);
            Continue();
            return new AP_FHABasePage(_context);
        }
    }
}
