using SFA.DAS.Approvals.UITests.Project;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project
{
    [Binding]
    public class RAAV2EmployerConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public RAAV2EmployerConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpRAAV2EmployerProjectConfiguration()
        {
            _context.SetEasLoginUser(_configSection.GetConfigSection<RAAV2EmployerUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<RAAV2EmployerProviderPermissionUser>());

            var x = _configSection.GetConfigSection<ProviderPermissionsConfig>();

            _context.SetProviderPermissionConfig(x);

            var providerConfig = new ProviderConfig { UserId = x.UserId, Password = x.Password, Ukprn = x.Ukprn };

            _context.SetProviderConfig(providerConfig);
        }
    }
}
