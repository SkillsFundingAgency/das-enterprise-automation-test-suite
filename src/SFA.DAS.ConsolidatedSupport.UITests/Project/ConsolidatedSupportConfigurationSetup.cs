using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    [Binding]
    public class ConsolidatedSupportConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ConsolidatedSupportConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpConsolidatedSupportProjectConfiguration()
        {
            _context.SetConsolidatedSupportConfig(_configSection.GetConfigSection<ConsolidatedSupportConfig>());
        }
    }
}