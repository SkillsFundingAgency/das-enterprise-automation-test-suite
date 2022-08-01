using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountSignOutHelper
    {
        private readonly ScenarioContext _context;
     
        public AccountSignOutHelper(ScenarioContext context) => _context = context;
    
        public CreateAnAccountToManageApprenticeshipsPage SignOut() => new HomePage(_context, true).SignOut().CickContinueInYouveLoggedOutPage();

        public YouveLoggedOutPage SignOut(HomePage page) => page.SignOut();
    }
}
