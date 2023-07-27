using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service
{
    [Binding]
    public class ProviderConfigurationSetup
    {
        private readonly ScenarioContext _context;

        public ProviderConfigurationSetup(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 2)]
        public void SetUpProviderConfiguration()
        {
            var configSection = _context.Get<IConfigSection>();

            _context.SetProviderConfig(configSection.GetConfigSection<ProviderConfig>());

            _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderViewOnlyUser>());

            _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorUser>());

            _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderContributorWithApprovalUser>());

            _context.SetNonEasLoginUser(configSection.GetConfigSection<ProviderAccountOwnerUser>());
        }
    }
}
