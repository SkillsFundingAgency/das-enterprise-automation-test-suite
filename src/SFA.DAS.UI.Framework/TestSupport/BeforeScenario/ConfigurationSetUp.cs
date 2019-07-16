using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.BeforeScenario
{
    [Binding]
    public class ConfigurationSetUp
    {
        private readonly ScenarioContext _context;

        public ConfigurationSetUp(ScenarioContext context)
        {
            _context = context;
        }
        
        [BeforeScenario(Order = 10)]
        public void SetUpConfiguration()
        {
            var configuration = new JsonConfig
            { BaseUrl = Configurator.GetBaseUrl(), Browser = Configurator.GetBrowser(),
                BrowserstackServerName = Configurator.GetBrowserstackServerName(),
                BrowserstackUsername = Configurator.GetBrowserstackUsername(),
                BrowserstackPassword = Configurator.GetBrowserstackPassword(),
                BrowserstackBrowser = Configurator.GetBrowserstackBrowser(),
                BrowserstackOs = Configurator.GetBrowserstackOs(),
                BrowserstackBrowserVersion = Configurator.GetBrowserstackbrowserVersion(),
                BrowserstackOsversion = Configurator.GetBrowserstackOsversion(),
                Resolution = Configurator.GetResolution()
            };
            _context.Set(configuration);
        }
    }
}