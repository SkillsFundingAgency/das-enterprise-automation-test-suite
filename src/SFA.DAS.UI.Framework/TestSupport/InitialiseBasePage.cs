using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public abstract class InitialiseBasePage(ScenarioContext context)
{
    #region Helpers and Context
    protected readonly ScenarioContext context = context;
    protected readonly string[] tags = context.ScenarioInfo.Tags;
    protected readonly ObjectContext objectContext = context.Get<ObjectContext>();
    protected readonly PageInteractionHelper pageInteractionHelper = context.Get<PageInteractionHelper>();
    protected readonly FormCompletionHelper formCompletionHelper = context.Get<FormCompletionHelper>();
    protected readonly IFrameHelper frameHelper = context.Get<IFrameHelper>();
    protected readonly JavaScriptHelper javaScriptHelper = context.Get<JavaScriptHelper>();
    protected readonly TabHelper tabHelper = context.Get<TabHelper>();
    protected readonly TableRowHelper tableRowHelper = context.Get<TableRowHelper>();
    protected readonly FrameworkConfig frameworkConfig = context.Get<FrameworkConfig>();

    #endregion

}