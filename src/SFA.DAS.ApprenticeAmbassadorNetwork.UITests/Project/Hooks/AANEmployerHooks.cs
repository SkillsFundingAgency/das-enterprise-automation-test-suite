namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aanemployer")]
public class AANEmployerHooks(ScenarioContext context) : AANBaseHooks(context)
{
    [BeforeScenario(Order = 31)]
    public void Navigate_Employer() => tabHelper.GoToUrl(UrlConfig.AAN_Employer_BaseUrl);
}
