using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;
        protected readonly ObjectContext objectContext;
        protected readonly LoginCredentialsHelper loginCredentialsHelper;

        public EmployerPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
        }

        public bool IsSignInPageDisplayed()
        {
            return new CheckSignInPage(_context)
                .IsPageDisplayed();
        }

        public bool IsIndexPageDisplayed()
        {
            return new CheckIndexPage(_context)
                .IsPageDisplayed();
        }

        public bool IsYourAccountPageDisplayed()
        {
            return new CheckYourAccountPage(_context)
                .IsPageDisplayed();
        }

        public HomePage ReLogin()
        {
            var loginCredentials = loginCredentialsHelper.GetLoginCredentials();

            return new SignInPage(_context)
                .Login(loginCredentials);
        }

        protected virtual HomePage Login(LoginUser loginUser)
        {
            return new IndexPage(_context)
                    .SignIn()
                    .Login(loginUser);
        }

        public HomePage Login(LoginUser loginUser, bool isLevy)
        {
            loginCredentialsHelper.SetLoginCredentials(loginUser, isLevy);

            var homePage = Login(loginUser);

            objectContext.SetAccountId(homePage.AccountId());

            return homePage;
        }

        public HomePage Login(EoiUser eoiUser)
        {
            return Login(eoiUser, false);
        }
    }
}
