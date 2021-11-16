using SFA.DAS.API.Framework;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA_V2.APITests.Project.Helpers.SqlDbHelpers;

namespace SFA.DAS.RAA_V2.APITests.Project
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
            _context.SetRestClient(new Outer_EmployerAccountLegalEntitiesApiClient(_context.GetOuter_ApiAuthTokenConfig()));

            _context.Set(new EmployerLegalEntitiesSqlDbHelper(_dbConfig));

        }
           
    }
}
