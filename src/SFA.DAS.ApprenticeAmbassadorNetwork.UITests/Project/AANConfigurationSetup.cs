using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;

[Binding]
public class AANConfigurationSetup
{
    private readonly ScenarioContext _context;

    public AANConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpAANConfigConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        _context.SetEasLoginUser(new List<EasAccountUser>
        {
            configSection.GetConfigSection<AanEmployerUser>(),
            configSection.GetConfigSection<AanEmployerOnBoardedUser>()
        });

        var dfeAdminUsers = _context.Get<FrameworkList<DfeAdminUsers>>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<AanApprenticeUser>(),
            configSection.GetConfigSection<AanApprenticeNonBetaUser>(),
            configSection.GetConfigSection<AanApprenticeOnBoardedUser>(),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AanAdminUser()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AanSuperAdminUser())
        });
    }
}