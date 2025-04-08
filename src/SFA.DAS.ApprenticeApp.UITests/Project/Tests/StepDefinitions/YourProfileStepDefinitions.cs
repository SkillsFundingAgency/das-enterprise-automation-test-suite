using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;
using SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class YourProfileStepDefinitions(ScenarioContext context)
    {
        private readonly AppStepsHelper _stepsHelper = new(context);
        private YourProfilePage yourProfilePage;

        [When("the apprentice clicks on the account tab")]
        public void WhenTheApprenticeClicksOnTheAccountTab()
        {
            var accountPage = _stepsHelper.NavigateToAccountPage();
        }

        [When("the apprentice clicks on your profile")]
        public void WhenTheApprenticeClicksOnYourProfile()
        {
            yourProfilePage = _stepsHelper.NavigateToYourProfilePage();
        }

        [Then("the profile page is displayed")]
        public void ThenTheProfilePageIsDisplayed()
        {
            Assert.AreEqual("Your profile", yourProfilePage.YourProfilePageTitle());
        }
    }
}
