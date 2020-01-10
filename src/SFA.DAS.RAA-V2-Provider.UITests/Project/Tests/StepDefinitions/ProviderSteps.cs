using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
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
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(_context);
        }

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, true);

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();

        [Given(@"the Provider creates a vacancy by entering all the Optional fields")]
        public void GivenTheProviderCreatesAVacancyByEnteringAllTheOptionalFields() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, true, true);
        
        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();
    }
}
