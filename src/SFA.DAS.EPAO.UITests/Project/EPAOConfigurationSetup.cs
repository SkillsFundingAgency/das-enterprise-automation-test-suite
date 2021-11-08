using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
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

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOStandardApplyUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOAssessorUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAODeleteAssessorUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOManageUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOApplyUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOE2EApplyUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOWithdrawalUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOAdminUser>());

            _context.SetNonAccountLoginUser(_configSection.GetConfigSection<EPAOStageTwoStandardCancelUser>());
        }             
    }
}