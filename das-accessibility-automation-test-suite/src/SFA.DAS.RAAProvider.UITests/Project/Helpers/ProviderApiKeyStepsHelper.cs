using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderApiKeyStepsHelper(ScenarioContext context) : ProviderBaseStepsHelper(context)
    {
        public KeyforApiPage RenewRecruitmentAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPILink());

        public KeyforApiPage RenewRecruitmentAPISandboxKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewRecruitmentAPISandBoxLink());

        public KeyforApiPage RenewDisplayAPIKey() => RenewAPIKey(NavigateToAPIListPage().ClickViewDisplayAPILink());

        public KeyforApiPage DoesNotRenewDisplayAPIKey() => NavigateToAPIListPage().ClickViewDisplayAPILink().ClickRenewKeyLink().DoNotRenewApiKey();

        public KeyforApiPage ViewRecruitmentApiKeyPage() => NavigateToAPIListPage().ClickViewRecruitmentAPILink();

        private static KeyforApiPage RenewAPIKey(KeyforApiPage page) => page.ClickRenewKeyLink().RenewAPIKey().VerifyApikeyRenewed();

        private ApiListPage NavigateToAPIListPage() => GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickAPIKeysHereLink();

        public DisplayAdvertAPIPage VerifyDisplayApiPage() =>
            GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickDeveloperGetStartedPageLink().ClickDisplayAdvertApiLink().VerifyEndpointTitles();

        public RecruitmentAPIPage VerifyRecruitmentApiPage() =>
            GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickDeveloperGetStartedPageLink().ClickRecruitmentApiLink().VerifyEndpointTitles();

        public DevHubSignInPage ClickDevHubSignInLink() =>
            GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickDeveloperGetStartedPageLink().ClickDevHubSignInLink().SignIn();

        public ApiListPage VerifyDisplayApiText() =>
            new ApiListPage(context).VerifyDisplayAdvertApiText();
    }
}
