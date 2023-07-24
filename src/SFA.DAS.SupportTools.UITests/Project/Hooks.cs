namespace SFA.DAS.SupportConsole.UITests.Project;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _context;

    public Hooks(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 22)]
    public void Navigate() => _context.Get<TabHelper>().GoToUrl(UrlConfig.SupportTools_BaseUrl);

}