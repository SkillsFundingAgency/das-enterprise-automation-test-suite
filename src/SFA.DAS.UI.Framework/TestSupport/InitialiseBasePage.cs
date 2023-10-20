using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class InitialiseBasePage
{
    #region Helpers and Context
    protected readonly ScenarioContext context;
    protected readonly string[] tags;
    protected readonly ObjectContext objectContext;
    protected readonly PageInteractionHelper pageInteractionHelper;
    protected readonly FormCompletionHelper formCompletionHelper;
    protected readonly IFrameHelper frameHelper;
    protected readonly JavaScriptHelper javaScriptHelper;
    protected readonly TabHelper tabHelper;
    protected readonly TableRowHelper tableRowHelper;
    protected readonly FrameworkConfig frameworkConfig;
    #endregion

    public InitialiseBasePage(ScenarioContext context)
    {
        this.context = context;
        objectContext = context.Get<ObjectContext>();
        tags = context.ScenarioInfo.Tags;
        frameworkConfig = context.Get<FrameworkConfig>();
        pageInteractionHelper = context.Get<PageInteractionHelper>();
        formCompletionHelper = context.Get<FormCompletionHelper>();
        frameHelper = context.Get<IFrameHelper>();
        javaScriptHelper = context.Get<JavaScriptHelper>();
        tabHelper = context.Get<TabHelper>();
        tableRowHelper = context.Get<TableRowHelper>();
    }

}