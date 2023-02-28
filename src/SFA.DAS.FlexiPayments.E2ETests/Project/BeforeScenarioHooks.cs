using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project
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


        [BeforeScenario(Order = 40)]
        public void SetUpHelpers()
        {
            _context.Set(new EarningsSqlDbHelper(_dbConfig));
            _context.Set(new ApprenticeshipsSqlDbHelper(_dbConfig));
        }
    }
}
