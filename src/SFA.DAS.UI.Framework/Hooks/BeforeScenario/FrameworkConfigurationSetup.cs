using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;

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
            var testExecutionConfig = _configSection.GetConfigSection<TestExecutionConfig>();

            var captureUrlAdmin = testExecutionConfig.CaptureUrlAdmins.Split(",").ToList();

            var frameworkConfig = new FrameworkConfig
            {
                NServiceBusConfig = _configSection.GetConfigSection<NServiceBusConfig>(),
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                IsVstsExecution = Configurator.IsVstsExecution,
                CanCaptureUrl = captureUrlAdmin.Any(x => Configurator.GetDeploymentRequestedFor().ContainsCompareCaseInsensitive(x))
            };
            
            _context.Set(frameworkConfig);

            _objectContext.SetBrowser(testExecutionConfig.Browser);

            var driverLocationConfig = new DriverLocationConfig { ChromeWebDriver = Configurator.ChromeWebDriver, GeckoWebDriver = Configurator.GeckoWebDriver, IEWebDriver = Configurator.IEWebDriver };

            _context.Set(driverLocationConfig);
        }
    }
}