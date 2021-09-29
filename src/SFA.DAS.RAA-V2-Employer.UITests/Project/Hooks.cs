using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
        }

        [BeforeScenario(Order = 34)]
        public void SetUpHelpers()
        {
            _objectContext.SetRAAV2Employer();

            _context.Set(new ProviderPermissionsSqlDbHelper(_dbConfig));
        }
    }
}
