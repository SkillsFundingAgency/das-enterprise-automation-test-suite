using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountSignOutHelper
    {
        private readonly ScenarioContext _context;
     
        public AccountSignOutHelper(ScenarioContext context) => _context = context;
    
        public IndexPage SignOut() => new HomePage(_context, true).SignOut().CickContinueInYouveLoggedOutPage();
    }
}
