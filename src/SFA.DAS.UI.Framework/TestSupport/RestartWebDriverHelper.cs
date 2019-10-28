using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class RestartWebDriverHelper
    {
        private readonly BrowserStackTearDownHelper _browserStackTearDownHelper;
        private readonly DisposeWebDriverTeardownHelper _disposeWebDriverTeardownHelper;
        private readonly WebDriverSetupHelper _webDriverSetupHelper;
        private readonly FrameworkHelpersSetup _frameworkHelpersSetup;
        private readonly ObjectContext _objectContext;

        public RestartWebDriverHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _browserStackTearDownHelper = new BrowserStackTearDownHelper(context);
            _disposeWebDriverTeardownHelper = new DisposeWebDriverTeardownHelper(context);
            _webDriverSetupHelper = new WebDriverSetupHelper(context);
            _frameworkHelpersSetup = new FrameworkHelpersSetup(context);
        }

        public void RestartWebDriver(string url, string applicationName)
        {
            _browserStackTearDownHelper.InformBrowserStackOnFailure();

            _browserStackTearDownHelper.UpdateTestName(_objectContext.GetCurrentApplicationName());

            _disposeWebDriverTeardownHelper.DisposeWebDriver();

            var webDriver = _webDriverSetupHelper.SetupWebDriver();

            webDriver.Navigate().GoToUrl(url);

            _objectContext.SetCurrentApplicationName(applicationName);

            _frameworkHelpersSetup.SetupFrameworkHelpers();
        }
    }

}
