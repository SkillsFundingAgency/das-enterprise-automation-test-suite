using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRegistrationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly RegistrationConfig _config;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly PregSqlDataHelper _pregSqlDataHelper;

        public ProviderRegistrationSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _objectContext = context.Get<ObjectContext>();
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
            var uri = new Uri(new Uri($"https://accounts.{new Uri(_config.EmployerApprenticeshipServiceBaseURL).Host}"), $"/service/register/{_pregSqlDataHelper.GetReference(_objectContext.GetRegisteredEmail())}").AbsoluteUri;

            _tabHelper.OpenInNewTab(uri);

            new SetUpAsAUserPage(_context).ProviderLeadRegistration().ContinueToGetApprenticeshipFunding().DoNotAddPaye();
        }

        [When(@"the employer adds PAYE from Account Home Page")]
        public void WhenTheEmployerAddsPAYEFromAccountHomePage()
        {
            _homePageStepsHelper.GotoEmployerHomePage(new MyAccountWithOutPayeLoginHelper(_context))
                .AddYourPAYEScheme()
                .AddPaye()
                .ContinueToGGSignIn()
                .SignInTo(0)
                .SearchForAnOrganisation(EnumHelper.OrgType.Company)
                .SelectYourOrganisation(EnumHelper.OrgType.Company)
                .ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                .SelectViewItLaterAndContinue();
        }

        [When(@"the employer signs the agreement")]
        public void WhenTheEmployerSignsTheAgreement()
        {
            _homePageStepsHelper.GotoEmployerHomePage()
                .ClickAcceptYourAgreementLinkInHomePagePanel()
                .ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
                .ProviderLeadRegistrationSignAgreement()
                .ClickNoToAddApprenticeRecords()
                .ClickNoToAddRecruitApprentice()
                .ConfirmProviderLeadRegistrationPermissions();
        }

        [Then(@"the invited employer status in ""(Invitation sent|Account started|PAYE scheme added|Legal agreement accepted)""")]
        public void ThenTheInvitedEmployerStatusIn(string status)
        {
            GoToProviderHomePage();
            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers().VerifyStatus(status);
        }

        private void GoToProviderHomePage() => _providerHomePageStepsHelper.GoToProviderHomePage(true);
    }
}
