using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;
using SFA.DAS.Roatp.UITests.Project.Tests.StepDefinitions.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class GwAdminSteps
    {
        private readonly ScenarioContext _context;

        public GwAdminSteps(ScenarioContext context) => _context = context;

        [When(@"the gateway admin lands on the Dashboard")]
        public void WhenTheGatewayAdminLandsOnTheDashboard() => GoToRoatpAdminHomePage();

        private GatewayLandingPage GoToRoatpAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();
            new SignInPage(_context).SignInGatewayUser();
            return new GatewayLandingPage(_context);
        }

    }
}
