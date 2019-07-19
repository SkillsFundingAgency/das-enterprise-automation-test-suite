using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
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
            var WebDriver = _context.GetWebDriver();
            _context.Set(new PageInteractionHelper(WebDriver));
            _context.Set(new FormCompletionHelper(WebDriver));
        }
    }
}
