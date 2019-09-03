using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public EmployerPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public bool IsSignInPageDisplayed()
        {
            return new CheckSignInPage(_context)
                .IsIndexPageDisplayed();
        }

        public void ReLogin()
        {
            var loginCredentials = _objectContext.GetLoginCredentials();

            var loginUser = new LoggedInUser { Username = loginCredentials.Username, Password = loginCredentials.Password };

            new SignInPage(_context)
                .Login(loginUser);
        }

        public HomePage Login(LoginUser loginUser)
        {
            return new IndexPage(_context)
                .SignIn()
                .Login(loginUser);
        }

        internal void SetLoginCredentials(LoginUser loginUser, bool isLevy)
        {
            _objectContext.SetLoginCredentials(loginUser.Username, loginUser.Password, isLevy);
            TestContext.Progress.WriteLine($"Email : {loginUser.Username}");
        }
    }
}
