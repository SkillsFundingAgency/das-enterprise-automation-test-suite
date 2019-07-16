using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.AfterScenario
{
    [Binding]
    public class DisposeTearDown
    {
        private readonly ScenarioContext _context;

        public DisposeTearDown(ScenarioContext context)
        {
            _context = context;
        }

        [AfterScenario(Order = 12)]
        public void DisposeOnTestRun()
        {
            var WebDriver = _context.Get<IWebDriver>("webdriver");
            WebDriver?.Quit();
            WebDriver?.Dispose();
        }
    }
}
