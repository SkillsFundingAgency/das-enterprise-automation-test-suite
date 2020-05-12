using TechTalk.SpecFlow;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions.GwAdmin
{
    [Binding]
    public class GwAdminSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;

        public GwAdminSteps(ScenarioContext context)
        {
            _context = context;
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(_context);
        }

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => GoToGatewayLandingPage();

        private StaffDashboardPage GoToGatewayLandingPage()
        {
            _loginStepsHelper.SubmitValidLoginDetails();

            return new StaffDashboardPage(_context);
        }

        [When(@"the gateway admin assess all sections as PASS")]
        public void WhenTheGatewayAdminAssessAllSectionsAsPASS()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the gateway admin completes assessment by confirming the Gateway outcome as PASS")]
        public void ThenTheGatewayAdminCompletesAssessmentByConfirmingTheGatewayOutcomeAsPASS()
        {
            ScenarioContext.Current.Pending();
        }

    }
}