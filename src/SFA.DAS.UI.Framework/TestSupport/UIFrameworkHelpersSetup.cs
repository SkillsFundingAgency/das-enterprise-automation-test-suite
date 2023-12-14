using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public class UIFrameworkHelpersSetup
{
    private readonly ScenarioContext _context;

    private readonly ObjectContext objectContext;


    public UIFrameworkHelpersSetup(ScenarioContext context)
    {
        _context = context;

        objectContext = context.Get<ObjectContext>();
    }

    public void SetupUIFrameworkHelpers(bool restart)
    {
        SetupUIFrameworkHelpers();

        _context.Replace(new ScreenShotTitleGenerator(restart ? _context.Get<ScreenShotTitleGenerator>().GetCounter() : 0));
    }

    private void SetupUIFrameworkHelpers()
    {
        var webDriver = _context.GetWebDriver();

        var scenarioInfo = _context.ScenarioInfo;

        var iFrameHelper = new IFrameHelper(webDriver);
        _context.Replace(iFrameHelper);

        _context.Replace(new JavaScriptHelper(webDriver, iFrameHelper));

        _context.Replace(new TabHelper(webDriver, objectContext));

        var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, _context.Get<FrameworkConfig>().TimeOutConfig);

        var retryHelper = new RetryHelper(webDriver, scenarioInfo, objectContext);

        var pageInteractionHelper = new PageInteractionHelper(webDriver, objectContext, webDriverwaitHelper, retryHelper);
        _context.Replace(pageInteractionHelper);

        var formCompletionHelper = new FormCompletionHelper(webDriver, objectContext, webDriverwaitHelper, retryHelper);
        _context.Replace(formCompletionHelper);

        _context.Replace(new CheckPageInteractionHelper(webDriver, objectContext, webDriverwaitHelper, new CheckPageRetryHelper(webDriver, scenarioInfo, objectContext)));

        _context.Replace(new TableRowHelper(pageInteractionHelper, formCompletionHelper));

        _context.Replace(new RetryAssertHelper(_context.ScenarioInfo, objectContext));
    }
}
