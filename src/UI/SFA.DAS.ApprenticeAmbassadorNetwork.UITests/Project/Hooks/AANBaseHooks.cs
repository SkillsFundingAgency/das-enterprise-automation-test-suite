namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

public abstract class AANBaseHooks
{
    protected readonly ScenarioContext context;
    protected readonly TabHelper tabHelper;

    public AANBaseHooks(ScenarioContext context)
    {
        this.context = context;
        tabHelper = this.context.Get<TabHelper>();
    }
}
