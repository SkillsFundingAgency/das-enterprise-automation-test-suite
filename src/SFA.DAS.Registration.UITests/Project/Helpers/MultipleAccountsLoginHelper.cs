using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
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
