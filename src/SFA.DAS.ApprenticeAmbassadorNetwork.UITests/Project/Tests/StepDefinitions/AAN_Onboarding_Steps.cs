using Polly;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AAN_Onboarding_Steps
    {
        private readonly ScenarioContext context;
        private readonly AANConfig config;

        public AAN_Onboarding_Steps(ScenarioContext context)
        {
            this.context = context;
            config = context.GetAANConfig<AANConfig>();
        }

        [Given(@"the provider logs into AAN portal")]
        public void GivenTheProviderLogsIntoAANPortal()
        {
            context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_BaseUrl);
            new SignInPage(context).SubmitValidUserDetails(config.AANUserName, config.AANPassword);
        }
    }
}
