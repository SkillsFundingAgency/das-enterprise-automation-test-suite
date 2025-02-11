namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aanemployer")]
public class AANEmployerHooks(ScenarioContext context) : AANBaseHooks(context)
{
    [BeforeScenario(Order = 31)]
    public void Navigate_Employer() => tabHelper.GoToUrl(UrlConfig.AAN_Employer_BaseUrl);

    [AfterScenario(Order = 34), Scope(Tag = "@aanemployer03b")]
    public void DeleteLocationFilterEvents()
    {
        context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
        {
            context.Get<AANSqlHelper>().DeleteLocationFilterEventsBeginning("Location Filter Employer Test");
        });
    }
}
