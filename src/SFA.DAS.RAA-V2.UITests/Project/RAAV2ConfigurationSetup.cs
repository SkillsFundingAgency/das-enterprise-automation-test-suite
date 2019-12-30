using SFA.DAS.Configuration;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project
{
    [Binding]
    public class RAAV2ConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public RAAV2ConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration()
        {
            var config = _configSection.GetConfigSection<RAAV2Config>();
            _context.SetRAAV2Config(config);

            var rAAV2EmployerUser = _configSection.GetConfigSection<RAAV2EmployerUser>();
            _context.SetUser(rAAV2EmployerUser);
        }
    }
}
