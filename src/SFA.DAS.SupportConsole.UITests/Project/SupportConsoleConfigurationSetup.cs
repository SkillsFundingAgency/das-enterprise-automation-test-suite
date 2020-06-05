using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project
{
    [Binding]
    public class SupportConsoleConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public SupportConsoleConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpSupportConsoleProjectConfiguration()
        {
            _context.SetSupportConsoleConfig(_configSection.GetConfigSection<SupportConsoleConfig>());

            _context.SetUser(_configSection.GetConfigSection<SupportConsoleTier1User>());

            _context.SetUser(_configSection.GetConfigSection<SupportConsoleTier2User>());
        }
    }
}