using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class RoatpAdminLoginStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;

        public RoatpAdminLoginStepsHelper(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        public void SubmitValidLoginDetails() => SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);

        public void SubmitValidLoginDetails(string username, string password)
        {
            new ServiceStartPage(_context).StartNow().LoginToAccess1Staff();

            new EsfaSignInPage(_context).SubmitValidLoginDetails(username, password);
        }
    }
}
