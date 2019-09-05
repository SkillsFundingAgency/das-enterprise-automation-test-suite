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
            var webDriver = _context.GetWebDriver();
            var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, _config.TimeOutConfig);
            var retryHelper = new RetryHelper(webDriver);
            _context.Set(new SqlDatabaseConncetionHelper());
            _context.Set(new PageInteractionHelper(webDriver, webDriverwaitHelper, retryHelper));
            var formCompletionHelper = new FormCompletionHelper(webDriver, webDriverwaitHelper, retryHelper);
            _context.Set(formCompletionHelper);
            _context.Set(new TableRowHelper(webDriver, formCompletionHelper));
            _context.Set(new JavaScriptHelper(webDriver));
            _context.Set(new RandomDataGenerator());
            _context.Set(new RegexHelper());
            _context.Set(new AssertHelper());
            _context.Set(new ScreenShotTitleGenerator(0));
        }
    }
}
