using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderregistrationproviderroleSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderregistrationproviderroleSteps(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }       

        [Given(@"the user can view invited employers")]
        public void GivenTheUserCanViewInvitedEmployers()
        {
            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployersForProviderRoles().LoginToPireanPreprod();
        }

        [Given(@"the user cannot invite an employer to setup an account")]
        public void GivenTheUserCannotInviteAnEmployerToSetupAnAccount()
        {            
            new ProviderLeadRegistrationHomePage(_context).GoToProviderToSetUpEmployerAccountGoesToAccessDenied().GoBackToTheProviderHomePage();
        }

        [Given(@"the user can invite an employer to setup an account")]
        public void GivenTheUserCanInviteAnEmployerToSetupAnAccount()
        {
            new ProviderLeadRegistrationHomePage(_context).SetupEmployerAccountForProviderRoles();

            new StartSettingUpEmployerPage(_context).Start()
                .EnterRegistrationDetailsAndContinue()
                .ChangeDetails()
                .VerifyDetails()
                .NavigateToCheckDetailsPage()
                .InviteEmployer();
        }
    }
}
