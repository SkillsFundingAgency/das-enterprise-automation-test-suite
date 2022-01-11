using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using SFA.DAS.FrameworkHelpers;

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

            var captureUrlAdmin = testExecutionConfig.CaptureUrlAdmins.ToList(",");

            var fullscreenshotAdmin = testExecutionConfig.FullScreenShotAdmins.ToList(",");

            bool.TryParse(testExecutionConfig.CanTakeFullScreenShot, out bool canTakeFullScreenShot);

            bool IsVstsExecution = Configurator.IsVstsExecution;

            var frameworkConfig = new FrameworkConfig
            {
                NServiceBusConfig = _configSection.GetConfigSection<NServiceBusConfig>(),
                TimeOutConfig = _configSection.GetConfigSection<TimeOutConfig>(),
                BrowserStackSetting = _configSection.GetConfigSection<BrowserStackSetting>(),
                IsVstsExecution = IsVstsExecution,
                CanCaptureUrl = IsCurrrentUserAnAdmin(captureUrlAdmin) && IsVstsExecution,
                CanTakeFullScreenShot = IsCurrrentUserAnAdmin(fullscreenshotAdmin) || canTakeFullScreenShot
            };

            _context.Set(frameworkConfig);

            _objectContext.SetBrowser(testExecutionConfig.Browser);

            var driverLocationConfig = new DriverLocationConfig { ChromeWebDriver = Configurator.ChromeWebDriver, GeckoWebDriver = Configurator.GeckoWebDriver, IEWebDriver = Configurator.IEWebDriver };

            _context.Set(driverLocationConfig);

            if (frameworkConfig.CanCaptureUrl) _objectContext.InitAuthUrl();
        }

          private bool IsCurrrentUserAnAdmin(List<string> admins) => admins.Any(x => Configurator.GetDeploymentRequestedFor().ContainsCompareCaseInsensitive(x));
    }
}