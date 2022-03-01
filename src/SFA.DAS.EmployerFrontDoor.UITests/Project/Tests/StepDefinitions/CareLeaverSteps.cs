using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class CareLeaverSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public CareLeaverSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the CareLeaver link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheCareLeaverLink()
        {
            _stepsHelper.GoToCareLeaverDetailsPage();
        }
    }
}