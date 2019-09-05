using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project
{
    [Binding]
    public class ProjectSpecificConfigurationSetup          
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IConfigSection _configSection;

        public ProjectSpecificConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<ProjectConfig>();
            _context.SetProjectConfig(config);

            _objectContext.ReplaceBrowser(config.Browser);
        }
    }
}
