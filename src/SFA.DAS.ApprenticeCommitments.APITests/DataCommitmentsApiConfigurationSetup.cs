using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests
{
    [Binding]
    public class DataCommitmentsApiConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public DataCommitmentsApiConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpDataCommitmentsApiConfiguration() => _context.Set(_configSection.GetConfigSection<DasCommitmentsApiMIConfig>());
    }
}