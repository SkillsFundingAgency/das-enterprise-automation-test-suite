using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project;

[Binding]
public class DfeProviderConfigurationSetup
{
    private readonly ScenarioContext _context;

    public DfeProviderConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 1)]
    public void SetUpDfeProviderConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        var dfeProviderList = configSection.GetConfigSection<List<DfeProvider>>("DfeProvidersConfig");

        var dfeframeworkList = new FrameworkList<DfeProvider>();

        dfeframeworkList.AddRange(dfeProviderList);

        _context.Set(dfeframeworkList);
    }
}
