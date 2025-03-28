namespace SFA.DAS.SupportTools.UITests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    [BeforeScenario(Order = 22)]
    public void Navigate() => context.Get<TabHelper>().GoToUrl(UrlConfig.SupportTools_BaseUrl);

}