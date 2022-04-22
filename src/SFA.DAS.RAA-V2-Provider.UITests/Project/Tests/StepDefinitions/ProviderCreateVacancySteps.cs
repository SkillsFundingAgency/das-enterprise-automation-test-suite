using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderCreateVacancySteps
    {
        private readonly ProviderCreateVacancyStepsHelper _providerStepsHelper;

        public ProviderCreateVacancySteps(ScenarioContext context) => _providerStepsHelper = new ProviderCreateVacancyStepsHelper(context);

        [Then(@"the Provider creates anonymous vacancy through View all your vacancies page")]
        public void ThenTheProviderCreatesAnonymousVacancyThroughViewAllYourVacanciesPage() => _providerStepsHelper.CreateAnonymousVacancy();

        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => CreateANewVacancy();

        [Given(@"the Provider creates a vacancy by entering all the Optional fields")]
        public void GivenTheProviderCreatesAVacancyByEnteringAllTheOptionalFields()
        {
            _providerStepsHelper.optionalFields = true;

            CreateANewVacancy();
        }

        [When(@"the Provider creates an Offline vacancy")]
        public void WhenTheProviderCreatesAnOfflineVacancy() => _providerStepsHelper.CreateOfflineVacancy();


        [When(@"Provider selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void WhenProviderSelectsInTheFirstPartOfTheJourney(string wageType) => _providerStepsHelper.CreateVacancyForWageType(wageType);

        private void CreateANewVacancy() => _providerStepsHelper.CreateANewVacancyForRandomEmployer();
    }
}
