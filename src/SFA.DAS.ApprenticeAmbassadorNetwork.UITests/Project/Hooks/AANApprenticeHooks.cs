namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aanaprentice")]
public class AANApprenticeHooks(ScenarioContext context) : AANBaseHooks(context)
{
    [BeforeScenario(Order = 31)]
    public void Navigate_Apprentice() => tabHelper.GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);
}
