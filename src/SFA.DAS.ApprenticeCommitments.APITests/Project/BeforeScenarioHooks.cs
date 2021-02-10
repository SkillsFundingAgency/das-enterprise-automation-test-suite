using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
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

            var restClient = new ApprenticeCommitmentsRestClient(_context.Get<OuterApiAuthTokenConfig>().ApprenticeCommitmentsApiKey);

            _context.SetRestClient(restClient);

            var mIrestClient = new AuthTokenApiRestClient(_context.Get<CommitmentsApiAuthTokenConfig>());

            _context.SetRestClient(mIrestClient);
        }
    }
}