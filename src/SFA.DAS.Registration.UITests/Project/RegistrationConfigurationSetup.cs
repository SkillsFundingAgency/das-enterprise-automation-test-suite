using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class RegistrationConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpRegistrationConfigConfiguration()
        {
            if (new TestDataSetUpConfigurationHelper(context).NoNeedToSetUpConfiguration()) return;

            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<AuthTestUser>(),
                _configSection.GetConfigSection<LevyUser>(),
                _configSection.GetConfigSection<NonLevyUser>(),
                _configSection.GetConfigSection<TransactorUser>(),
                _configSection.GetConfigSection<ViewOnlyUser>(),
            ]);

            SetMongoDbConfig();
        }

        [BeforeScenario(Order = 2), Scope(Tag = "@addmultiplelevyfunds")]
        public void SetUpRegistrationConfigConfigurationForAddMultipleLevyFunds()
        {
            context.SetEasLoginUser([_configSection.GetConfigSection<AddMultiplePayeLevyUser>()]);

            SetMongoDbConfig();
        }

        public void SetMongoDbConfig() => context.SetMongoDbConfig(_configSection.GetConfigSection<MongoDbConfig>());
    }
}