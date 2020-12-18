using SFA.DAS.UI.Framework.TestSupport;
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
            if (!IsCloudExecution() && frameworkConfig.IsVstsExecution && IsUnsupportedChromeDriverVersion(objectContext.GetChromedriverVersion()))
            {
                objectContext.SetFireFoxDriverLocation(FindLocalDriverServiceLocation(FirefoxDriverServiceName));

                objectContext.SetChromeDriverLocation(FindLocalDriverServiceLocation(ChromeDriverServiceName));

                objectContext.SetIeDriverLocation(FindLocalDriverServiceLocation(InternetExplorerDriverServiceName));

                var webDriver = new RestartWebDriverHelper(context).RestartWebDriver();

                AddCapabilities(webDriver);
            }
        }

        private bool IsUnsupportedChromeDriverVersion(string chromedriverVersion) => chromedriverVersion.StartsWith("87.0.4280.20");
    }
}
