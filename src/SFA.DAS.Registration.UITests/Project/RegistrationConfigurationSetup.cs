using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class RegistrationConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public RegistrationConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpRegistrationConfigConfiguration()
        {
            var config = _configSection.GetConfigSection<RegistrationConfig>();
            _context.SetRegistrationConfig(config);

            var levyUser = _configSection.GetConfigSection<LevyUser>();
            _context.SetUser(levyUser);

            var nonLevyUser = _configSection.GetConfigSection<NonLevyUser>();
            _context.SetUser(nonLevyUser);

            var eoiUser = _configSection.GetConfigSection<EoiUser>();
            _context.SetUser(eoiUser);

            var mongoDbconfig = _configSection.GetConfigSection<MongoDbConfig>();
            _context.SetMongoDbConfig(mongoDbconfig);
        }
    }
}
