using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.DfeAdmin.Service.Project;

[Binding]
public class DfeAdminsConfigurationSetup(ScenarioContext context)
{
    private const string DfeAdminsConfig = "DfeAdminsConfig";

    [BeforeScenario(Order = 1)]
    public void SetUpDfeAdminsConfiguration() => new DfeSignConfigurationSetupHelper(context).SetUpDfeSignConfiguration<DfeAdminUsers>(DfeAdminsConfig);
}
