using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project;

[Binding]
public class ProviderConfigurationSetup
{
    private readonly ScenarioContext _context;

    public ProviderConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 1)]
    public void SetUpDfeProviderConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        var dfeProviderList = configSection.GetConfigSection<List<DfeProvider>>("DfeProvidersConfig");

        _context.Set(dfeProviderList);
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        var providerConfig = SetProviderCredsHelper.SetProviderCreds(_context.Get<List<DfeProvider>>(), configSection.GetConfigSection<ProviderConfig>());

        _context.SetProviderConfig(providerConfig);

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderViewOnlyUser>());

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorUser>());

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorWithApprovalUser>());

        var providerAccountOwnerUser = SetProviderCredsHelper.SetProviderCreds(_context.Get<List<DfeProvider>>(), configSection.GetConfigSection<ProviderAccountOwnerUser>());

        _context.SetNonEasLoginUser(providerAccountOwnerUser);
    }
}
