namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Hooks;

[Binding, Scope(Tag = "@aanaprentice")]
public class AANApprenticeHooks(ScenarioContext context) : AANBaseHooks(context)
{
    [BeforeScenario(Order = 31)]
    public void Navigate_Apprentice() => tabHelper.GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);

    [AfterScenario(Order = 34), Scope(Tag = "@aanapprentice04b")]
    public void DeleteLocationFilterEvents()
    {
        context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
        {
            context.Get<AANSqlHelper>().DeleteLocationFilterEventsBeginning("Location Filter Apprentice Test");
        });
    }
}

