using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
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

            _objectContext.SetPledgeDetailList();
        }

        [AfterScenario(Order = 31)]
        public void DeletePledge() 
        {
            if (_context.TestError == null)
                _tryCatch.AfterScenarioException(() => _transferMatchingSqlDataHelper.DeletePledge(_objectContext.GetPledgeDetailList()));
        }
    }
}
