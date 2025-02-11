using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;

[Binding]
public class AANConfigurationSetup(ScenarioContext context)
{
    [BeforeScenario(Order = 2)]
    public void SetUpAANConfigConfiguration()
    {
        var configSection = context.Get<ConfigSection>();

        context.SetEasLoginUser(
        [
            configSection.GetConfigSection<AanEmployerUser>(),
            configSection.GetConfigSection<AanEmployerOnBoardedUser>()
        ]);

        var dfeAdminUsers = context.Get<FrameworkList<DfeAdminUsers>>();

        context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AanAdminUser()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AanSuperAdminUser())
        });

        context.SetApprenticeAccountsPortalUser(
        [
           configSection.GetConfigSection<AanApprenticeUser>(),
           configSection.GetConfigSection<AanApprenticeNonBetaUser>(),
           configSection.GetConfigSection<AanApprenticeOnBoardedUser>(),
        ]);
    }
}