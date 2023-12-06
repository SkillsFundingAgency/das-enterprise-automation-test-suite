using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project;

[Binding]
public class EPAOConfigurationSetup
{
    private readonly ScenarioContext _context;
    public EPAOConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpEPAOProjectConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        _context.SetAssessorGovSignUser(new List<GovSignUser>
        {
            configSection.GetConfigSection<EPAOStandardApplyUser>(),
            configSection.GetConfigSection<EPAOAssessorUser>(),
            configSection.GetConfigSection<EPAODeleteAssessorUser>(),
            configSection.GetConfigSection<EPAOManageUser>(),
            configSection.GetConfigSection<EPAOApplyUser>(),
            configSection.GetConfigSection<EPAOE2EApplyUser>(),
            configSection.GetConfigSection<EPAOWithdrawalUser>(),
            configSection.GetConfigSection<EPAOStageTwoStandardCancelUser>(),
        });

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdminUsers>>(), new AsAdminUser())
        });
    }             
}