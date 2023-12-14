using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TransferMatching.APITests.Project;
using System.Collections.Generic;
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
            _context.SetTransferMatchingJobsConfig(_configSection.GetConfigSection<TransferMatchingJobsConfig>());
            _context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<TransferMatchingUser>(),
                _configSection.GetConfigSection<TransfersUserNoFunds>(),
                _configSection.GetConfigSection<TransfersUser>()
            });
        }
    }
}
