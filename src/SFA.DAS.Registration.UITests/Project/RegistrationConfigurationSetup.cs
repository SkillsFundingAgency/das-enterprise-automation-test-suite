using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
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
            _context.SetRegistrationConfig(_configSection.GetConfigSection<RegistrationConfig>());

            _context.SetTprConfig(_configSection.GetConfigSection<TprConfig>());

            _context.SetProviderLeadRegistrationConfig(_configSection.GetConfigSection<ProviderLeadRegistrationConfig>());

            _context.SetUser(_configSection.GetConfigSection<LevyUser>());

            _context.SetUser(_configSection.GetConfigSection<NonLevyUser>());

            _context.SetUser(_configSection.GetConfigSection<TransactorUser>());

            _context.SetUser(_configSection.GetConfigSection<ViewOnlyUser>());

            _context.SetMongoDbConfig(_configSection.GetConfigSection<MongoDbConfig>());
        }
    }
}
