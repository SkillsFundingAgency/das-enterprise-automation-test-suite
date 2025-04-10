using System;
using SFA.DAS.RAAProvider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRecruitmentAPISteps(ScenarioContext context)
    {
        private readonly ProviderApiKeyStepsHelper _providerStepsHelper = new(context);

        [Given(@"the Provider renews the employer recruitment API key")]
        public void GivenTheProviderRenewsTheEmployerRecruitmentAPIKey() => _providerStepsHelper.RenewRecruitmentAPIKey();

        [Given(@"the Provider renews the employer recruitment API sandbox key")]
        public void GivenTheProviderRenewsTheEmployerRecruitmentAPISandboxKey() => _providerStepsHelper.RenewRecruitmentAPISandboxKey();

        [Given(@"the Provider renews the employer display API key")]
        public void GivenTheProviderRenewsTheEmployerDisplayAPIKey() => _providerStepsHelper.RenewDisplayAPIKey();

        [Then(@"the provider does not renews the api key")]
        public void ThenTheProviderDoesNotRenewsTheApiKey() => _providerStepsHelper.DoesNotRenewDisplayAPIKey();

        [Then(@"the provider views '(.*)'")]
        public void ThenTheProviderViewsApi(string apiName)
        {
            switch (apiName)
            {
                case "Display advert api":
                    _providerStepsHelper.VerifyDisplayApiPage();
                    break;
                case "Recruitment api":
                    _providerStepsHelper.VerifyRecruitmentApiPage();
                    break;
                case "API List page":
                    _providerStepsHelper.VerifyDisplayApiText();
                    break;
                default:
                    throw new ArgumentException($"Unknown API name: {apiName}");
            }

        }
        [Then(@"the provider signs in to developer hub")]
        public void ThenTheProviderSignsIntoDeveloperHub() 
        {
            _providerStepsHelper.ClickDevHubSignInLink();
        }
        
    }
}
