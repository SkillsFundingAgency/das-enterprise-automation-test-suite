using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerPortalLoginHelper(ScenarioContext context) : IReLoginHelper
    {
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        protected readonly ObjectContext objectContext = context.Get<ObjectContext>();
        protected readonly LoginCredentialsHelper loginCredentialsHelper = context.Get<LoginCredentialsHelper>();

        public bool IsSignInPageDisplayed() => new CheckStubSignInPage(context).IsPageDisplayed();

        public bool IsIndexPageDisplayed() => new CheckIndexPage(context).IsPageDisplayed();

        public bool IsYourAccountPageDisplayed() => new CheckYourAccountPage(context).IsPageDisplayed();

        public HomePage ReLogin() => new StubSignInEmployerPage(context).Login(GetLoginCredentials()).ContinueToHomePage();

        public AccountUnavailablePage FailedLogin1() => new StubSignInEmployerPage(context).Login(GetLoginCredentials()).GoToAccountUnavailablePage();

        protected virtual HomePage Login(EasAccountUser loginUser) => new CreateAnAccountToManageApprenticeshipsPage(context).GoToStubSignInPage().Login(loginUser).ContinueToHomePage();

        protected virtual void SetLoginCredentials(EasAccountUser loginUser, bool isLevy)
            => loginCredentialsHelper.SetLoginCredentials(loginUser.Username, loginUser.IdOrUserRef, loginUser.OrganisationName, isLevy);

        public HomePage Login(EasAccountUser loginUser, bool isLevy)
        {
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
