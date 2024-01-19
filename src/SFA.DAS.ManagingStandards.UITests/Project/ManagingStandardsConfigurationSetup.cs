using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service;

namespace SFA.DAS.ManagingStandards.UITests.Project;

[Binding]
public class ManagingStandardsConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpManagingStandardsProjectConfiguration() => context.SetNonEasLoginUser(SetDfeAdminCredsHelper.SetDfeAdminCreds(context.Get<FrameworkList<DfeAdminUsers>>(), new AsAdminUser()));
}