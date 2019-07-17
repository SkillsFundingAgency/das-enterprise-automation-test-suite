using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport.BeforeScenario
{
    [Binding]
    public class HelpersSetup
    {
        private readonly ScenarioContext _context;

        public HelpersSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 12)]
        public void SetUpHelpers()
        {
            var WebDriver = _context.Get<IWebDriver>("webdriver");
            _context.Set(new PageInteractionHelper(WebDriver));
            _context.Set(new FormCompletionHelper(WebDriver));
        }
    }
}
