using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchAndSelectStandardPage : BasePage
    {
        protected override string PageTitle => "Search and select the standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RandomElementHelper _dataHelper;
        #endregion

        #region Locators
        private By StandardTextBox => By.Id("SelectedStandardCode");
        private By AutoSuggestOptions => By.CssSelector(".autocomplete__option");
        #endregion

        public AS_SearchAndSelectStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<RandomElementHelper>();
            VerifyPage();
        }

        public AS_WhatGradePage SelectStandardAndContinue()
        {
            _formCompletionHelper.Click(StandardTextBox);
            var autoSuggestOptionElements = _pageInteractionHelper.FindElements(AutoSuggestOptions);
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(autoSuggestOptionElements, false, 0));
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
