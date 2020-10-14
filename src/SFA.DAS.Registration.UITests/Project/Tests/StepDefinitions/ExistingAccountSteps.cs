using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.InterimPages;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingAccountSteps
    {
        private readonly ScenarioContext _context;

        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerLoginFromCreateAcccountPageHelper _loginFromCreateAcccountPageHelper;
        private HomePage _homePage;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _loginFromCreateAcccountPageHelper = new EmployerLoginFromCreateAcccountPageHelper(_context);
        }

        [Given(@"the Employer logins using existing Levy Account")]
        [When(@"the Employer logins using existing Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingLevyAccount() => _homePage = _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>(), true);

        [Given(@"the Employer logins using existing NonLevy Account")]
        [When(@"the Employer logins using existing NonLevy Account")]
        public void GivenTheEmployerLoginsUsingExistingNonLevyAccount() => _homePage = _loginFromCreateAcccountPageHelper.Login(_context.GetUser<NonLevyUser>());

        [Given(@"the Employer logins using existing transactor user account")]
        public void GivenTheEmployerLoginsUsingExistingTransactorUserAccount() => _homePage = _loginFromCreateAcccountPageHelper.Login(_context.GetUser<TransactorUser>(), true);

        [Given(@"the Employer logins using existing view user account")]
        public void GivenTheEmployerLoginsUsingExistingViewUserAccount() => _homePage = _loginFromCreateAcccountPageHelper.Login(_context.GetUser<ViewOnlyUser>(), true);

        [Then(@"Employer is able to navigate to all the link under Settings")]
        public void ThenEmployerIsAbleToNavigateToAllTheLinkUnderSettings() => _homePage = _homePage
                .GoToYourAccountsPage().OpenAccount().GoToHomePage()
                .GoToRenameAccountPage().GoToHomePage()
                .GoToChangeYourPasswordPage().ClickBackLink()
                .GoToChangeYourEmailAddressPage().ClickBackLink()
                .GoToNotificationSettingsPage().ClickBackLink();

        [Then(@"Employer is able to navigate to Your saved favourites Page")]
        public void ThenEmployerIsAbleToNavigateToYourSavedFavouritesPage() => _homePage = _homePage.GoToYourSavedFavourites().GoToHomePage();

        [Then(@"Employer is able to navigate to Help Page")]
        public void ThenEmployerIsAbleToNavigateToHelpPage() => _homePage.GoToHelpPage();

        [Then(@"the employer can navigate to home page")]
        public void ThenTheEmployerCanNavigateToHomePage() => new HomePage(_context, true);

        [Then(@"the user can not add an organisation")]
        public void ThenTheUserCanNotAddAnOrganisation()
        {
            _homePage = _homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(OrgType.Company2)
                .SelectYourOrganisation(OrgType.Company2)
                .ClickYesContinueButtonAndRedirectedToAccessDeniedPage()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not add Payee Scheme")]
        public void ThenTheUserCanNotAddPayeeScheme()
        {
            _homePage = _homePage.GotoPAYESchemesPage()
                .ClickAddNewSchemeButtonAndRedirectedToAccessDeniedPage()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not invite a team members")]
        public void ThenTheUserCanNotInviteATeamMembers()
        {
            _homePage = _homePage.GotoYourTeamPage()
                .ClickInviteANewMemberButtonAndRedirectedToAccessDeniedPage()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not accept agreement")]
        public void ThenTheUserCanNotAcceptAgreement()
        {
            _homePage = _homePage.ClickAcceptYourAgreementLinkInHomePagePanel()
                .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
                .ClickYesAndContinueDoYouAcceptTheEmployerAgreementOnBehalfOfPage()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not add an apprentices")]
        public void ThenTheUserCanNotAddAnApprentices()
        {
            new InterimApprenticesAccessDeniedPage(_context);
            _homePage = new HomePage(_context, true);
        }
    }
}