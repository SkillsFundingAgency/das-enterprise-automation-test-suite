using SFA.DAS.RAT_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Step_Definitions
{
    [Binding]
    public class ProviderCreateVacancySteps
    {
        private readonly ProviderCreateVacancyStepsHelper _providerStepsHelper;

        public ProviderCreateVacancySteps(ScenarioContext context) => _providerStepsHelper = new ProviderCreateVacancyStepsHelper(context);

        [Then(@"the Provider creates anonymous vacancy through View all your vacancies page")]
        public void ThenTheProviderCreatesAnonymousVacancyThroughViewAllYourVacanciesPage() => _providerStepsHelper.CreateANewVacancyForRandomEmployer();
        [Given(@"the Provider creates a vacancy by using a registered name")]
        public void GivenTheProviderCreatesAVacancyByUsingARegisteredName() => CreateANewVacancy();

        private void CreateANewVacancy() => _providerStepsHelper.CreateANewVacancyForRandomEmployer();
    }
}
