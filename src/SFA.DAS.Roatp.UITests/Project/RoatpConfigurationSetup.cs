using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project;

[Binding]
public class RoatpConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public RoatpConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpRoatpConfigConfiguration() => _context.SetRoatpConfig(_configSection.GetConfigSection<RoatpConfig>());
}
