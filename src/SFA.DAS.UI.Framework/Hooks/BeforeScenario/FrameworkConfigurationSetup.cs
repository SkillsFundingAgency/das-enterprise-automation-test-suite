using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class FrameworkConfigurationSetup
    {
        private readonly ScenarioContext _context;

        private readonly IConfigSection _configSection;

        private readonly ObjectContext _objectContext;

        public FrameworkConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _configSection = context.Get<IConfigSection>();
        }
        
        [BeforeScenario(Order = 2)]
        public void SetUpFrameworkConfiguration()
        {
            var configuration = new FrameworkConfig
            {
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                IsVstsExecution = Configurator.IsVstsExecution,
                DriverLocation = Configurator.DriverLocation
            };

            _context.Set(configuration);

            var executionConfig = new EnvironmentConfig { EnvironmentName = Configurator.EnvironmentName, ProjectName = Configurator.ProjectName };

            _context.Set(executionConfig);

            var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

            _objectContext.SetBrowser(testExecutionConfig.Browser);
        }
    }
}