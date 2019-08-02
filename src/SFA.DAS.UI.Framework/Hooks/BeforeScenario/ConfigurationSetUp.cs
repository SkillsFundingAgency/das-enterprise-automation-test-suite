using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigSection _configSection;

        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = new ConfigSection(Configurator.GetConfig());
        }
        
        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                HostingConfig = _configSection.GetConfigSection<HostingConfig>(),
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>()
            };

            _context.Set(configuration);
        }
    }
}