using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class MultipleAccountsLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public string OrganisationName { get; set; }

        public MultipleAccountsLoginHelper(ScenarioContext context, MultipleAccountUser multipleAccountUser) : base(context)
        {
            _context = context;

            OrganisationName = multipleAccountUser.OrganisationName;
        }

        protected override void SetLoginCredentials(LoginUser loginUser, bool isLevy)
        {
            loginCredentialsHelper.SetLoginCredentials(loginUser.Username, loginUser.Password, OrganisationName, isLevy); 
        }

        protected override HomePage Login(LoginUser loginUser) => new IndexPage(_context).ClickSignInLinkOnIndexPage().MultipleAccountLogin(loginUser).GoToHomePage(objectContext.GetOrganisationName());
    }
}
