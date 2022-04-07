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
            SetFireFoxDriverLocation(false);
            
            SetChromeDriverLocation(false);
            
            SetIeDriverLocation(false);

            SetEdgeDriverLocation(false);

            webDriverSetupHelper.SetupWebDriver();
        }
    }
}
