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
            {
                BaseUrl = Configurator.GetBaseUrl(),
                Browser = Configurator.GetBrowser(),
                BrowserStackSetting = Configurator.GetBrowserStackSetting()
            };
            _context.Set(configuration);
        }
    }
}