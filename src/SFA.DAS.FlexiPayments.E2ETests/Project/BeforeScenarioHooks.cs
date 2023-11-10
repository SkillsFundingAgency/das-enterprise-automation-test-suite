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

            var objectContext = _context.Get<ObjectContext>();

            _context.Set(new EarningsSqlDbHelper(objectContext, dbConfig));

            _context.Set(new ApprenticeshipsSqlDbHelper(objectContext, dbConfig));

            objectContext.SetFlexiPaymentsTestDataList();
        }
    }
}
