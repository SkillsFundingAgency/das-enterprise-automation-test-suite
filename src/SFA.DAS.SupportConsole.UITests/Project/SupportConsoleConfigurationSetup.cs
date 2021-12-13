using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project
{
    [Binding]
    public class SupportConsoleConfigurationSetup
    {
        private readonly ScenarioContext context;
        private readonly IConfigSection _configSection;

        public SupportConsoleConfigurationSetup(ScenarioContext context)
        {
            context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpSupportConsoleProjectConfiguration()
        {
            context.SetSupportConsoleConfig(_configSection.GetConfigSection<SupportConsoleConfig>());

            context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportConsoleTier1User>());

            context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportConsoleTier2User>());

            context.SetNonEasLoginUser(_configSection.GetConfigSection<SupportToolsUser>());
            
        }
    }
}