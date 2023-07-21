using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;

[Binding]
public class AANConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public AANConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpAANConfigConfiguration()
    {
        _context.SetNonEasLoginUser(_configSection.GetConfigSection<AanUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<AanNonBetaUser>());
    }
}
