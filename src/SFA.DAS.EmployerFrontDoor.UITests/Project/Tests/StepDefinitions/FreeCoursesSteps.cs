using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class FreeCoursesSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public FreeCoursesSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the FreeCourses link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheFreeCoursesLink()
        {
            _stepsHelper.GoToFreeCoursesDetailsPage();
        }

    }
}