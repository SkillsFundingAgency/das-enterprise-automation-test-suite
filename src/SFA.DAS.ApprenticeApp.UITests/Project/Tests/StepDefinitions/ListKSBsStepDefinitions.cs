using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ListKSBsStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private KsbPage ksbPage;

        [When("the apprentice user clicks on the KSBs tab")]
        public void WhenTheApprenticeUserClicksOnTheKSBsTab()
        {
            ksbPage = _stepsHelper.NavigateToKsbPage();
        }

        [Then("the KSBs are displayed")]
        public void ThenTheKSBsAreDisplayed()
        {
            Assert.AreEqual("Your knowledge, skills and behaviours (KSBs)", ksbPage.KsbPageTitle());
        }
    }
}
