using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public class UIFrameworkHelpersSetup(ScenarioContext context)
{
    private readonly ObjectContext objectContext = context.Get<ObjectContext>();

    public void SetupUIFrameworkHelpers(bool restart)
    {
        SetupUIFrameworkHelpers();

        context.Replace(new ScreenShotTitleGenerator(restart ? context.Get<ScreenShotTitleGenerator>().GetCounter() : 0));
    }

    private void SetupUIFrameworkHelpers()
    {
        var webDriver = context.GetWebDriver();

        var scenarioInfo = context.ScenarioInfo;

        var iFrameHelper = new IFrameHelper(webDriver);
        context.Replace(iFrameHelper);

        context.Replace(new JavaScriptHelper(webDriver, iFrameHelper));

        context.Replace(new TabHelper(webDriver, objectContext));

        var webDriverwaitHelper = new WebDriverWaitHelper(webDriver, context.Get<FrameworkConfig>().TimeOutConfig);

        var retryHelper = new RetryHelper(webDriver, scenarioInfo, objectContext);

        var pageInteractionHelper = new PageInteractionHelper(webDriver, objectContext, webDriverwaitHelper, retryHelper);
        context.Replace(pageInteractionHelper);

        var formCompletionHelper = new FormCompletionHelper(webDriver, objectContext, webDriverwaitHelper, retryHelper);
        context.Replace(formCompletionHelper);

        context.Replace(new CheckPageInteractionHelper(webDriver, objectContext, webDriverwaitHelper, new CheckPageRetryHelper(webDriver, scenarioInfo, objectContext)));

        context.Replace(new TableRowHelper(pageInteractionHelper, formCompletionHelper));

        context.Replace(new RetryAssertHelper(context.ScenarioInfo, objectContext));
    }
}
