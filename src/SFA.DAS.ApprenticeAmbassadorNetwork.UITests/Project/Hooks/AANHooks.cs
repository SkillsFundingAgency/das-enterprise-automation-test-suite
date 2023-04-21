global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using TechTalk.SpecFlow;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;

namespace SFA.DAS.ManagingStandards.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "aan")]
    public class AANHooks
    {
        private readonly string[] _tags;
        private AANSqlDataHelper _aANSqlDataHelper;
        private AANDataHelpers _dataHelper;
        protected readonly DbConfig _dbConfig;
        private readonly ScenarioContext _context;
        private readonly AANConfig _config;

        public AANHooks(ScenarioContext context)
        {
            _tags = context.ScenarioInfo.Tags;
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _config = context.GetAANConfig<AANConfig>();
        }

        [BeforeScenario(Order = 31)]
        public void SetUpDataHelpers()
        {
            _context.Set(_aANSqlDataHelper = new AANSqlDataHelper(_dbConfig));
            _context.Set(_dataHelper = new AANDataHelpers());
        }

        //[BeforeScenario(Order = 32)]
        //public void SetApprovedByRegulatorToNull()
        //{
        //    if (_tags.Any(x => x == "aan")) _aANSqlDataHelper.ClearRegulation(_config.Ukprn, _dataHelper.StandardsTestData.LarsCode);
        //}
    }
}
