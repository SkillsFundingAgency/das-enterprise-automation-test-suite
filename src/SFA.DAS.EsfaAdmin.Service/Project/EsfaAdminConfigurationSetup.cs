using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project;

[Binding]
public class EsfaAdminConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public EsfaAdminConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpRoatpConfigConfiguration() => _context.SetEsfaAdminConfig(_configSection.GetConfigSection<EsfaAdminConfig>());
}
