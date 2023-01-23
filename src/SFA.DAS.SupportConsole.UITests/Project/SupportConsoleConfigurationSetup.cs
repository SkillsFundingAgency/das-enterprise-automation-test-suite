namespace SFA.DAS.SupportConsole.UITests.Project;

[Binding]
public class SupportConsoleConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public SupportConsoleConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpSupportConsoleProjectConfiguration()
    {
        _context.SetSupportConsoleConfig(_configSection.GetConfigSection<SupportConsoleConfig>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportConsoleTier1User>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportConsoleTier2User>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportToolsSCPUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportToolsSCSUser>());

    }
}