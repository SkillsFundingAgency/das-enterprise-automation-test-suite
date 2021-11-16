using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
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
            var regConfig = _configSection.GetConfigSection<RegistrationConfig>();

            var listoforg = ListOfOrganisation();

            int randomvalue = RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, listoforg.Count - 1);

            regConfig.RE_OrganisationName = listoforg[randomvalue];

            _context.SetRegistrationConfig(regConfig);

            _context.SetEasLoginUser(new List<EasAccountUser>() 
            {
                _configSection.GetConfigSection<AuthTestUser>(),
                _configSection.GetConfigSection<LevyUser>(),
                _configSection.GetConfigSection<NonLevyUser>(),
                _configSection.GetConfigSection<TransactorUser>(),
                _configSection.GetConfigSection<ViewOnlyUser>(),
            });

            _context.SetMongoDbConfig(_configSection.GetConfigSection<MongoDbConfig>());
        }

        private List<string> ListOfOrganisation() => new List<string>() { "ABCD BUILDING SERVICE LTD", "COVENTRY AIRPORT LIMITED", "LOAD ESTATES LIMITED" };
    }
}
