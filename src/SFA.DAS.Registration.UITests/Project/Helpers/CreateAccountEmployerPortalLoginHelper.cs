using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class CreateAccountEmployerPortalLoginHelper : EmployerPortalLoginHelper
    {
        private readonly ScenarioContext _context;

        public CreateAccountEmployerPortalLoginHelper(ScenarioContext context) : base(context) => _context = context;

        protected override HomePage Login(EasAccountUser loginUser) => new CreateAnAccountToManageApprenticeshipsPage(_context).CreateAccount().Login(loginUser).ContinueToHomePage();
    }
}
