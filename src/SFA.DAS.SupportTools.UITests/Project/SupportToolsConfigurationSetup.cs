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
        var configSection = _context.Get<IConfigSection>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<SupportToolsSCSUser>(),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdminUsers>>(), new SupportToolScpUser())
        });
    }
}