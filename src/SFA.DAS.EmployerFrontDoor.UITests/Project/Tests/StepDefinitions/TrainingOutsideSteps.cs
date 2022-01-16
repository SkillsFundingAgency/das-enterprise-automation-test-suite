using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class TrainingOutsideSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public TrainingOutsideSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the TrainingOutside link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheTrainingOutsideLink()
        {
            _stepsHelper.GoToTrainingOutsideDetailsPage();
        }

    }
}
