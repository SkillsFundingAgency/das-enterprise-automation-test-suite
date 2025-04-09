namespace SFA.DAS.RAA.APITests.Project;

[Binding]
public class RaaApiFrameworkConfigurationSetup(ScenarioContext context)
{
    private readonly ConfigSection _configSection = context.Get<ConfigSection>();

    [BeforeScenario(Order = 12)]
    public void SetUpRaaApiFrameworkConfiguration()
    {
        context.Set(_configSection.GetConfigSection<Raa_Emp_Outer_ApiAuthTokenConfig>());
    }
}
