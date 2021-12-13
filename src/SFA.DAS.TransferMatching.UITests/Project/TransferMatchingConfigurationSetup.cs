using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class TransferMatchingConfigurationSetup
    {
        private readonly ScenarioContext context;
        private readonly IConfigSection _configSection;

        public TransferMatchingConfigurationSetup(ScenarioContext context)
        {
            context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpTransferMatchingConfiguration()
        {
            context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<TransferMatchingUser>(),
                _configSection.GetConfigSection<TransfersUserNoFunds>(),
                _configSection.GetConfigSection<TransfersUser>()
            });
        }
    }
}
