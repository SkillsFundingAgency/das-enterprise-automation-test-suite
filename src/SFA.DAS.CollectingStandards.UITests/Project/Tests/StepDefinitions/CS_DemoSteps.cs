using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;

namespace SFA.DAS.CollectingStandards.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CS_DemoSteps
    {
        private readonly ScenarioContext _context;

        public CS_DemoSteps(ScenarioContext context) => _context = context;
    
        [Given(@"the provider logs in")]
        public void GivenTheProviderLandOnProviderPortalPage() => new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(false);
    }
}
