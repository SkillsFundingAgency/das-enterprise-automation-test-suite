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
            _context.SetApprovalsConfig(_configSection.GetConfigSection<ApprovalsConfig>());

            _context.SetProviderPermissionConfig(_configSection.GetConfigSection<ProviderPermissionsConfig>());

            _context.SetPerfTestProviderPermissionsConfig(_configSection.GetConfigSection<PerfTestProviderPermissionsConfig>());

            _context.SetUser(_configSection.GetConfigSection<ProviderPermissionLevyUser>());

            _context.SetUser(_configSection.GetConfigSection<ChangeOfEmployerLevyUser>());

            _context.SetChangeOfPartyConfig(_configSection.GetConfigSection<ChangeOfPartyConfig>());
        }
    }
}
