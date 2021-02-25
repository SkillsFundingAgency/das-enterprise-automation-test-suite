using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
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

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _objectContext.SetApprenticeEmail(new ApprenticeCommitmentsApiDataHelper().Email);

            _context.Set(new ApprenticeCommitmentSqlHelper(_dbConfig));

            _context.Set(new ApprenticeLoginSqlDbHelper(_dbConfig));

            _context.Set(new ApprenticeCommitmentsRegistrationSqlDbHelper(_dbConfig));

            _context.SetRestClient(new Inner_CommitmentsApiRestClient(_context.GetInner_CommitmentsApiAuthTokenConfig()));
        }
    }
}