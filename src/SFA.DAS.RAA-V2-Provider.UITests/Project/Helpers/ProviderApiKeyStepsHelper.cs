using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderApiKeyStepsHelper(ScenarioContext context) : ProviderBaseStepsHelper(context)
    {
        public KeyforApiPage RenewRecruitmentAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPILink());

        public KeyforApiPage RenewRecruitmentAPISandboxKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPISandBoxLink());

        public KeyforApiPage RenewDisplayAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewDisplayAPILink());

        public KeyforApiPage DoesNotRenewDisplayAPIKey() => NavigateToAPIListPage().ClickViewDisplayAPILink().ClickRenewKeyLink().DoNotRenewApiKey();

        private static KeyforApiPage RenewAPIKey(KeyforApiPage page) => page.ClickRenewKeyLink().RenewAPIKey().VerifyApikeyRenewed();

        private ApiListPage NavigateToAPIListPage() => GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickAPIKeysHereLink();
    }
}
