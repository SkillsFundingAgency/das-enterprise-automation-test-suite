namespace SFA.DAS.EsfaAdmin.Service.Project;

[Binding]
public class EsfaAdminLaunchApplicationHooks
{
    private readonly string[] _tags;

    private readonly TabHelper _tabHelper;

    public EsfaAdminLaunchApplicationHooks(ScenarioContext context)
    {
        _tags = context.ScenarioInfo.Tags;

        _tabHelper = context.Get<TabHelper>();
    }

    [BeforeScenario(Order = 40)]
    public void EsfaAdminLaunchApplication()
    {
        if (_tags.Any(x => x == "esfaadmin" || x == "oldroatpadmin" || x == "newroatpadmin" || x == "roatpfulle2eviaadmin")) _tabHelper.GoToUrl(UrlConfig.Admin_BaseUrl);
    }
}
