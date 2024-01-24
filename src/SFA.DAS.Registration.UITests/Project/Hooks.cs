using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailinatorAPI.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
        private PregSqlDataHelper _pregSqlDataHelper;

        [BeforeScenario(Order = 21)]
        public void Navigate() => context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var tags = context.ScenarioInfo.Tags;

            var dataHelper = new DataHelper(tags);

            _objectContext.SetDataHelper(dataHelper);

            var emaildomain = tags.Any(x => x.ContainsCompareCaseInsensitive("perftest")) ? "dasperfautomation.com" :
                              tags.Any(x => x.ContainsCompareCaseInsensitive("mailinator")) ? "mailinator.com" :
                              tags.Any(x => x.ContainsCompareCaseInsensitive("testinator")) ? GetDomainName() : "dasautomation.com";

            var aornDataHelper = new AornDataHelper();

            var registrationDatahelpers = new RegistrationDataHelper(tags, $"{dataHelper.GatewayUsername}@{emaildomain}", aornDataHelper);

            context.Set(registrationDatahelpers);

            context.Set(new LoginCredentialsHelper(_objectContext));

            _objectContext.SetOrganisationName(registrationDatahelpers.CompanyTypeOrg);

            context.Set(new RegistrationSqlDataHelper(_objectContext, _dbConfig));

            context.Set(new TprSqlDataHelper(_dbConfig, _objectContext, aornDataHelper));

            _objectContext.SetRegisteredEmail(registrationDatahelpers.RandomEmail);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "providerleadregistration")]
        public void SetUpProviderLeadRegistrationDataHelpers() => context.Set(_pregSqlDataHelper = new PregSqlDataHelper(_objectContext, _dbConfig));

        [AfterScenario(Order = 22)]
        [Scope(Tag = "providerleadregistration")]
        public void ClearInvitation() => _tryCatch.AfterScenarioException(() => _pregSqlDataHelper.DeleteInvitation(_objectContext.GetRegisteredEmail()));

        private string GetDomainName() => context.Get<MailinatorApiHelper>().GetDomainName();
    }
}
