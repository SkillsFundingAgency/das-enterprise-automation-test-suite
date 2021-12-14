using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.PayeCreation.Project
{
    [Binding]
    public class PayeCreationConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public PayeCreationConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpPayeCreationConfiguration()
        {
            _context.SetPayeCreationConfig(_configSection.GetConfigSection<PayeCreationConfig>());

            _context.SetMongoDbConfig(_configSection.GetConfigSection<MongoDbConfig>());
        }
    }
}
