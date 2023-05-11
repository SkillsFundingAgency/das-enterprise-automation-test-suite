using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;

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

        public SignInPage FailedLogin() => new SignInPage(_context).FailedLogin(GetLoginCredentials());

        protected virtual HomePage Login(EasAccountUser loginUser) => new CreateAnAccountToManageApprenticeshipsPage(_context).GoToStubSignInPage().Login(loginUser).ContinueToLogin();

        protected virtual void SetLoginCredentials(EasAccountUser loginUser, bool isLevy) 
            => loginCredentialsHelper.SetLoginCredentials(loginUser.Username, loginUser.IdOrUserRef, loginUser.OrganisationName, isLevy);

        public HomePage Login(EasAccountUser loginUser, bool isLevy)
        {
            loginUser.IdOrUserRef = _registrationSqlDataHelper.GetUserRef(loginUser.Username);

            SetLoginCredentials(loginUser, isLevy);

            var homePage = Login(loginUser);

            objectContext.SetOrUpdateUserCreds(loginUser.Username, loginUser.IdOrUserRef, _registrationSqlDataHelper.CollectAccountDetails(loginUser.Username));

            return homePage;
        }

        public HomePage Login(LevyUser nonLevyUser) => Login(nonLevyUser, true);

        public HomePage Login(NonLevyUser nonLevyUser) => Login(nonLevyUser, false);

        public LoggedInAccountUser GetLoginCredentials() => loginCredentialsHelper.GetLoginCredentials();
    }
}
