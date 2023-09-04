using Polly;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        
        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 40)]
        public void SetUpHelpers()
        {
            var dbConfig = _context.Get<DbConfig>();

            _context.Set(new EarningsSqlDbHelper(dbConfig));

            _context.Set(new ApprenticeshipsSqlDbHelper(dbConfig));

            _context.Get<ObjectContext>().SetTestDataList();
        }
    }
}
