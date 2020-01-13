using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhatGradePage : BasePage
    {
        protected override string PageTitle => "What grade did the apprentice achieve?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        #region Locators
        private By PassRadioButton => By.Id("Pass");
        private By FailRadioButton => By.Id("Fail");
        #endregion

        public AS_WhatGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        public void SelectGradeAndEnterDate(string grade)
        {
            if (grade == "Passed")
            {
                _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(PassRadioButton));
                Continue();
                new AS_AchievementDatePage(_context).EnterAchievementGradeDateAndContinue();
            }
            else if (grade == "Failed")
            {
                _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(FailRadioButton));
                Continue();
                new AS_ApprenticeFailedDatePage(_context).EnterAchievementGradeDateAndContinue();
            }
        }

        public AS_ApprenticeshipStartDate SelectGradeForPrivatelyFundedAprrenticeAndContinue()
        {
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(PassRadioButton));
            Continue();
            return new AS_ApprenticeshipStartDate(_context);
        }

        public AS_CheckAndSubmitAssessmentPage ClickBackLink()
        {
            NavigateBack();
            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}
