using SFA.DAS.IdamsLogin.Service.Project;
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

        var aanAdminUser = SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdminUsers>>(), new AanAdminUser());

        _context.Get<ObjectContext>().SetDebugInformation($"{aanAdminUser}");

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<AanApprenticeUser>(),
            configSection.GetConfigSection<AanApprenticeNonBetaUser>(),
            configSection.GetConfigSection<AanApprenticeOnBoardedUser>(),
            aanAdminUser
        });

        _context.SetAanEsfaSuperAdminConfig(configSection.GetConfigSection<AanEsfaSuperAdminConfig>());
    }
}