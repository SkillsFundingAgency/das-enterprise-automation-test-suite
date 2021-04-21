using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class ApprovalsConfigurationSetup          
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;
        
        public ApprovalsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpApprovalsConfiguration()
        {
            var config = _configSection.GetConfigSection<ApprovalsConfig>();
            _context.SetApprovalsConfig(config);

            var ppconfig = _configSection.GetConfigSection<ProviderPermissionsConfig>();
            _context.SetProviderPermissionConfig(ppconfig);

            var pppfconfig = _configSection.GetConfigSection<PerfTestProviderPermissionsConfig>();
            _context.SetPerfTestProviderPermissionsConfig(pppfconfig);

            var transferUser = _configSection.GetConfigSection<TransfersUser>();
            _context.SetUser(transferUser);

            var agreementNotSignedTransfersUser = _configSection.GetConfigSection<AgreementNotSignedTransfersUser>();
            _context.SetUser(agreementNotSignedTransfersUser);

            var providerPermissionLevyUser = _configSection.GetConfigSection<ProviderPermissionLevyUser>();
            _context.SetUser(providerPermissionLevyUser);

            var providerViewOnlyUser = _configSection.GetConfigSection<ProviderViewOnlyUser>();
            _context.SetUser(providerViewOnlyUser);

            var transfersConfig = _configSection.GetConfigSection<TransfersConfig>();
            _context.SetTransfersConfig(transfersConfig);

            var changeOfPartyConfig = _configSection.GetConfigSection<ChangeOfPartyConfig>();
            _context.SetChangeOfPartyConfig(changeOfPartyConfig);
        }
    }
}
