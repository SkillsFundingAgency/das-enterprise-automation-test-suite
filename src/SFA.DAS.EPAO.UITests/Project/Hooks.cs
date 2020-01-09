using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _config;
        private readonly IWebDriver _webDriver;
        private readonly SqlDatabaseConnectionHelper _sqlDatabaseConnectionHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetEPAOConfig<EPAOConfig>();
            _sqlDatabaseConnectionHelper = context.Get<SqlDatabaseConnectionHelper>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var ePAOSqlDataHelper = new EPAOSqlDataHelper(_config, _sqlDatabaseConnectionHelper);
            _context.Set(ePAOSqlDataHelper);
            var random = _context.Get<RandomDataGenerator>();
            _context.Set(new EPAODataHelper(random));
            _context.Set(new RandomElementHelper(random));
        }
    }
}
