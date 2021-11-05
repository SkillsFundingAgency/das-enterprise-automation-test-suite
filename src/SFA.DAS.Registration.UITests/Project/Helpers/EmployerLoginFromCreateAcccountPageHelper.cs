using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerLoginFromCreateAcccountPageHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public EmployerLoginFromCreateAcccountPageHelper(ScenarioContext context) : base(context) => _context = context;
    
        protected override HomePage Login(AccountUser loginUser) => new IndexPage(_context).CreateAccount().SignIn().Login(loginUser);
    }
}
