using SFA.DAS.IdamsLogin.Service.Project;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
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

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<AanApprenticeUser>(),
            configSection.GetConfigSection<AanApprenticeNonBetaUser>(),
            configSection.GetConfigSection<AanApprenticeOnBoardedUser>(),
        });

        var aanAdmin = SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdmin>>(), new AanAdminConfig());

        _context.SetAanEsfaAdminConfig(aanAdmin);

        _context.SetAanEsfaSuperAdminConfig(configSection.GetConfigSection<AanEsfaSuperAdminConfig>());
    }

}