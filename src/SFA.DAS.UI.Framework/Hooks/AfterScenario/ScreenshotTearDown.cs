using OpenQA.Selenium.Remote;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
        }

        [AfterScenario(Order = 11)]

        public void TakeScreenshotOnFailure()
        {
            var scenarioTitle = _context.ScenarioInfo.Title;
            var options = _context.Get<FrameworkConfig>();
            if (_context.TestError != null)
            {
                switch (true)
                {
                    case bool _ when options.Browser.IsCloudExecution():
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
