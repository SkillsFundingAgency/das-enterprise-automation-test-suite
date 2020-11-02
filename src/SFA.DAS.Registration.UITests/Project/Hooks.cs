using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
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
        private readonly TryCatchException _tryCatch;
        private PregSqlDataHelper _pregSqlDataHelper;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _tprconfig = context.GetTprConfig<TprConfig>();
            _providerLeadRegistrationConfig = context.GetProviderLeadRegistrationConfig<ProviderLeadRegistrationConfig>();
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchException>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate() => _webDriver.Navigate().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var dataHelper = new DataHelper(_context.ScenarioInfo.Tags);

            _objectContext.SetDataHelper(dataHelper);

            var emaildomain = (_context.ScenarioInfo.Tags.Contains("perftestnonlevy") || _context.ScenarioInfo.Tags.Contains("perftestlevy")) ? "perftest.com" : "mailinator.com";

            var registrationDatahelpers = new RegistrationDataHelper($"{dataHelper.GatewayUsername}@{emaildomain}", _config.RE_AccountPassword, _config.RE_OrganisationName, _context.Get<RandomDataGenerator>());

            _context.Set(registrationDatahelpers);

            _context.Set(new LoginCredentialsHelper(_objectContext));

            _objectContext.SetOrganisationName(_config.RE_OrganisationName);

            _context.Set(new RegistrationSqlDataHelper(_config));

            _context.Set(new TprSqlDataHelper(_tprconfig, _objectContext, registrationDatahelpers));

            _objectContext.SetRegisteredEmail(registrationDatahelpers.RandomEmail);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "providerleadregistration")]
        public void SetUpProviderLeadRegistrationDataHelpers()
        {
            _pregSqlDataHelper = new PregSqlDataHelper(_providerLeadRegistrationConfig);

            _context.Set(_pregSqlDataHelper);
        }

        [AfterScenario(Order = 22)]
        [Scope(Tag = "providerleadregistration")]
        public void ClearInvitation() => _tryCatch.AfterScenarioException(() => _pregSqlDataHelper.DeleteInvitation(_objectContext.GetRegisteredEmail()));
    }
}
