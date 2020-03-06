using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project
{
    [Binding]
    public class AskProjectSetUp
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public AskProjectSetUp(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProjectSpecificConfiguration()
        {
            var config = _configSection.GetConfigSection<AskConfig>();
            _context.SetAskConfig(config);
        }
    }
}
