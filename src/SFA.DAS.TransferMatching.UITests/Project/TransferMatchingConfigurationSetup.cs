using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TransferMatching.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class TransferMatchingConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpTransferMatchingConfiguration()
        {
            context.SetTransferMatchingJobsConfig(_configSection.GetConfigSection<TransferMatchingJobsConfig>());
            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<TransferMatchingUser>(),
                _configSection.GetConfigSection<TransfersUserNoFunds>(),
                _configSection.GetConfigSection<TransfersUser>()
            ]);
        }
    }
}
