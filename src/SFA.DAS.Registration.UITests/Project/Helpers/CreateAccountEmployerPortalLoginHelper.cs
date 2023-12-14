using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class CreateAccountEmployerPortalLoginHelper(ScenarioContext context) : EmployerPortalLoginHelper(context)
    {
        private readonly ScenarioContext _context = context;

        protected override HomePage Login(EasAccountUser loginUser) => new CreateAnAccountToManageApprenticeshipsPage(_context).ClickOnCreateAccountLink().Login(loginUser).ContinueToHomePage();
    }
}
