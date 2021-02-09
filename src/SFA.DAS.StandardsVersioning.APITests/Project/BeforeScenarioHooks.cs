using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var restClient = new ManageIdentityRestClient(_context.Get<DasCoursesApiMiConfig>());

            _context.SetRestClient(restClient);
        }
    }
}