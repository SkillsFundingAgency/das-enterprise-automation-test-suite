namespace SFA.DAS.RoatpAdmin.Service.Project;

[Binding]
public class RoatpAdminLaunchApplicationHooks(ScenarioContext context)
{
    private readonly string[] _tags = context.ScenarioInfo.Tags;

    private readonly TabHelper _tabHelper = context.Get<TabHelper>();

    [BeforeScenario(Order = 40)]
    public void RoatpAdminLaunchApplication()
    {
        if (_tags.Any(x => x == "oldroatpadmin" || x == "newroatpadmin" || x == "roatpfulle2eviaadmin")) _tabHelper.GoToUrl(UrlConfig.Admin_BaseUrl);
    }
}
