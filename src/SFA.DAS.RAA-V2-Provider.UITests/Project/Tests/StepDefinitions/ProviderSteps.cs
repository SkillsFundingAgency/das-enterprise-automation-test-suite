using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName()
        {
            throw new PendingStepException();
        }
    }
}
