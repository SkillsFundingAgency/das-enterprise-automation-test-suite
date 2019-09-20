using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

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

        public void ReLogin()
        {
            var loginCredentials = loginCredentialsHelper.GetLoginCredentials();

            new SignInPage(_context)
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
    }

    public class MultipleAccountsLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public MultipleAccountsLoginHelper(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        protected override HomePage Login(LoginUser loginUser)
        {
            return new IndexPage(_context)
                .SignIn()
                .MultipleAccountLogin(loginUser)
                .GoToHomePage(objectContext.GetOrganisationName());
        }
    }
}
