using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project
{
    [Binding]
    public class ApprenticeCommitmentsConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ApprenticeCommitmentsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpRegistrationConfigConfiguration()
        {
            _context.SetApprenticeCommitmentsConfig(_configSection.GetConfigSection<ApprenticeCommitmentsConfig>());
        }
    }
}
