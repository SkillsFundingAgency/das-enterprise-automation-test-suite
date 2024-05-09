namespace SFA.DAS.Live.SmokeTests.Project;

[Binding]
public class SmokeTestsConfigurationSetup(ScenarioContext context)
{
    private readonly ConfigSection _configSection = context.Get<ConfigSection>();

    [BeforeScenario(Order = 2)]
    public void SetUpRegistrationConfigConfiguration()
    {
        context.Set(_configSection.GetConfigSection<LiveEasUser>());

        context.Set(_configSection.GetConfigSection<MailasourDeviceConfig>());
    }
}