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
        _configSection  = _context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration()
    {
        _context.SetProviderConfig(SetProviderCreds<ProviderConfig>());

        _context.SetProviderPermissionConfig(SetProviderCreds<ProviderPermissionsConfig>());

        _context.SetChangeOfPartyConfig(SetProviderCreds<ChangeOfPartyConfig>());

        _context.SetPortableFlexiJobProviderConfig(SetProviderCreds<PortableFlexiJobProviderConfig>());

        _context.SetPerfTestProviderPermissionsConfig(_configSection.GetConfigSection<PerfTestProviderPermissionsConfig>());

        _context.SetNonEasLoginUser(SetProviderCreds<ProviderAccountOwnerUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderViewOnlyUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderContributorUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderContributorWithApprovalUser>());
    }

    private T SetProviderCreds<T>() where T : ProviderConfig => SetProviderCredsHelper.SetProviderCreds(_context.Get<FrameworkList<DfeProvider>>(), _configSection.GetConfigSection<T>());
}
