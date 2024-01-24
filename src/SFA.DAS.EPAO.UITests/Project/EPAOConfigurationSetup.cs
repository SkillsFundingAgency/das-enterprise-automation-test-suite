using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.EPAO.UITests.Project;

[Binding]
public class EPAOConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpEPAOProjectConfiguration()
    {
        var configSection = context.Get<ConfigSection>();

        context.SetEPAOAssessorPortalUser(
        [
            configSection.GetConfigSection<EPAOStandardApplyUser>(),
            configSection.GetConfigSection<EPAOAssessorUser>(),
            configSection.GetConfigSection<EPAODeleteAssessorUser>(),
            configSection.GetConfigSection<EPAOManageUser>(),
            configSection.GetConfigSection<EPAOApplyUser>(),
            configSection.GetConfigSection<EPAOE2EApplyUser>(),
            configSection.GetConfigSection<EPAOWithdrawalUser>(),
            configSection.GetConfigSection<EPAOStageTwoStandardCancelUser>(),
        ]);

        context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(context.Get<FrameworkList<DfeAdminUsers>>(), new AsAdminUser())
        });
    }
}