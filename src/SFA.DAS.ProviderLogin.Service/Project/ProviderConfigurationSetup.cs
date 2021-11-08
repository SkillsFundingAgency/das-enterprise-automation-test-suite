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
        private readonly IConfigSection _configSection;
        
        public ProviderConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProviderConfiguration()
        {
            _context.SetProviderConfig(_configSection.GetConfigSection<ProviderConfig>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<ProviderViewOnlyUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<ProviderContributorUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<ProviderContributorWithApprovalUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<ProviderAccountOwnerUser>());
        }
    }
}
