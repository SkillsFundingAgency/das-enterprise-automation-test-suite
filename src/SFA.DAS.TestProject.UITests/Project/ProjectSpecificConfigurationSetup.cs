using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project
{
    [Binding]
    public class ProjectSpecificConfigurationSetup          
    {
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        private readonly ObjectContext _objectContext;

        public ProjectSpecificConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _config = context.GetConfigSection<ProjectSpecificConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            _context.SetProjectSpecificConfig(_config);
            _objectContext.SetBrowser(_config.TP_Browser);
        }
    }
}
