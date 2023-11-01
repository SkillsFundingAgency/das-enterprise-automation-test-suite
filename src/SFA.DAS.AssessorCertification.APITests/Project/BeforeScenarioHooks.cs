using Polly;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.AssessorCertification.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
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
            var objectContext = _context.Get<ObjectContext>();

            _context.Set(new AssessorCertificationSqlDbHelper(objectContext, _dbConfig));

            _context.SetRestClient(new Outer_AssessorCertificationApiRestClient(objectContext, _context.GetOuter_ApiAuthTokenConfig()));
        }
    }
}
