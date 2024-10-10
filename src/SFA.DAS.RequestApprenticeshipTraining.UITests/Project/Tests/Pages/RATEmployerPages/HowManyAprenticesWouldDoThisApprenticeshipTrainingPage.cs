using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(ScenarioContext context) : RatProjectBasePage(context)
    {
        protected override string PageTitle => "How many apprentices would do this apprenticeship training?";

        #region Locators
        private static By EnterNumberOfApprentices => By.CssSelector("#NumberOfApprentices");
        #endregion

        public AreTheApprenticeshipsInTheSameLocationPage EnterMoreThan1Apprentices()
        {
            EnterApprentices(RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 4));

            return new AreTheApprenticeshipsInTheSameLocationPage(context);
        }

        public WhereIsTheApprenticeshipLocationPage Enter1Apprentices()
        {
            EnterApprentices(1);

            return new WhereIsTheApprenticeshipLocationPage(context);
        }

        private void EnterApprentices(int noOfApprentice)
        {
            formCompletionHelper.EnterText(EnterNumberOfApprentices, noOfApprentice);

            Continue();
        }
    }
}