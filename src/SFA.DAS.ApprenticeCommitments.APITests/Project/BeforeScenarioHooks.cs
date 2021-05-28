using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;
        private readonly string[] _tags;

        public BeforeScenarioHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
            _tags = context.ScenarioInfo.Tags;
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            var datahelper = new ApprenticeCommitmentsDataHelper(random, _tags.Contains("perftest"));

            _context.Set(datahelper);

            _objectContext.SetApprenticeEmail(datahelper.Email);

            _context.Set(new AccountsAndCommitmentsSqlHelper(_dbConfig));

            _context.Set(new ApprenticeLoginSqlDbHelper(_dbConfig));

            _context.Set(new ApprenticeCommitmentsSqlDbHelper(_dbConfig));

            _context.SetRestClient(new Inner_CommitmentsApiRestClient(_context.GetInner_CommitmentsApiAuthTokenConfig()));
        }
    }
}