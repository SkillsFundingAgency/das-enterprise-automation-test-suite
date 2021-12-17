using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class SWAPSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public SWAPSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the SWAP link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheSWAPLink()
        {
            _stepsHelper.GoToSWAPDetailsPage();
        }

    }
}
