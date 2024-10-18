using Polly;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
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
    private readonly ConfigSection _configSection;
    private readonly string[] _tags;

    private FrameworkList<DfeProviderUsers> dfeframeworkList;

    private List<ProviderDetails> dfeProviderDetailsList;

    public ProviderConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _tags = context.ScenarioInfo.Tags;
        _configSection = _context.Get<ConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpProviderConfiguration()
    {
        dfeframeworkList = _context.Get<FrameworkList<DfeProviderUsers>>();

        dfeProviderDetailsList = new EmployerProviderRelationshipsSqlDataHelper(_context.Get<ObjectContext>(), _context.Get<DbConfig>()).GetProviderName(dfeframeworkList.SelectMany(x => x.Listofukprn).ToList());

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

    private T SetProviderCreds<T>() where T : ProviderConfig => SetProviderCredsHelper.SetProviderCreds(dfeframeworkList, dfeProviderDetailsList, _configSection.GetConfigSection<T>());

    private void SetProviderConfig()
    {
        var providerConfig = SetProviderCreds<ProviderConfig>();

        if (_tags.IsAddRplDetails()) providerConfig = SetProviderCreds<RplProviderConfig>();

        if (_tags.IsTestDataDeleteCohortViaProviderPortal()) _context.Set(SetProviderCreds<DeleteCohortProviderConfig>());

        _context.SetProviderConfig(providerConfig);
    }
}
