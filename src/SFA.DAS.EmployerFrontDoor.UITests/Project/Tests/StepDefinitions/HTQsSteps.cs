using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class HTQsSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public HTQsSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the HTQs link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheHTQsLink()
        {
            _stepsHelper.GoToHTQsDetailsPage();
        }

    }
}
