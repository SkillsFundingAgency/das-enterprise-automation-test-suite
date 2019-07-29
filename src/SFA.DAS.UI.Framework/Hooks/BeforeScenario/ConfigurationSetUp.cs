using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
        }
        
        [BeforeScenario(Order = 10)]
        public void SetUpConfiguration()
        {
            var configuration = new FrameworkConfig
            {
                BaseUrl = Configurator.GetBaseUrl(),
                Browser = Configurator.GetBrowser(),
                TimeOutSetting = Configurator.GetTimeOut(),
                BrowserStackSetting = Configurator.GetBrowserStackSetting()
            };

            _context.Set(configuration);

            _context.SetConfigurationRoot(Configurator.config);
        }
    }
}