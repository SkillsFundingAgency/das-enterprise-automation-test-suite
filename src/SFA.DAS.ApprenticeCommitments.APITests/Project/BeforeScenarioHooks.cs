using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
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
            _context.Set(new ApprenticeCommitmentSqlHelper(_dbConfig));

            _context.SetRestClient(new Outer_ApprenticeCommitmentsApiRestClient(_context.GetOuter_ApiAuthTokenConfig()));

            _context.SetRestClient(new Inner_CommitmentsApiRestClient(_context.GetInner_CommitmentsApiAuthTokenConfig()));
        }
    }
}