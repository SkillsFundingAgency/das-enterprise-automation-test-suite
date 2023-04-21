using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

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
    public void SetUpRoatpConfigConfiguration() => _context.SetRoatpConfig(_configSection.GetConfigSection<AANConfig>());
}
