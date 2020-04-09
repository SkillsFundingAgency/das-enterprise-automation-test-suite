using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        private readonly TprConfig _tprconfig;
        private readonly ProviderLeadRegistrationConfig _providerLeadRegistrationConfig;
        private readonly IWebDriver _webDriver;
        private readonly ObjectContext _objectContext;
        private PregSqlDataHelper _pregSqlDataHelper;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _tprconfig = context.GetTprConfig<TprConfig>();
            _providerLeadRegistrationConfig = context.GetProviderLeadRegistrationConfig<ProviderLeadRegistrationConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.EmployerApprenticeshipServiceBaseURL;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var dataHelper = new DataHelper(_config.TwoDigitProjectCode);

            _objectContext.SetDataHelper(dataHelper);
           
            var registrationDatahelpers = new RegistrationDataHelper(dataHelper.GatewayUsername, _config.RE_AccountPassword, _config.RE_OrganisationName, _context.Get<RandomDataGenerator>());

            _context.Set(registrationDatahelpers);

            _context.Set(new LoginCredentialsHelper(_objectContext));

            _objectContext.SetOrganisationName(_config.RE_OrganisationName);

            _context.Set(new RegistrationSqlDataHelper(_config));

            _context.Set(new TprSqlDataHelper(_tprconfig, _objectContext, registrationDatahelpers));

            _pregSqlDataHelper = new PregSqlDataHelper(_providerLeadRegistrationConfig);

            _context.Set(_pregSqlDataHelper);

            _objectContext.SetRegisteredEmail(registrationDatahelpers.RandomEmail);
        }

        [AfterScenario(Order = 22)]
        [Scope(Tag = "providerleadregistration")]
        public void ClearInvitation() => _pregSqlDataHelper.DeleteInvitation(_objectContext.GetRegisteredEmail());
    }
}
