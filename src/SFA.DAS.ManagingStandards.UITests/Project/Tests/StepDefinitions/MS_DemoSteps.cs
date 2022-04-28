using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;

namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MS_DemoSteps
    {
        private readonly ScenarioContext _context;

        public MS_DemoSteps(ScenarioContext context) => _context = context;
    
        [Given(@"the provider logs into employer portal")]
        public void GivenTheProviderLogsIntoEmployerPortal() => new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(false);
    }
}
