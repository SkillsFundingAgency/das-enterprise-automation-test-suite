using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRegistration
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _dataHelper;
        private readonly TabHelper _tabHelper;
        private readonly RegistrationConfig _config;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly PregSqlDataHelper _pregSqlDataHelper;
        private HomePage _homePage;

        public ProviderRegistration(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<RegistrationConfig>();
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<RegistrationDataHelper>();
            _tabHelper = context.Get<TabHelper>();
            _pregSqlDataHelper = context.Get<PregSqlDataHelper>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
        }

        [Given(@"the provider invite an employer")]
        public void GivenTheProviderInviteAnEmployer()
        {
            GoToProviderHomePage();

            new ProviderLeadRegistrationHomePage(_context).SetupEmployerAccount().LoginToPireanPreprod();

            new StartSettingUpEmployerPage(_context).Start()
                .EnterRegistrationDetailsAndContinue()
                .ChangeDetails()
                .VerifyDetails()
                .NavigateToCheckDetailsPage()
                .InviteEmployer();
        }

        [When(@"the employer sets up the user")]
        public void WhenTheEmployerSetsUpTheUser()
        {
            var uri = new Uri(new Uri(_config.EmployerApprenticeshipServiceBaseURL), $"/service/register/{_pregSqlDataHelper.GetReference(_objectContext.GetRegisteredEmail())}").AbsoluteUri;

            _tabHelper.OpenInNewTab(uri);

            new SetUpAsAUserPage(_context).ProviderLeadRegistration().ContinueToGetApprenticeshipFunding().DoNotAddPaye();
        }

        [When(@"the employer adds PAYE from Account Home Page")]
        public void WhenTheEmployerAddsPAYEFromAccountHomePage()
        {
            _homePage = _homePageStepsHelper.GotoEmployerHomePage(new MyAccountWithOutPayeLoginHelper(_context))
                .AddYourPAYEScheme()
                .AddPaye()
                .ContinueToGGSignIn()
                .EnterPayeDetailsAndContinue(0)
                .ClickContinueInConfirmPAYESchemePage()
                .SelectContinueAccountSetupInPAYESchemeAddedPage();
        }


        [Then(@"the invited employer status in ""(Invitation sent|Account started|PAYE scheme added|Legal agreement signed)""")]
        public void ThenTheInvitedEmployerStatusIn(string status)
        {
            GoToProviderHomePage();
            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers().VerifyStatus(status);
        }

        private void GoToProviderHomePage() => _providerHomePageStepsHelper.GoToProviderHomePage(true);
    }
}
