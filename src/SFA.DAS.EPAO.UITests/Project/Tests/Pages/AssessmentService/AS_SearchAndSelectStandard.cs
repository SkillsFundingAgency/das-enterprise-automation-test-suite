using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchAndSelectStandard : BasePage
    {
        protected override string PageTitle => "Search and select the standard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EPAODataHelper _ePAODataHelper;
        #endregion

        #region Locators
        private By StandardTextBox => By.Id("SelectedStandardCode");
        private By AutoSuggestOptions => By.CssSelector(".autocomplete__option");
        #endregion

        public AS_SearchAndSelectStandard(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _ePAODataHelper = new EPAODataHelper(_context);
            VerifyPage();
        }

        public AS_WhatGradePage SelectStandardAndContinue()
        {
            _formCompletionHelper.Click(StandardTextBox);
            _ePAODataHelper.ClickFirstElementFromAutoSuggestOptions(AutoSuggestOptions);
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
