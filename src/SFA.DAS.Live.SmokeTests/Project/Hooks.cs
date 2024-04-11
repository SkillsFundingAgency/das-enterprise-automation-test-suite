namespace SFA.DAS.Live.SmokeTests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    [BeforeScenario(Order = 30)]
    public void Navigate()
    {
        context.Get<TabHelper>().GoToUrl(UrlConfig.Live_Employer_BaseUrl);
    }
}