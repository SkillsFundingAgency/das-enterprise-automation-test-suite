using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project
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
            _context.Set(new AssessorCertificationSqlDbHelper(_dbConfig));

            _context.SetRestClient(new Outer_AssessorCertificationApiRestClient(_context.GetOuter_ApiAuthTokenConfig()));
        }
    }
}
