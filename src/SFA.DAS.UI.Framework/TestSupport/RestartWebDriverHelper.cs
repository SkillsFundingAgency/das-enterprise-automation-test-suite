using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport;

public class RestartWebDriverHelper(ScenarioContext context)
{
    private readonly BrowserStackTearDownHelper _browserStackTearDownHelper = new(context);
    private readonly DisposeWebDriverTeardownHelper _disposeWebDriverTeardownHelper = new(context);
    private readonly WebDriverSetupHelper _webDriverSetupHelper = new(context);
    private readonly UIFrameworkHelpersSetup _frameworkHelpersSetup = new(context);
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    public void RestartWebDriver(string url, string applicationName)
    {
        _browserStackTearDownHelper.MarkTestStatus();

        _browserStackTearDownHelper.UpdateTestName(_objectContext.GetCurrentApplicationName());

        var webDriver = RestartWebDriver();

        webDriver.Navigate().GoToUrl(url);

        _objectContext.SetDebugInformation($"Restarted WebDriver and Navigated to {url}");

        _objectContext.SetCurrentApplicationName(applicationName);
    }

    public IWebDriver RestartWebDriver()
    {
        _disposeWebDriverTeardownHelper.DisposeWebDriver();

        var webdriver = _webDriverSetupHelper.SetupWebDriver();

        _frameworkHelpersSetup.SetupUIFrameworkHelpers(true);

        return webdriver;
    }
}
