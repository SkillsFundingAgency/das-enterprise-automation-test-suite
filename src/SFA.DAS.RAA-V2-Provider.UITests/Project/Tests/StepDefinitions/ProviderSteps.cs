using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderNewSteps
    {
        private readonly ProviderCreateVacancyStepsHelper _providerStepsHelper;

        public ProviderNewSteps(ScenarioContext context) => _providerStepsHelper = new ProviderCreateVacancyStepsHelper(context);

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

        private void CreateANewVacancy() => _providerStepsHelper.CreateANewVacancy(string.Empty);
    }



    [Binding]
    public class ProviderSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

        [When(@"Provider selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void WhenProviderSelectsInTheFirstPartOfTheJourney(string wageType) => _providerStepsHelper.CreateANewVacancy(wageType);

        [When(@"the Provider creates an Offline vacancy")]
        public void WhenTheProviderCreatesAnOfflineVacancy() => _providerStepsHelper.CreateANewVacancy(string.Empty, true, false, false);

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();


        
        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();

        [Then(@"the Provider verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type)' the wage option selected in the Preview page")]
        public void ThenTheProviderVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _providerStepsHelper.VerifyWageType(wageType);

        [Then(@"Provider can view the refered vacancy")]
        public void ThenProviderCanViewTheReferedVacancy() => _providerStepsHelper.ViewReferVacancy();

        //[Then(@"the Provider creates anonymous vacancy through View all your vacancies page")]
        public void ThenTheProviderCreatesAnonymousVacancyThroughViewAllYourVacanciesPage() { }

        [Given(@"the Provider renews the employer recruitment API key")]
        public void GivenTheProviderRenewsTheEmployerRecruitmentAPIKey() => _providerStepsHelper.RenewRecruitmentAPIKey();

        [Given(@"the Provider renews the employer recruitment API sandbox key")]
        public void GivenTheProviderRenewsTheEmployerRecruitmentAPISandboxKey() => _providerStepsHelper.RenewRecruitmentAPISandboxKey();

        [Given(@"the Provider renews the employer display API key")]
        public void GivenTheProviderRenewsTheEmployerDisplayAPIKey() => _providerStepsHelper.RenewDisplayAPIKey();

        [Then(@"the provider does not renews the api key")]
        public void ThenTheProviderDoesNotRenewsTheApiKey() => _providerStepsHelper.DoesNotRenewDisplayAPIKey();
    }
}
