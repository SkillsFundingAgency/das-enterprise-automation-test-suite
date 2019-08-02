using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class HelpersSetup
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;

        public HelpersSetup(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<FrameworkConfig>();
        }

        [BeforeScenario(Order = 4)]
        public void SetUpHelpers()
        {
            var WebDriver = _context.GetWebDriver();
            _context.Set(new PageInteractionHelper(WebDriver, _config.TimeOutConfig));
            _context.Set(new FormCompletionHelper(WebDriver));
            _context.Set(new JavaScriptHelper(WebDriver));
        }
    }
}
