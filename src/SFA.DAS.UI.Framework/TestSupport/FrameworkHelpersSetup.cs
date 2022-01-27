using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class FrameworkHelpersSetup
    {
        private readonly ScenarioContext _context;
        
        public FrameworkHelpersSetup(ScenarioContext context) => _context = context;

        public void SetupUIFrameworkHelpers()
        {
            var webDriver = _context.GetWebDriver();

            var iFrameHelper = new IFrameHelper(webDriver);
            _context.Replace(iFrameHelper);

            var javaScriptHelper = new JavaScriptHelper(webDriver, iFrameHelper);
            _context.Replace(javaScriptHelper);

            _context.Replace(new TabHelper(webDriver));

            var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, javaScriptHelper, _context.Get<FrameworkConfig>().TimeOutConfig);

            var retryHelper = new RetryHelper(webDriver, _context.ScenarioInfo);

            var pageInteractionHelper = new PageInteractionHelper(webDriver, webDriverwaitHelper, retryHelper);
            _context.Replace(pageInteractionHelper);

            var formCompletionHelper = new FormCompletionHelper(webDriver, webDriverwaitHelper, retryHelper);
            _context.Replace(formCompletionHelper);

            _context.Replace(new TableRowHelper(pageInteractionHelper, formCompletionHelper));

            _context.Replace(new RetryAssertHelper(_context.ScenarioInfo));

            _context.Replace(new ScreenShotTitleGenerator(0));
        }
    }
}
