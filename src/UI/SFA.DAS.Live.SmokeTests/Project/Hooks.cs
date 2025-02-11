namespace SFA.DAS.Live.SmokeTests.Project;

[Binding]
public class Hooks(ScenarioContext context)
{
    [BeforeScenario(Order = 30)]
    public void Navigate()
    {
        var easUrl = EnvironmentConfig.IsLiveEnvironment ? UrlConfig.Live_Employer_BaseUrl : UrlConfig.EmployerApprenticeshipService_BaseUrl;

        context.Get<TabHelper>().GoToUrl(easUrl);

        context.Get<ObjectContext>().SetOrganisationName(context.Get<LiveEasUser>().OrganisationName);
    }
}
