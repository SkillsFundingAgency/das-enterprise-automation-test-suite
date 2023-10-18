using System.Runtime.InteropServices;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.API.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;
        private readonly EmploymentCheckProcessConfig _config;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _config = context.GetEmploymentCheckPaymentProcessConfig<EmploymentCheckProcessConfig>();
        }
       

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var objectContext = _context.Get<ObjectContext>();

            _context.SetRestClient(new Outer_EmploymentCheckApiClient(objectContext, _context.GetOuter_ApiAuthTokenConfig()));

            _context.Set(new EmploymentCheckOrchestrationHelper(_config));
            _context.Set(new Helper(_context));
            _context.Set(new EmploymentChecksSqlDbHelper(objectContext, _dbConfig));
        }
           
    }
}