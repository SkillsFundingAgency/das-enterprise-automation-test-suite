using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests
{
    [Binding]
    public class DataCoursesApiConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public DataCoursesApiConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpDataCoursesApiConfiguration() => _context.Set(_configSection.GetConfigSection<DasCoursesApiMiConfig>());
    }
}