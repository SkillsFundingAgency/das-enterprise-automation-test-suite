using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhichLearningOptionPage : AS_BasePage
    {
        protected override string PageTitle => "Which learning option did the apprentice take?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By RadioButton => By.CssSelector("label");
        #endregion

        public AS_WhichLearningOptionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_WhatGradePage SelectLearningOptionAndContinue()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "options_Overheadlines");
            Continue();
            return new AS_WhatGradePage(_context);
        }
    }
}
