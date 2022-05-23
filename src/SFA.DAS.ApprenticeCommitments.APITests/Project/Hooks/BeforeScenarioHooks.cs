using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Hooks
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
            var a = new ApprenticeCommitmentsDataHelper(_context.Get<ApprenticePPIDataHelper>());

            _context.Set(a);

            _objectContext.SetApprenticeDetail(a.ApprenticeFirstname, a.ApprenticeLastname, a.ApprenticeDob, a.ApprenticeEmail);

            _context.Set(new AccountsAndCommitmentsSqlHelper(_dbConfig));

            _context.Set(new ApprenticeLoginSqlDbHelper(_dbConfig));

            _context.Set(new ApprenticeCommitmentsSqlDbHelper(_dbConfig));

            _context.SetRestClient(new Inner_CommitmentsApiRestClient(_context.GetInner_CommitmentsApiAuthTokenConfig()));
        }
    }
}