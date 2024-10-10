using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class CheckYourAnswersPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "Check your answers";

        #region Locators
        private static By ClickChangeHowManyApprentices => By.CssSelector("a[id='NumberOfApprentices-change']");
        private static By ClickChangeOneApprenticeshipLocation => By.CssSelector("a[id='SameLocation-change']");
        private static By ClickChangeApprenticeshipLocations => By.CssSelector("a[id='MultipleLocations-change']");
        private static By ClickChangeTrainingOptions => By.CssSelector("a[id='AtApprenticesWorkplace-change']");
        #endregion

        public void SubmitAnswers()
        {
            Continue();
        }

        public HowManyAprenticesWouldDoThisApprenticeshipTrainingPage ChangeHowManyApprentices()
        {
            ClickChange(ClickChangeHowManyApprentices);

            return new (context);
        }

        public AreTheApprenticeshipsInTheSameLocationPage ChangeOneApprenticeshipLocation()
        {
            ClickChange(ClickChangeOneApprenticeshipLocation);

            return new(context);
        }

        public WhereIsTheApprenticeshipLocationPage ChangeApprenticeshipLocations()
        {
            ClickChange(ClickChangeApprenticeshipLocations);

            return new(context);
        }

        public SelectTrainingOptionsPage ChangeTrainingOptions()
        {
            ClickChange(ClickChangeTrainingOptions);

            return new(context);
        }

        private void ClickChange(By by) => formCompletionHelper.Click(by);
    }
}
