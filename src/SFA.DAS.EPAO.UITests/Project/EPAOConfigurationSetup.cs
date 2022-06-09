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

        _context.SetNonEasLoginUser(new List<NonAccountUser>
        {
            configSection.GetConfigSection<EPAOStandardApplyUser>(),
            configSection.GetConfigSection<EPAOAssessorUser>(),
            configSection.GetConfigSection<EPAODeleteAssessorUser>(),
            configSection.GetConfigSection<EPAOManageUser>(),
            configSection.GetConfigSection<EPAOApplyUser>(),
            configSection.GetConfigSection<EPAOE2EApplyUser>(),
            configSection.GetConfigSection<EPAOWithdrawalUser>(),
            configSection.GetConfigSection<EPAOAdminUser>(),
            configSection.GetConfigSection<EPAOStageTwoStandardCancelUser>()
        });
    }             
}