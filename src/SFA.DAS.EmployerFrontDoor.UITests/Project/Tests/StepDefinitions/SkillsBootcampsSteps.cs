using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class SkillsBootcampsSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public SkillsBootcampsSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the SkillsBootcamps link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheSkillsBootcampsLink()
        {
            _stepsHelper.GoToSkillsBootcampsDetailsPage();
        }

    }
}
