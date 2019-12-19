using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_DeclarationPage : BasePage
    {
        protected override string PageTitle => "Declaration";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By ConfirmAndRecordAGradeButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_DeclarationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_WhatGradePage ClickConfirmInDeclarationPage()
        {
            _formCompletionHelper.Click(ConfirmAndRecordAGradeButton);
            return new AS_WhatGradePage(_context);
        }
    }
}
