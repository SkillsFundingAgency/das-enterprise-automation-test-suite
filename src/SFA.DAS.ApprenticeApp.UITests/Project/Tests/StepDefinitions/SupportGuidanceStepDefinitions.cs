using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SupportGuidanceStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private SupportGuidancePage supportGuidancePage;

        [When("the apprentice clicks on the support and guidance tab")]
        public void WhenTheApprenticeClicksOnTheSupportAndGuidanceTab()
        {
            supportGuidancePage = _stepsHelper.NavigateToSupportGuidancePage();
        }

        [Then("the support and guidance articles are displayed")]
        public void ThenTheSupportAndGuidanceArticlesAreDisplayed()
        {
            Assert.AreEqual("Support and guidance", supportGuidancePage.SupportGuidancePageTitle());
        }
    }
}
