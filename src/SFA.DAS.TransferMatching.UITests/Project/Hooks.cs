using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;
        private readonly TryCatchExceptionHelper _tryCatch;
        private TransferMatchingSqlDataHelper _transferMatchingSqlDataHelper;
        private CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            _context.Set(new TMDataHelper());

            _transferMatchingSqlDataHelper = new TransferMatchingSqlDataHelper(_dbConfig);

            _context.Set(_transferMatchingSqlDataHelper);

            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(_dbConfig);

            _context.Set(_commitmentsSqlDataHelper);

            _objectContext.SetPledgeDetailList();
        }

        [AfterScenario(Order = 31)]
        public void DeletePledge() 
        {
            if (_context.TestError == null) _tryCatch.AfterScenarioException(() => _transferMatchingSqlDataHelper.DeletePledge(_objectContext.GetPledgeDetailList()));
        }
    }
}
