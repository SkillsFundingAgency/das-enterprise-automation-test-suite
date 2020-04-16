using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class MultipleAccountsLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public MultipleAccountsLoginHelper(ScenarioContext context) : base(context) => _context = context;

        protected override HomePage Login(LoginUser loginUser) => new IndexPage(_context).ClickSignInLinkOnIndexPage().MultipleAccountLogin(loginUser).GoToHomePage(objectContext.GetOrganisationName());
    }
}
