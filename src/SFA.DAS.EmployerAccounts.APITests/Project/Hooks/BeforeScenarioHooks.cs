using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
        }

        [BeforeScenario(Order = 45)]
        public void SetUpHelpers()
        {
            _context.Set(new EmployerAccountsSqlDbHelper(_dbConfig, _context.Get<ObjectContext>()));          

            _context.SetRestClient(new Inner_EmployerAccountsApiRestClient(_objectContext, _context.Get<Inner_ApiFrameworkConfig>()));

            _context.SetRestClient(new Inner_EmployerAccountsLegacyApiRestClient(_objectContext, _context.Get<Inner_ApiFrameworkConfig>()));
        }
    }
}
