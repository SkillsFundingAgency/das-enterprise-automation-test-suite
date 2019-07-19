using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class DisposeTeardown
    {
        private readonly ScenarioContext _context;

        public DisposeTeardown(ScenarioContext context)
        {
            _context = context;
        }

        [AfterScenario(Order = 12)]
        public void DisposeOnTestRun()
        {
            var WebDriver = _context.GetWebDriver();
            WebDriver?.Quit();
            WebDriver?.Dispose();
        }
    }
}
