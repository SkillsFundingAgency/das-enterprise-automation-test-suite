using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
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
            var rAAV2EmployerUser = _configSection.GetConfigSection<RAAV2EmployerUser>();
            _context.SetUser(rAAV2EmployerUser);
        }
    }
}
