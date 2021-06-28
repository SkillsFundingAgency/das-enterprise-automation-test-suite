using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class WebDriverSetup : WebDriverSetupBase
    {
        public WebDriverSetup(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 3)]
        public void SetupWebDriver()
        {
            objectContext.SetFireFoxDriverLocation(FindDriverServiceLocation(FirefoxDriverServiceName));
            
            objectContext.SetChromeDriverLocation(FindDriverServiceLocation(ChromeDriverServiceName));
            
            objectContext.SetIeDriverLocation(FindDriverServiceLocation(InternetExplorerDriverServiceName));

            var webDriver = webDriverSetupHelper.SetupWebDriver();

            if (!IsCloudExecution())
            {
                AddCapabilities(webDriver);
            }
        }
    }
}
