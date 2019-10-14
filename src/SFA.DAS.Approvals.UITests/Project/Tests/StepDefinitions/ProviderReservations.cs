using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderReservations
    {
        private readonly ScenarioContext _context;

        public ProviderReservations(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"An Employer has given create reservation permission to a provider")]
        public void GivenAnEmployerHasGivenCreateReservationPermissionToAProvider()
        {
            throw new PendingStepException();
        }

        [When(@"Provider login and makes a reservation")]
        public void WhenProviderLoginAndMakesAReservation()
        {
            throw new PendingStepException();
        }

        [Then(@"Funding is reserved successfully")]
        public void ThenFundingIsReservedSuccessfully()
        {
            throw new PendingStepException();
        }



    }
}
