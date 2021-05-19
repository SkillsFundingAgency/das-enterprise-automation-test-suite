using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_WhatGradePage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "What grade did the apprentice achieve?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        private readonly ScenarioContext _context;

        #region Locators
        private By PassRadioButton => By.Id("Pass");
        private By FailRadioButton => By.Id("Fail");
        private By PassWithExcellenceRadioButton => By.Id("Pass_with_excellence"); 
        #endregion

        public AS_WhatGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public void SelectGradeAndEnterDate(string grade)
        {
            switch (grade)
            {
                case "pass":
                    SelectGrade(PassRadioButton);
                    new AS_AchievementDatePage(_context).EnterAchievementGradeDateAndContinue();
                    break;
                case "PassWithExcellence":
                    SelectGrade(PassWithExcellenceRadioButton);
                    new AS_AchievementDatePage(_context).EnterAchievementGradeDateAndContinue();
                    break;
                case "fail":
                    SelectGrade(FailRadioButton);
                    new AS_ApprenticeFailedDatePage(_context).EnterAchievementGradeDateAndContinue();
                    break;
            }
        }

        public AS_AchievementDatePage SelectGradeForPrivatelyFundedAprrenticeAndContinue()
        {
            SelectGrade(PassRadioButton);
            return new AS_AchievementDatePage(_context);
        }

        private void SelectGrade(By by)
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(by));
            Continue();
        }
    }
}