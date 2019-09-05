using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;

        public EmployerPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
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
            return new IndexPage(_context)
                .SignIn()
                .Login(loginUser);
        }
    }
}
