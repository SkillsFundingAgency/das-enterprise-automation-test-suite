using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderApiKeyStepsHelper : ProviderBaseStepsHelper
    {
        public ProviderApiKeyStepsHelper(ScenarioContext context) : base(context) { }

        public KeyforAPIPage RenewRecruitmentAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPILink());

        public KeyforAPIPage RenewRecruitmentAPISandboxKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPISandBoxLink());

        public KeyforAPIPage RenewDisplayAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewDisplayAPILink());

        public KeyforAPIPage DoesNotRenewDisplayAPIKey() => NavigateToAPIListPage().ClickViewDisplayAPILink().ClickRenewKeyLink().DoNotRenewApiKey();

        private KeyforAPIPage RenewAPIKey(KeyforAPIPage page) => page.ClickRenewKeyLink().RenewAPIKey().VerifyApikeyRenewed();

        private APIListPage NavigateToAPIListPage() => GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickAPIKeysHereLink();
    }
}
