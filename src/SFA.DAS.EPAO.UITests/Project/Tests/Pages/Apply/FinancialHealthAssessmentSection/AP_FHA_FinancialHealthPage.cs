using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection
{
    public class AP_FHA_FinancialHealthPage : EPAOApply_BasePage
    {
        protected override string PageTitle => "Financial health";
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _frameworkConfig;

        #region Locators
        private By ChooseFileOption => By.Id("FHA-01");
        #endregion

        public AP_FHA_FinancialHealthPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
            _frameworkConfig = context.Get<FrameworkConfig>();
        }

        public AP_FHABasePage UploadFileAndContinueInFinancialHealthPage()
        {
            string File = AppDomain.CurrentDomain.BaseDirectory + _frameworkConfig.SampleFileName;
            formCompletionHelper.EnterText(ChooseFileOption, File);
            Continue();
            return new AP_FHABasePage(_context);
        }
    }
}
