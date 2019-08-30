using OpenQA.Selenium.Remote;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;


        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 11)]

        public void TakeScreenshotOnFailure()
        {
            var scenarioTitle = _context.ScenarioInfo.Title;
            var options = _context.Get<FrameworkConfig>();
            var browser = _objectContext.GetBrowser();
            if (_context.TestError != null)
            {
                switch (true)
                {
                    case bool _ when browser.IsCloudExecution():
                        RemoteWebDriver remoteWebDriver = (RemoteWebDriver)_context.GetWebDriver();
                        BrowserStackTeardown.MarkTestAsFailed(remoteWebDriver, options.BrowserStackSetting, scenarioTitle, _context.TestError.Message);
                        break;
                    default:
                        var webDriver = _context.GetWebDriver();
                        ScreenshotHelper.TakeScreenShot(webDriver, scenarioTitle);
                        break;
                }
            }
        }
    }
}
