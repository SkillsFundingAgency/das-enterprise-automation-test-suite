using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
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
            _context.SetApprovalsConfig(_configSection.GetConfigSection<ApprovalsConfig>());

            _context.SetProviderPermissionConfig(_configSection.GetConfigSection<ProviderPermissionsConfig>());

            _context.SetPerfTestProviderPermissionsConfig(_configSection.GetConfigSection<PerfTestProviderPermissionsConfig>());

            _context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<ProviderPermissionLevyUser>(),
                _configSection.GetConfigSection<EmployerWithMultipleAccountsUser>(),
                _configSection.GetConfigSection<FlexiJobUser>(),
                _configSection.GetConfigSection<EmployerConnectedToPortableFlexiJobProvider>()
            });

            _context.SetChangeOfPartyConfig(_configSection.GetConfigSection<ChangeOfPartyConfig>());

            _context.SetPortableFlexiJobProviderConfig(_configSection.GetConfigSection<PortableFlexiJobProviderConfig>());
        }
    }
}
