using SFA.DAS.EsfaAdmin.Service.Project;
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
            configSection.GetConfigSection<AanEWOUser>()
        });

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            configSection.GetConfigSection<AanUser>(),
            configSection.GetConfigSection<AanNonBetaUser>(),
        });

        _context.SetAanEsfaAdminConfig(configSection.GetConfigSection<AanEsfaAdminConfig>());

        _context.SetAanEsfaSuperAdminConfig(configSection.GetConfigSection<AanEsfaSuperAdminConfig>());
    }
}