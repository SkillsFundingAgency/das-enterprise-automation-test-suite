using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

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

        var dfeAdminUsers = _context.Get<FrameworkList<DfeAdminUsers>>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new SupportConsoleTier1User()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new SupportConsoleTier2User())
        });
    }
}