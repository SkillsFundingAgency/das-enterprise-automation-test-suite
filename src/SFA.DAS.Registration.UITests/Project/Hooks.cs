using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
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
        private readonly DbConfig _dbConfig;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private PregSqlDataHelper _pregSqlDataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate() => _context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var tags = _context.ScenarioInfo.Tags;

            var dataHelper = new DataHelper(tags);

            _objectContext.SetDataHelper(dataHelper);

            var emaildomain = tags.Any(x => x.ContainsCompareCaseInsensitive("perftest")) ? "dasperfautomation.com" :
                              tags.Any(x => x.ContainsCompareCaseInsensitive("mailinator")) ? "mailinator.com" :
                              tags.Any(x => x.ContainsCompareCaseInsensitive("testinator")) ? GetDomainName() : "dasautomation.com";

            var aornDataHelper = new AornDataHelper();

            var registrationDatahelpers = new RegistrationDataHelper(tags, $"{dataHelper.GatewayUsername}@{emaildomain}", aornDataHelper);

            _context.Set(registrationDatahelpers);

            _context.Set(new LoginCredentialsHelper(_objectContext));

            _objectContext.SetOrganisationName(registrationDatahelpers.CompanyTypeOrg);

            _context.Set(new RegistrationSqlDataHelper(_dbConfig));

            _context.Set(new TprSqlDataHelper(_dbConfig, _objectContext, aornDataHelper));

            _objectContext.SetRegisteredEmail(registrationDatahelpers.RandomEmail);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "providerleadregistration")]
        public void SetUpProviderLeadRegistrationDataHelpers() => _context.Set(_pregSqlDataHelper = new PregSqlDataHelper(_dbConfig));

        [AfterScenario(Order = 22)]
        [Scope(Tag = "providerleadregistration")]
        public void ClearInvitation() => _tryCatch.AfterScenarioException(() => _pregSqlDataHelper.DeleteInvitation(_objectContext.GetRegisteredEmail()));

        private string GetDomainName() => _context.Get<MailinatorApiHelper>().GetDomainName();
    }
}
