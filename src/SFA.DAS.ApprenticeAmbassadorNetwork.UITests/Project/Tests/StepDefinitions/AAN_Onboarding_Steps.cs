using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AAN_Onboarding_Steps
    {
        private ScenarioContext _context;
        private SignInPage _signInPage;
        private readonly AANConfig _config;

        public AAN_Onboarding_Steps(ScenarioContext context)
        {
            _context = context;
            _signInPage = new SignInPage(context);
            _config = context.GetAANConfig<AANConfig>();
        }

        [Given(@"the provider logs into AAN portal")]
        public void GivenTheProviderLogsIntoAANPortal()
        {
            _context.Get<TabHelper>().GoToUrl(UrlConfig.AAN_BaseUrl);
            _signInPage.SubmitValidUserDetails(_config.AANUserName,_config.AANPassword);

        }
    }
}
