using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class ApprenticeshipsSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public ApprenticeshipsSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the apprenticeships link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheApprenticeshipsLink()
        {
            _stepsHelper.GoToApprenticeshipsDetailsPage();
        }
    }
}
