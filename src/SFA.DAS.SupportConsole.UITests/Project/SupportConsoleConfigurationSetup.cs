namespace SFA.DAS.SupportConsole.UITests.Project;

[Binding]
public class SupportConsoleConfigurationSetup
{
    private readonly ScenarioContext _context;

    public SupportConsoleConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpSupportConsoleProjectConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        _context.SetSupportConsoleConfig(configSection.GetConfigSection<SupportConsoleConfig>());

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<SupportConsoleTier1User>(),
            configSection.GetConfigSection<SupportConsoleTier2User>(),
        });
    }
}