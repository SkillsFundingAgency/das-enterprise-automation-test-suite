using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Hooks
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
            var employerFinanceSqlHelper = new EmployerFinanceSqlHelper(_dbConfig, _context);
            _context.Set(employerFinanceSqlHelper);

            _context.SetRestClient(new Inner_EmployerFinanceApiRestClient(_objectContext, _context.Get<Inner_ApiFrameworkConfig>()));
        }
    }
}