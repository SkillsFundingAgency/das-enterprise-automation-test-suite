using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprovalsSupport.UITests.Project
{
    public class ApprovalsSupportConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ApprovalsSupportConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration()
        {
            var config = _configSection.GetConfigSection<ApprovalsSupportConfig>();
            _context.SetApprovalsSupportConfig(config);
        }
    }
}