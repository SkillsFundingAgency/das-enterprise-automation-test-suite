using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project;

[Binding]
public class ProviderConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public ProviderConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration()
    {
        var configSection = _context.Get<IConfigSection>();

        _context.SetProviderConfig(SetProviderCreds<ProviderConfig>());

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderViewOnlyUser>());

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorUser>());

        _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorWithApprovalUser>());

        _context.SetNonEasLoginUser(SetProviderCreds<ProviderAccountOwnerUser>());
    }

    private T SetProviderCreds<T>() where T : ProviderConfig => SetProviderCredsHelper.SetProviderCreds(_context.Get<FrameworkList<DfeProvider>>(), _configSection.GetConfigSection<T>());
}
