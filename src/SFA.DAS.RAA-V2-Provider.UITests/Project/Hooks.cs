using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;

        public Hooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 35)]
        public void SetUpHelpers()
        {
            _context.Set(new ProviderCreateVacancySqlDbHelper(_context.Get<DbConfig>()));
            _context.Set(new RAAV2ProviderPermissionsSqlDbHelper(_context.Get<DbConfig>()));
        }
    }
}
