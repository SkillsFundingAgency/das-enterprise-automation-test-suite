using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRegistrationSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private readonly PregSqlDataHelper _pregSqlDataHelper;

        public ProviderRegistrationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
            _pregSqlDataHelper = context.Get<PregSqlDataHelper>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
        }

        [Given(@"the provider invites an employer")]
        public void GivenTheProviderInviteAnEmployer()
        {
            GoToProviderHomePage();

            new ProviderLeadRegistrationHomePage(_context).SetupEmployerAccount()
                .Start()
                .EnterRegistrationDetailsAndContinue()
                .ClickEmployerOrganisationChange()
                .VerifyDetails()
                .NavigateToCheckDetailsPage()
                .InviteEmployer();
        }

        [When(@"the provider resends the invite after editing details")]
        public void WhenTheProviderResendsTheInviteAfterEditingDetails()
        {
            GoToProviderHomePage();

            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers()
                .ResendInvitation()
                .ClickEmployerFirstNameChange()
                .UpdateEmployerFirstNameAndContinue("NewFirstName")
                .InviteEmployer();
        }

        [When(@"the employer sets up the user")]
        public void WhenTheEmployerSetsUpTheUser()
        {
            string email = _objectContext.GetRegisteredEmail();

            var uri = new Uri(new Uri($"https://{new Uri(UrlConfig.EmployerApprenticeshipService_BaseUrl).Host}"), $"/service/register/{_pregSqlDataHelper.GetReference(email)}").AbsoluteUri;
            
            _tabHelper.OpenInNewTab(uri);

            _accountCreationStepsHelper.RegisterUserAccount(new StubSignInEmployerPage(_context), email).DoNotEnterNameAndContinue().ConfirmNameAndContinue().ClickContinueButtonToAcknowledge();
        }

        [When(@"the employer adds PAYE from TaskList Page")]
        public void WhenTheEmployerAddsPAYEFromTaskListPage()
        {     
            _homePageStepsHelper.GoToCreateYourEmployerAccountPage()
            .GoToAddPayeLink()
            .SelectOptionLessThan3Million()
            .AddPaye()
            .ContinueToGGSignIn()
            .SignInTo(0)
            .SearchForAnOrganisation(EnumHelper.OrgType.Company)
            .SelectYourOrganisation(EnumHelper.OrgType.Company)
            .ClickYesThisIsMyOrg()
            .ContinueToConfirmationPage()
            .GoToSetYourAccountNameLink()
            .SelectoptionNo()
            .ContinueToAcknowledge()
            .SelectGoToYourEmployerAccountHomepage();
        }


        [When(@"the employer signs the agreement")]
        public void WhenTheEmployerSignsTheAgreement()
        {
            _homePageStepsHelper.GotoEmployerHomePage()
                .ClickAcceptYourAgreementLinkInHomePagePanel()
                .ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
                .ProviderLeadRegistrationSignAgreement()
                .ClickAddApprentice(AddApprenticePermissions.DoNotAllow)
                .ClickRecruitApprentice(RecruitApprenticePermissions.DoNotAllow)
                .ConfirmProviderLeadRegistrationPermissions();
        }

        [Then(@"the invited employer status is ""(Account creation not started|Account creation started|PAYE scheme added|Legal agreement accepted)""")]
        public void ThenTheInvitedEmployerStatusIs(string status)
        {
            GoToProviderHomePage();
            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers().VerifyStatus(status);
        }

        [Then(@"view status ""(Account creation started:|PAYE scheme added:|Legal agreement accepted:)"" is ""(Account creation not started|PAYE scheme not added|Legal agreement not accepted|today)""")]
        public void ThenViewStatusIs(string status, string value)
        {
            if (value == "today")
                value = DateTime.Today.ToString("dd MMMM yyyy");

            GoToProviderHomePage();

            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers()
                .ViewStatus()
                .VerifyStatus(status, value)
                .ClickBackLink();
        }

        [Then(@"the email address is not editable")]
        public void ThenTheEmailAddressIsNotEditable()
        {
            GoToProviderHomePage();

            new ProviderLeadRegistrationHomePage(_context).ViewInvitedEmployers()
                .ResendInvitation()
                .ClickEmployerFirstNameChange()
                .VerifyEmailIsNotEditable();
        }


        private void GoToProviderHomePage() => _providerHomePageStepsHelper.GoToProviderHomePage(true);
    }
}