using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class ResetWebDriverSetup : WebDriverSetupBase
    {
        public ResetWebDriverSetup(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 5)]
        public void SetupWebDriver()
        {
            var browser = _objectContext.GetBrowser();
            
            if (!browser.IsCloudExecution() && _frameworkConfig.IsVstsExecution && IsUnsupportedChromeDriverVersion(_objectContext.GetChromedriverVersion()))
            {
                _objectContext.SetFireFoxDriverLocation(FindLocalDriverServiceLocation(FirefoxDriverServiceName));

                _objectContext.SetChromeDriverLocation(FindLocalDriverServiceLocation(ChromeDriverServiceName));

                _objectContext.SetIeDriverLocation(FindLocalDriverServiceLocation(InternetExplorerDriverServiceName));

                var webDriver = new RestartWebDriverHelper(_context).RestartWebDriver();

                AddCapabilities(webDriver);
            }
        }

        private bool IsUnsupportedChromeDriverVersion(string chromedriverVersion) => chromedriverVersion.StartsWith("87.0.4280.20");
    }
}
