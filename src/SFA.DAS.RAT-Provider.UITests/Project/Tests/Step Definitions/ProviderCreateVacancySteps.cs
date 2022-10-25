using SFA.DAS.RAT_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Step_Definitions
{
    [Binding]
    public class ProviderCreateVacancySteps
    {
        private readonly ProviderCreateVacancyStepsHelper _providerStepsHelper;

        public ProviderCreateVacancySteps(ScenarioContext context) => _providerStepsHelper = new ProviderCreateVacancyStepsHelper(context);

        [Given(@"the Provider creates traineeship vacancy through View all your traineeship vacancies page")]
        [Then(@"the Provider creates traineeship vacancy through View all your traineeship vacancies page")]
        public void ThenTheProviderCreatesTraineeshipVacancyThroughViewAllYourTraineeshipsVacanciesPage() => _providerStepsHelper.CreateANewTraineeshipVacancy();

        [Then(@"the Provider creates anonymous vacancy through View all your vacancies page")]
        public void ThenTheProviderCreatesAnonymousVacancyThroughViewAllYourVacanciesPage() => _providerStepsHelper.CreateANewVacancyForRandomEmployer();
       
        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => CreateANewVacancy();

        [Given(@"the Provider creates a traineeship vacancy by entering all the Optional fields")]
        public void GivenTheProviderCreatesATraineeshipVacancyByEnteringAllTheOptionalFields()
        {
            _providerStepsHelper.optionalFields = true;

            CreateANewVacancy();
        }
        [When(@"the Provider creates an Offline vacancy")]
        public void WhenTheProviderCreatesAnOfflineVacancy() => _providerStepsHelper.CreateOfflineVacancy();

        private void CreateANewVacancy() => _providerStepsHelper.CreateANewTraineeshipVacancy();
    }
}
