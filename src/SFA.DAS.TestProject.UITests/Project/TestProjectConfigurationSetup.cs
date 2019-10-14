using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project
{
    [Binding]
    public class TestProjectConfigurationSetup          
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public TestProjectConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTestProjectConfiguration()
        {
            var config = _configSection.GetConfigSection<TestProjectConfig>();
            _context.SetTestProjectConfig(config);
        }
    }
}
