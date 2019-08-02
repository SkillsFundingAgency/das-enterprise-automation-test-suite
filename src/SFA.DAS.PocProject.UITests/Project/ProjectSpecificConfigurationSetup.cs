using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project
{
    [Binding]
    public class ProjectSpecificConfigurationSetup
    {
        private readonly ProjectSpecificConfig _config;
        private readonly ObjectContext _objectContext;

        public ProjectSpecificConfigurationSetup(ScenarioContext context)
        {
            _config = context.GetConfigSection<ProjectSpecificConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            _objectContext.SetBrowser(_config.PP_Browser);
        }

    }
}
