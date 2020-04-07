using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRegistration
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _dataHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderRegistration(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<RegistrationDataHelper>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        [Then(@"the provider can invite an employer")]
        public void ThenTheProviderCanInviteAnEmployer()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(false);

            new ProviderLeadRegistrationHomePage(_context).SetupEmployerAccount().LoginToPireanPreprod();

            new StartSettingUpEmployerPage(_context).Start()
                .EnterRegistrationDetailsAndContinue()
                .ChangeDetails()
                .VerifyDetails()
                .NavigateToCheckDetailsPage()
                .InviteEmployer();

            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers().VerifyStatus("Invitation sent");
        }
    }
}
