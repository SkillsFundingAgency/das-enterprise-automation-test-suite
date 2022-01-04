using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class MultipleAccountsLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public string OrganisationName { get; set; }

        public MultipleAccountsLoginHelper(ScenarioContext context, MultipleEasAccountUser multipleAccountUser) : base(context)
        {
            _context = context;

            OrganisationName = multipleAccountUser.OrganisationName;
        }

        protected override void SetLoginCredentials(EasAccountUser loginUser, bool isLevy) => 
            loginCredentialsHelper.SetLoginCredentials(loginUser.Username, loginUser.Password, OrganisationName, isLevy); 
        
        protected override HomePage Login(EasAccountUser loginUser) => new CreateAnAccountToManageApprenticeshipsPage(_context).ClickSignInLinkOnIndexPage().MultipleAccountLogin(loginUser).GoToHomePage(objectContext.GetOrganisationName());

        public MyAccountTransferFundingPage LoginToMyAccountTransferFunding(SignInPage signInPage) => signInPage.GoToMyAccountTransferFundingPage(GetLoginCredentials());

        public new HomePage ReLogin() => Login(GetLoginCredentials());
    }
}
