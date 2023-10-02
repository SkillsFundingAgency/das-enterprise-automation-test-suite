using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
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
            var dfeproviders = _context.Get<List<DfeProvider>>();

            _context.SetApprovalsConfig(_configSection.GetConfigSection<ApprovalsConfig>());

            var providerPermissionsConfig = SetProviderCreds(dfeproviders, _configSection.GetConfigSection<ProviderPermissionsConfig>());

            _context.SetProviderPermissionConfig(providerPermissionsConfig);

            _context.SetPerfTestProviderPermissionsConfig(_configSection.GetConfigSection<PerfTestProviderPermissionsConfig>());

            _context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<ProviderPermissionLevyUser>(),
                _configSection.GetConfigSection<EmployerWithMultipleAccountsUser>(),
                _configSection.GetConfigSection<FlexiJobUser>(),
                _configSection.GetConfigSection<EmployerConnectedToPortableFlexiJobProvider>()
            });

            var changeOfPartyConfig = SetProviderCreds(dfeproviders, _configSection.GetConfigSection<ChangeOfPartyConfig>());

            _context.SetChangeOfPartyConfig(changeOfPartyConfig);

            var portableFlexiJobProviderConfig = SetProviderCreds(dfeproviders, _configSection.GetConfigSection<PortableFlexiJobProviderConfig>());

            _context.SetPortableFlexiJobProviderConfig(portableFlexiJobProviderConfig);
        }

        private static T SetProviderCreds<T>(List<DfeProvider> dfeProviderList, T t) where T : ProviderConfig
        {
            return SetProviderCredsHelper.SetProviderCreds(dfeProviderList, t);
        }
    }
}
