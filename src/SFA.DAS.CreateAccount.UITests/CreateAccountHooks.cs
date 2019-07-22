using OpenQA.Selenium;
using SFA.DAS.CreateAccount.UITests.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests
{
    [Binding]
    public class CreateAccountHooks
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;
        private readonly IWebDriver _webDriver;
        public CreateAccountHooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 20)]
        public void SetupCreateAccountConfiguration()
        {
            var config = _context.GetConfigSection<CreateAccountConfig>();
            _context.Set(new CreateAccountConfig { MACurrentUserName = config.MACurrentUserName, MACurrentUserPassword = config.MACurrentUserPassword });
        }


        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}
