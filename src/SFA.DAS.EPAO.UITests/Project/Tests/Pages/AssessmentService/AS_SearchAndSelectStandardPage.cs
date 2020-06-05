using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchAndSelectStandardPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search and select the standard";
        private readonly ScenarioContext _context;

        #region Locators
        private By StandardTextBox => By.Id("SelectedStandardCode");
        private By AutoSuggestOptions => By.CssSelector(".autocomplete__option");
        #endregion

        public AS_SearchAndSelectStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_WhatGradePage SelectStandardAndContinue()
        {
            formCompletionHelper.Click(StandardTextBox);
            var autoSuggestOptionElements = pageInteractionHelper.FindElements(AutoSuggestOptions);
            formCompletionHelper.ClickElement(() => dataHelper.GetRandomElementFromListOfElements(autoSuggestOptionElements, false, 0));
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
