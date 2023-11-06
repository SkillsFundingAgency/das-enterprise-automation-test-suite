using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.SupportTools.UITests.Project;

[Binding]
public class SupportToolsConfigurationSetup
{
    private readonly ScenarioContext _context;

    public SupportToolsConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpSupportConsoleProjectConfiguration()
    {
        var dfeAdminUsers = _context.Get<FrameworkList<DfeAdminUsers>>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new SupportToolScsUser()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new SupportToolScpUser())
        });
    }
}