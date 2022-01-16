using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class SupportedInternshipsSteps
    {
        private readonly EmployerFrontDoorStepsHelper _stepsHelper;
        public SupportedInternshipsSteps(ScenarioContext context) => _stepsHelper = new EmployerFrontDoorStepsHelper(context);

        [Given(@"the user navigates to employment schemes page and verifies the SupportedInternships link")]
        public void GivenTheUserNavigatesToEmploymentSchemesPageAndVerifiesTheSupportedInternshipsLink()
        {
            _stepsHelper.GoToSupportedInternshipsDetailsPage();
        }

    }
}
