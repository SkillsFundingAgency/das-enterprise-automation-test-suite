using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeApp.UITests.Project.Helpers;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AppLoginStepDefinitions
    {
        private readonly AppStepsHelper _stepsHelper;
        public AppLoginStepDefinitions(ScenarioContext context)
        {
            _stepsHelper = new AppStepsHelper(context);
        }
        
        [Given(@"the apprentice has accepted the cookies")]
        public void GivenTheApprenticeHasAcceptedCookies()
        {
            _stepsHelper.GoToHomePage();
        }

        [When("the apprentice logs into the app")]
        public void WhenTheApprenticeLogsIntoTheApp()
        {
            _stepsHelper.GoToStubSigin();
        }

        [When(@"the apprentice is taken to the welcome page")]
        public void ThenTheApprenticeIsTakenToTheHomeScreen()
        {
            _stepsHelper.GoToWelcomePage();
        }

        [Then("the apprentice is taken to the tasks page")]
        public void ThenTheApprenticeIsTakenToTheTasksPage()
        {
            _stepsHelper.GoToTasksPage();
        }

        [Given("the apprentice has logged into the app")]
        public void GivenTheApprenticeHasLoggedIntoTheApp()
        {
            _stepsHelper.GoToHomePage();
            _stepsHelper.GoToStubSigin();
            _stepsHelper.GoToWelcomePage();
            _stepsHelper.GoToTasksPage();
        }
    }
}
