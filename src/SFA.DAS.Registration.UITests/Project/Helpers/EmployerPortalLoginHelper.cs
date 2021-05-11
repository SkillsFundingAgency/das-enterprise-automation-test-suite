using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        protected readonly ObjectContext objectContext;
        protected readonly LoginCredentialsHelper loginCredentialsHelper;

        public EmployerPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            objectContext = context.Get<ObjectContext>();
            loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
        }

        public bool IsSignInPageDisplayed() => new CheckSignInPage(_context).IsPageDisplayed();

        public bool IsIndexPageDisplayed() => new CheckIndexPage(_context).IsPageDisplayed();

        public bool IsYourAccountPageDisplayed() => new CheckYourAccountPage(_context).IsPageDisplayed();

        public HomePage ReLogin() => new SignInPage(_context).Login(GetLoginCredentials());

        protected virtual HomePage Login(LoginUser loginUser) => new IndexPage(_context).ClickSignInLinkOnIndexPage().Login(loginUser);

        public HomePage Login(LoginUser loginUser, bool isLevy)
        {
            loginCredentialsHelper.SetLoginCredentials(loginUser, isLevy);

            var homePage = Login(loginUser);

            (string accountId, string hashedAccountId) = _registrationSqlDataHelper.GetAccountIds(loginUser.Username);

            objectContext.SetHashedAccountId(hashedAccountId);

            objectContext.SetDBAccountId(accountId);

            return homePage;
        }

        public HomePage Login(NonLevyUser nonLevyUser) => Login(nonLevyUser, false);

        public LoginUser GetLoginCredentials() => loginCredentialsHelper.GetLoginCredentials();
    }
}
