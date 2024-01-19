using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project
{
    [Binding]
    public class TransfersConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpTransfersConfiguration()
        {
            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<AgreementNotSignedTransfersUser>(),
                _configSection.GetConfigSection<TransfersUser>()
            ]);
        }
    }
}
