using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.FinancialHealthAssessmentSection
{
    public class AP_FHABasePage : EPAOApply_BasePage
    {
        protected override string PageTitle => "Financial health assessment";
        
        #region Locators
        private By FHALink => By.LinkText("Financial health assessment");
        #endregion

        public AP_FHABasePage(ScenarioContext context) : base(context) => VerifyPage();

        public AP_FHA_FinancialHealthPage ClickFHALinkInFHABasePage()
        {
            formCompletionHelper.Click(FHALink);
            return new AP_FHA_FinancialHealthPage(_context);
        }
    }
}
