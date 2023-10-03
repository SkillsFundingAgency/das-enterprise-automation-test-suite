using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project;

[Binding]
public class ProviderConfigurationSetup
{
    private readonly ScenarioContext _context;
    
    public ProviderConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration() => _context.SetProviderConfig(SetProviderCredsHelper.SetProviderCreds(_context.Get<FrameworkList<DfeProvider>>(), _context.Get<IConfigSection>().GetConfigSection<ProviderConfig>()));
}
