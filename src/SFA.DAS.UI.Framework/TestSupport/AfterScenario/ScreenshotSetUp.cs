using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.AfterScenario
{
    [Binding]
    public class ScreenshotSetUp
    {
        private readonly ScenarioContext _context;

        public ScreenshotSetUp(ScenarioContext context)
        {
            _context = context;
        }

        [AfterScenario(Order = 11)]

        public void TakeScreenshotOnFailure()
        {
            var scenarioTitle = _context.ScenarioInfo.Title;
            var options = _context.Get<JsonConfig>();
            if (_context.TestError != null)
            {
                switch (true)
                {
                    case bool _ when options.Browser == "browserstack":
                        RemoteWebDriver remoteWebDriver = _context.Get<RemoteWebDriver>("webdriver");
                        BrowserStackTearDown.MarkTestAsFailed(remoteWebDriver, options, scenarioTitle, "Remote test failed");
                        break;
                    default:
                        var webDriver = _context.Get<IWebDriver>("webdriver");
                        ScreenshotHelper.TakeScreenShot(webDriver, scenarioTitle);
                        break;
                }
            }
        }
    }
}
