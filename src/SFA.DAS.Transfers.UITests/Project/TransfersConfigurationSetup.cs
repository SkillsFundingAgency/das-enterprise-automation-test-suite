using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project
{
    [Binding]
    public class TransfersConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;
        private readonly bool _isLocalhost;


        public TransfersConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
            _isLocalhost = !Configurator.IsVstsExecution;

        }
    

        [BeforeScenario(Order = 2)]
        public void SetUpTransfersConfiguration()
        {

            _context.SetUser(_configSection.GetConfigSection<AgreementNotSignedTransfersUser>());
            _context.SetUser(_configSection.GetConfigSection<TransfersUser>());
            _context.SetUser(_configSection.GetConfigSection<LevyUser>());



        }

    }
}
