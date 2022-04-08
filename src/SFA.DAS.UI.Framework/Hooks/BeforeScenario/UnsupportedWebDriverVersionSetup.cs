using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class UnsupportedWebDriverVersionSetup : WebDriverSetupBase
    {
        private static string _browser;

        public UnsupportedWebDriverVersionSetup(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 5)]
        public void SetupUnsupportedWebDriver()
        {
            _browser = objectContext.GetBrowser();

            if (!_browser.IsCloudExecution() && frameworkConfig.IsVstsExecution)
            {
                if (IsUnsupportedChromeDriverVersion()) { SetChromeDriverLocation(true); RestartWebDriver(); }
                else if (IsUnsupportedFirefoxDriverVersion()) { SetFireFoxDriverLocation(true); RestartWebDriver(); }
                else if (IsUnsupportedIeDriverVersion()) { SetIeDriverLocation(true); RestartWebDriver(); }
                else if (IsUnsupportedEdgeDriverVersion()) { SetEdgeDriverLocation(true); RestartWebDriver(); }
            }
        }

        private bool IsUnsupportedChromeDriverVersion() => _browser.IsChrome() && objectContext.GetChromedriverVersion().StartsWith("100.0");

        private bool IsUnsupportedFirefoxDriverVersion() => _browser.IsFirefox() && false;

        private bool IsUnsupportedIeDriverVersion() => _browser.IsIe() && false;

        private bool IsUnsupportedEdgeDriverVersion() => _browser.IsEdge() && false;

        private void RestartWebDriver() => new RestartWebDriverHelper(context).RestartWebDriver();
    }
}