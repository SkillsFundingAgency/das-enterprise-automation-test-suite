using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class RoatpAdminLoginStepsHelper
    {
        private readonly ScenarioContext _context;

        public RoatpAdminLoginStepsHelper(ScenarioContext context) => _context = context;

        public void SubmitValidLoginDetails()
        {
            new ServiceStartPage(_context).StartNow().LoginToAccess1Staff();

            new SignInPage(_context).SubmitValidLoginDetails();
        }
    }
}
