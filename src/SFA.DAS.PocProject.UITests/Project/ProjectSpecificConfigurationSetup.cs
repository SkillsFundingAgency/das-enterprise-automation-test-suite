using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project
{
    [Binding]
    public class ProjectSpecificConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly ObjectContext _objectContext;

        public ProjectSpecificConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            var configsectionHelper = context.Get<IConfigSection>();
            _config = configsectionHelper.GetConfigSection<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            _context.SetProjectConfig(_config);
            _objectContext.SetBrowser(_config.PP_Browser);
        }
    }
}
