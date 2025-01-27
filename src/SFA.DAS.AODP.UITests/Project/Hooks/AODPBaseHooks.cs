using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Hooks;

public abstract class AODPBaseHooks
{
    protected readonly ScenarioContext context;
    protected readonly TabHelper tabHelper;

    public AODPBaseHooks(ScenarioContext context)
    {
        this.context = context;
        tabHelper = this.context.Get<TabHelper>();
    }
}
