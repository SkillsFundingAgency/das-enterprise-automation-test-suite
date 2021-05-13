using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project
{
    [Binding]
    public class TransfersConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public TransfersConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTransfersConfiguration()
        {
            _context.SetUser(_configSection.GetConfigSection<AgreementNotSignedTransfersUser>());

            _context.SetUser(_configSection.GetConfigSection<TransfersUser>());
        }
    }
}
