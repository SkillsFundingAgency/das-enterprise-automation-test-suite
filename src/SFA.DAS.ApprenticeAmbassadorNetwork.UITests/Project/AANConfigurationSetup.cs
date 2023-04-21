namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;

[Binding]
public class AANConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public AANConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpRoatpConfigConfiguration() => _context.SetAANConfig(_configSection.GetConfigSection<AANConfig>());
}
