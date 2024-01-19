using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario;

[Binding]
public class UnsupportedWebDriverVersionSetup(ScenarioContext context) : WebDriverSetupBase(context)
{
    private static string _browser;

    [BeforeScenario(Order = 5)]
    public void SetupUnsupportedWebDriver()
    {
        _browser = objectContext.GetBrowser();

        if (!_browser.IsCloudExecution() && frameworkConfig.IsVstsExecution)
        {
            if (IsUnsupportedChromeDriverVersion()) { SetChromeDriverLocation(true); RestartWebDriver(); }
            else if (IsUnsupportedFirefoxDriverVersion()) { SetFireFoxDriverLocation(true); RestartWebDriver(); }
            else if (IsUnsupportedEdgeDriverVersion()) { SetEdgeDriverLocation(true); RestartWebDriver(); }
        }
    }

    private static bool IsUnsupportedChromeDriverVersion() => _browser.IsChrome() && false; //objectContext.GetChromedriverVersion().StartsWith("100.0"); A temp fix whenever we have chromedriver issue.

    private static bool IsUnsupportedFirefoxDriverVersion() => _browser.IsFirefox() && false;

    private static bool IsUnsupportedEdgeDriverVersion() => _browser.IsEdge() && false;

    private void RestartWebDriver() => new RestartWebDriverHelper(context).RestartWebDriver();
}