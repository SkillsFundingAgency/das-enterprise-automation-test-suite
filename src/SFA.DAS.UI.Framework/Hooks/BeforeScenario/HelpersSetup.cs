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
            var webDriverwaitHelper = new WebDriverWaitHelper(WebDriver, _config.TimeOutConfig);
            var retryHelper = new RetryHelper();
            _context.Set(new PageInteractionHelper(WebDriver, webDriverwaitHelper, retryHelper));
            _context.Set(new FormCompletionHelper(WebDriver, webDriverwaitHelper));
            _context.Set(new JavaScriptHelper(WebDriver));
            _context.Set(new RandomDataGenerator());
            _context.Set(new RegexHelper());
        }
    }
}
