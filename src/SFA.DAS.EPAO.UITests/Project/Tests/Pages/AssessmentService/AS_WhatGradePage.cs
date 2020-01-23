using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhatGradePage : EPAO_BasePage
    {
        protected override string PageTitle => "What grade did the apprentice achieve?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        private readonly ScenarioContext _context;

        #region Locators
        private By PassRadioButton => By.Id("Pass");
        private By FailRadioButton => By.Id("Fail");
        #endregion

        public AS_WhatGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void SelectGradeAndEnterDate(string grade)
        {
            if (grade == "Passed")
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PassRadioButton));
                Continue();
                new AS_AchievementDatePage(_context).EnterAchievementGradeDateAndContinue();
            }
            else if (grade == "Failed")
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FailRadioButton));
                Continue();
                new AS_ApprenticeFailedDatePage(_context).EnterAchievementGradeDateAndContinue();
            }
        }

        public AS_ApprenticeshipStartDate SelectGradeForPrivatelyFundedAprrenticeAndContinue()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(PassRadioButton));
            Continue();
            return new AS_ApprenticeshipStartDate(_context);
        }
    }
}
