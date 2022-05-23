using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRecruitmentAPISteps
    {
        private readonly ProviderApiKeyStepsHelper _providerStepsHelper;

        public ProviderRecruitmentAPISteps(ScenarioContext context) => _providerStepsHelper = new ProviderApiKeyStepsHelper(context);

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
