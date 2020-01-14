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
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

        [When(@"Provider selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void WhenProviderSelectsInTheFirstPartOfTheJourney(string wageType) => _providerStepsHelper.CreateANewVacancy(wageType);

        [When(@"the Provider creates an Offline vacancy")]
        public void WhenTheProviderCreatesAnOfflineVacancy() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, false);

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, true);

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();

        [Given(@"the Provider creates a vacancy by entering all the Optional fields")]
        public void GivenTheProviderCreatesAVacancyByEnteringAllTheOptionalFields() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, true, true);
        
        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();

        [Then(@"the Provider verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type)' the wage option selected in the Preview page")]
        public void ThenTheProviderVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _providerStepsHelper.VerifyWageType(wageType);

        [Then(@"Provider can view the refered vacancy")]
        public void ThenProviderCanViewTheReferedVacancy() => _providerStepsHelper.ViewReferVacancy();

    }
}
