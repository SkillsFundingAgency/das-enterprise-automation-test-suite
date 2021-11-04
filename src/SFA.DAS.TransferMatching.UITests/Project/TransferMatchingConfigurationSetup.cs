using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class TransferMatchingConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public TransferMatchingConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTransferMatchingConfiguration()
        {
            _context.SetUser(_configSection.GetConfigSection<TransferMatchingUser>());

            _context.SetUser(_configSection.GetConfigSection<TransfersUserNoFunds>());

            _context.SetUser(_configSection.GetConfigSection<TransfersUser>());
        }
    }
}
