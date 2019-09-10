using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;

        public EmployerPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
        }

        public bool IsSignInPageDisplayed()
        {
            return new CheckSignInPage(_context)
                .IsPageDisplayed();
        }

        public void ReLogin()
        {
            var loginCredentials = _loginCredentialsHelper.GetLoginCredentials();

            new SignInPage(_context)
                .Login(loginCredentials);
        }

        public HomePage Login(LoginUser loginUser)
        {
            var homePage = new IndexPage(_context)
                .SignIn()
                .Login(loginUser);

            _objectContext.SetAccountId(homePage.AccountID());

            return homePage;
        }
    }
}
