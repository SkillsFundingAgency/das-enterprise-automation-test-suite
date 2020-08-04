using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly EmployerLoginFromCreateAcccountPageHelper _loginFromCreateAcccountPageHelper;
        private readonly RegistrationConfig _registrationConfig;
        private HomePage _homePage;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _registrationConfig = _context.GetRegistrationConfig<RegistrationConfig>();
            _registrationDataHelper = _context.Get<RegistrationDataHelper>();
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _loginFromCreateAcccountPageHelper = new EmployerLoginFromCreateAcccountPageHelper(_context);
        }

        [Given(@"the employer logins using Non Levy Account created via powershell scripts")]
        public void GivenTheEmployerLoginsUsingNonLevyAccountCreatedViaPowershellScripts()
        {
            // call powershell script
            var sampleConfiguration = new CreateUserScriptConfiguration
            {
                Email = _registrationDataHelper.RandomEmail,
                Password = _registrationDataHelper.Password,
                PrivateAccountHashSalt = "",
                PrivateAccountHashAllowedCharacters = "",
                PublicAccountHashAllowedCharacters = "",
                PublichAccountHashSalt = "",
                PublicLegalEntityHashAllowedCharacters = "",
                PublicLegalEntityHashSalt = "",
                EmployerAccountsConnectionString = _registrationConfig.RE_AccountsDbConnectionString,
                EmployerUsersConnectionString = _registrationConfig.RE_EmployerUsersDbConnectionString,
                EmployerUsersProfilesConnectionString = _registrationConfig.RE_EmployerUsersProfilesDbConnectionString,
                AgreementName = "_Agreement_V3",
                ApprenticeshipEmployerType = ApprenticeshipEmployerType.NonLevy
            };

            PowerShellScriptWrapper.CreateRegistrationsUser(sampleConfiguration);

            //Login to application
            _loginFromCreateAcccountPageHelper.Login(_registrationDataHelper.RandomEmail, _registrationDataHelper.Password);
        }

        [Given(@"the Employer logins using existing Levy Account")]
        [When(@"the Employer logins using existing Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingLevyAccount() => _homePage = _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>(), true);

        [Given(@"the Employer logins using existing NonLevy Account")]
        [When(@"the Employer logins using existing NonLevy Account")]
        public void GivenTheEmployerLoginsUsingExistingNonLevyAccount() => _homePage = _loginFromCreateAcccountPageHelper.Login(_context.GetUser<NonLevyUser>());

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
    }
}
