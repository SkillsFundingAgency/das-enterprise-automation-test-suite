using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var restClient = new ManageIdentityRestClient(_context.Get<DasCoursesApiMiConfig>());

            _context.SetRestClient(restClient);
        }
    }
}