using Microsoft.Extensions.Configuration;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigurationRoot _configurationRoot;

        private readonly IConfigSection _configSection;

        private readonly ObjectContext _objectContext;
        public ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _configurationRoot = Configurator.GetConfig();
            _configSection = new ConfigSection(_configurationRoot);
        }
        
        [BeforeScenario(Order = 1)]
        public void SetUpConfiguration()
        {
            _context.Set(_configSection);

            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                TakeEveryPageScreenShot = Configurator.IsVstsExecution
            };

            _context.Set(configuration);

            var executionConfig = new EnvironmentConfig { EnvironmentName = Configurator.EnvironmentName, ProjectName = Configurator.ProjectName };

            _context.Set(executionConfig);

            var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

            _objectContext.SetBrowser(testExecutionConfig.Browser);
        }
    }
}