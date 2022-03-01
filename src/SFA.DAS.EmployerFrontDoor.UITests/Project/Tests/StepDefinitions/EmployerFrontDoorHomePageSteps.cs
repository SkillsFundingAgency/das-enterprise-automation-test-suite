using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFrontDoorHomePageSteps
    {

        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public EmployerFrontDoorHomePageSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to Home page and verifies the content and accept the cookie")]
        public void GivenTheUserNavigatesToHomePageAndVerifiesTheContentAndAcceptTheCookie()
        {
            _stepsHelper.GoToEmployerFrontDoorHomePage();
        }
    
    }
}