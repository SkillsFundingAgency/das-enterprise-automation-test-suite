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
            if (IsUnsupportedChromeDriverVersion()) { DAS.FrameworkHelpers.FileHelper.GetAzureSrcFilesPath(); RestartWebDriver(); }
            else if (IsUnsupportedFirefoxDriverVersion()) { SetFireFoxDriverLocation(true); RestartWebDriver(); }
            else if (IsUnsupportedEdgeDriverVersion()) { SetEdgeDriverLocation(true); RestartWebDriver(); }
        }
    }
    
    //A temp fix whenever we have chromedriver issue. We had the same issue when chrome driver version was 100.0
    private bool IsUnsupportedChromeDriverVersion() => _browser.IsChrome() && objectContext.GetChromedriverVersion().StartsWith("124.0.6367.60"); 

    private static bool IsUnsupportedFirefoxDriverVersion() => _browser.IsFirefox() && false;

    private static bool IsUnsupportedEdgeDriverVersion() => _browser.IsEdge() && false;

    private void RestartWebDriver() => new RestartWebDriverHelper(context).RestartWebDriver();
}