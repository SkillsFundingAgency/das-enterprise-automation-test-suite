using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class AskIfTrainingProvidersCanRunThisCoursePage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Ask if training providers can run this course";

        #region Locators
        private static By ClickStartNowButton => By.CssSelector(".govuk-button govuk-button--start");
        #endregion

        public HowManyAprenticesWouldDoThisApprenticeshipTrainingPage ClickStarNow()
        {
            formCompletionHelper.Click(ClickStartNowButton);

            return new HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(context);
        }
    }
}