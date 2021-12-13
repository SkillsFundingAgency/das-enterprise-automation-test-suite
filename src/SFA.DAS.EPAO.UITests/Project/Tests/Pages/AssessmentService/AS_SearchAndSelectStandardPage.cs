using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchAndSelectStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search and select the standard";
        
        #region Locators
        private By StandardTextBox => By.Id("SelectedStandardCode");
        private By AutoSuggestOptions => By.CssSelector(".autocomplete__option");
        #endregion

        public AS_SearchAndSelectStandardPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_WhatGradePage SelectStandardAndContinue()
        {
            formCompletionHelper.Click(StandardTextBox);
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(AutoSuggestOptions));
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
