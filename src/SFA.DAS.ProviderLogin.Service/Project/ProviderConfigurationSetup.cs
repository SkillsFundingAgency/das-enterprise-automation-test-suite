using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
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
    private readonly string[] _tags;

    public ProviderConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _tags = context.ScenarioInfo.Tags;
        _configSection = _context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration()
    {
        SetProviderConfig();

        _context.SetProviderPermissionConfig(SetProviderCreds<ProviderPermissionsConfig>());

        _context.SetChangeOfPartyConfig(SetProviderCreds<ChangeOfPartyConfig>());

        _context.SetPortableFlexiJobProviderConfig(SetProviderCreds<PortableFlexiJobProviderConfig>());

        _context.SetPerfTestProviderPermissionsConfig(_configSection.GetConfigSection<PerfTestProviderPermissionsConfig>());

        _context.SetNonEasLoginUser(SetProviderCreds<ProviderAccountOwnerUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderViewOnlyUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderContributorUser>());

        _context.SetNonEasLoginUser(_configSection.GetConfigSection<ProviderContributorWithApprovalUser>());
    }

    private T SetProviderCreds<T>() where T : ProviderConfig => SetProviderCredsHelper.SetProviderCreds(_context.Get<FrameworkList<DfeProviderUsers>>(), _configSection.GetConfigSection<T>());

    private void SetProviderConfig()
    {
        var providerConfig = SetProviderCreds<ProviderConfig>();

        if (_tags.IsAddRplDetails()) providerConfig = SetProviderCreds<RplProviderConfig>();

        if (_tags.IsTestDataDeleteCohortViaProviderPortal()) _context.Set(SetProviderCreds<DeleteCohortProviderConfig>());

        _context.SetProviderConfig(providerConfig);
    }
}
