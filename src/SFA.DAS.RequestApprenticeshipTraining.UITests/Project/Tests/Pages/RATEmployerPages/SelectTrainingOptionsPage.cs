using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class SelectTrainingOptionsPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Select training options";

        #region Locators
        private readonly By AtApprenticesWorkplace = By.CssSelector("label[for='AtApprenticesWorkplace']");
        private readonly By DayRelease = By.CssSelector("label[for='DayRelease']");
        private readonly By BlockRelease = By.CssSelector("label[for='BlockRelease']");
        #endregion

        public CheckYourAnswersPage SelectTrainingOptions()
        {
            formCompletionHelper.Click(AtApprenticesWorkplace);
            formCompletionHelper.Click(DayRelease);
            formCompletionHelper.Click(BlockRelease);
            Continue();
            return new CheckYourAnswersPage(context);
        }
    }
}
