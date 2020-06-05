using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    public class EPAOConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public EPAOConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEPAOProjectConfiguration()
        {
            _context.SetEPAOConfig(_configSection.GetConfigSection<EPAOConfig>());

            _context.SetUser(_configSection.GetConfigSection<EPAOStandardApplyUser>());

            _context.SetUser(_configSection.GetConfigSection<EPAOAssessorUser>());

            _context.SetUser(_configSection.GetConfigSection<EPAOManageUser>());

            _context.SetUser(_configSection.GetConfigSection<EPAOApplyUser>());

            _context.SetUser(_configSection.GetConfigSection<EPAOAdminUser>());
        }
    }
}
