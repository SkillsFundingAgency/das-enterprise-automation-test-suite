using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SettingsStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private SettingsPage settingsPage;

        [When("the apprentice clicks on settings")]
        public void WhenTheApprenticeClicksOnSettings()
        {
            settingsPage = _stepsHelper.NavigateToSettingsPage();
        }

        [Then("the settings options are displayed")]
        public void ThenTheSettingsOptionsAreDisplayed()
        {
            Assert.AreEqual("Settings", settingsPage.SettingsPageTitle());
        }
    }
}
