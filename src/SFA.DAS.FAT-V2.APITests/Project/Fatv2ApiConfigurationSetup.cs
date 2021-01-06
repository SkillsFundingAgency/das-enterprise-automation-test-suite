using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    [Binding]
    public class Fatv2ApiConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public Fatv2ApiConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEPAOProjectConfiguration()
        {
            _context.SetFatV2ApiConfig(_configSection.GetConfigSection<Fatv2ApiConfig>());
        }
    }
}