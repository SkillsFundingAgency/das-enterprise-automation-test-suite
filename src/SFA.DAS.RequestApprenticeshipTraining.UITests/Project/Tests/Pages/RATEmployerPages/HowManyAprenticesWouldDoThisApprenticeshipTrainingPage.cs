using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.RATEmployerPages
{
    public class HowManyAprenticesWouldDoThisApprenticeshipTrainingPage(ScenarioContext context) : BasePage(context)
    {
        protected override string PageTitle => "How many apprentices would do this apprenticeship training?";

        #region Locators
        private static By EnterNumberOfApprentices => By.CssSelector(".govuk-input govuk-input--width-4");
        #endregion

        public AreTheApprenticeshipsInTheSameLocationPage EnterHowManypprentices()
        {
            formCompletionHelper.EnterText(EnterNumberOfApprentices, 1);
            Continue();
            return new AreTheApprenticeshipsInTheSameLocationPage(context);
        }
    }
}