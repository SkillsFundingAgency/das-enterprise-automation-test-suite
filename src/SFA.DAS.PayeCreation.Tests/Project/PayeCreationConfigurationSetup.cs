using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PayeCreation.Project
{
    [Binding]
    public class PayeCreationConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpPayeCreationConfiguration()
        {
            context.SetPayeCreationConfig(_configSection.GetConfigSection<PayeCreationConfig>());

            context.SetMongoDbConfig(_configSection.GetConfigSection<MongoDbConfig>());
        }
    }
}
