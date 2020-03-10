using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class FrameworkHelpersSetup
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkConfig _config;

        public FrameworkHelpersSetup(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<FrameworkConfig>();
        }

        public void SetupFrameworkHelpers()
        {
            var webDriver = _context.GetWebDriver();
            _context.Replace(new TabHelper(webDriver));
            var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, _config.TimeOutConfig);
            var retryHelper = new RetryHelper(webDriver, _context.ScenarioInfo.Title);
            _context.Replace(new PageInteractionHelper(webDriver, webDriverwaitHelper, retryHelper));
            var formCompletionHelper = new FormCompletionHelper(webDriver, webDriverwaitHelper, retryHelper);
            _context.Replace(formCompletionHelper);
            _context.Replace(new TableRowHelper(webDriver, formCompletionHelper));
            _context.Replace(new JavaScriptHelper(webDriver));
            _context.Replace(new RandomDataGenerator());
            _context.Replace(new RegexHelper());
            _context.Replace(new AssertHelper());
            _context.Replace(new ScreenShotTitleGenerator(0));
        }
    }
}
