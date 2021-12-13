using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project
{
    [Binding]
    public class TransfersConfigurationSetup
    {
        private readonly ScenarioContext context;
        private readonly IConfigSection _configSection;

        public TransfersConfigurationSetup(ScenarioContext context)
        {
            context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTransfersConfiguration()
        {
            context.SetEasLoginUser(new List<EasAccountUser>() 
            {
                _configSection.GetConfigSection<AgreementNotSignedTransfersUser>(),
                _configSection.GetConfigSection<TransfersUser>()
            });
        }
    }
}
