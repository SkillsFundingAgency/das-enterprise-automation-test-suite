using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly RegistrationConfig _registrationConfig;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private readonly TprSqlDataHelper _tprSqlDataHelper;
        private readonly AccountCreationStepsHelper _accountCreationStepsHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;
        private HomePage _homePage;
        private AddAPAYESchemePage _addAPAYESchemePage;
        private GgSignInPage _gGSignInPage;
        private SearchForYourOrganisationPage _searchForYourOrganisationPage;
        private SelectYourOrganisationPage _selectYourOrganisationPage;
        private SignAgreementPage _signAgreementPage;
        private CheckYourDetailsPage _checkYourDetailsPage;
        private TheseDetailsAreAlreadyInUsePage _theseDetailsAreAlreadyInUsePage;
        private EnterYourPAYESchemeDetailsPage _enterYourPAYESchemeDetailsPage;
        private UsingYourGovtGatewayDetailsPage _usingYourGovtGatewayDetailsPage;
        private MyAccountWithOutPayePage _myAccountWithOutPayePage;
        private SetUpAsAUserPage _setUpAsAUserPage;
        private IndexPage _indexPage;
        private SignInPage _signInPage;
        private string _loginEmail;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _tprSqlDataHelper = context.Get<TprSqlDataHelper>();
            _tabHelper = context.Get<TabHelper>();
            _registrationConfig = context.GetRegistrationConfig<RegistrationConfig>();
            _accountCreationStepsHelper = new AccountCreationStepsHelper(context);
        }

        [Given(@"an User Account is created")]
        [When(@"an User Account is created")]
        public void AnUserAccountIsCreated() => _addAPAYESchemePage = _accountCreationStepsHelper.RegisterUserAccount().ContinueToGetApprenticeshipFunding();

        [When("the User initiates Account creation")]
        public void UserInitiatesAccountCreation() => _accountCreationStepsHelper.RegisterUserAccount();

        [Given(@"the User adds PAYE details")]
        [When(@"the User adds PAYE details")]
        [When(@"the User adds valid PAYE details")]
        public SearchForYourOrganisationPage AddPayeDetails() => AddPayeDetails(0);

        [Given(@"the User adds PAYE details attached to a (SingleOrg|MultiOrg) through AORN route")]
        [When(@"the User adds PAYE details attached to a (SingleOrg|MultiOrg) through AORN route")]
        public void WhenTheUserAddsPAYEDetailsAttachedToASingleOrgThroughAORNRoute(string org)
        {
            if (org.Equals("SingleOrg"))
            {
                _tprSqlDataHelper.CreateSingleOrgAornData();
                _checkYourDetailsPage = _accountCreationStepsHelper.AddPayeDetailsForSingleOrgAornRoute(_addAPAYESchemePage);
            }
            else
            {
                _tprSqlDataHelper.CreateMultiOrgAORNData();
                _checkYourDetailsPage = _addAPAYESchemePage.AddAORN()
                    .EnterAornAndPayeDetailsForMultiOrgScenarioAndContinue()
                    .SelectFirstOrganisationAndContinue();
            }

            _signAgreementPage = _checkYourDetailsPage.ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                    .SelectViewAgreementNowAndContinue();
        }

        [When(@"the User adds Invalid PAYE details")]
        public void WhenTheUserAddsInvalidPAYEDetails() => _gGSignInPage = _addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInWithInvalidDetails();

        [Then(@"the '(.*)' error message is shown")]
        public void ThenTheErrorMessageIsShown(string error) => Assert.AreEqual(error, _gGSignInPage.GetErrorMessage());

        [When(@"the User adds valid PAYE details on Gateway Sign In Page")]
        public void WhenTheUserAddsValidPAYEDetailsOnGatewaySignInPage() => _searchForYourOrganisationPage = _gGSignInPage.SignInTo(0);

        [When(@"adds Organisation details")]
        public void AddOrganisationDetails() => AddOrganisationTypeDetails(OrgType.Default);

        [When(@"adds (Company|PublicSector|Charity) Type Organisation details")]
        public void AddOrganisationTypeDetails(OrgType orgType) =>
            _signAgreementPage = _searchForYourOrganisationPage
                .SearchForAnOrganisation(orgType)
                .SelectYourOrganisation(orgType)
                .ContinueToAboutYourAgreementPage()
                .SelectViewAgreementNowAndContinue();

        [When(@"enters an Invalid Company number for Org search")]
        public SelectYourOrganisationPage WhenAnEmployerEntersAnInvalidCompanyNumberForOrgSearchInOrganisationSearchPage()
        {
            _selectYourOrganisationPage = _searchForYourOrganisationPage.SearchForAnOrganisation(_registrationDataHelper.InvalidCompanyNumber);
            return new SelectYourOrganisationPage(_context);
        }

        [Then(@"the '(.*)' message is shown")]
        public void ThenTheMessageIsShown(string resultMessage) => Assert.AreEqual(resultMessage, _selectYourOrganisationPage.GetSearchResultsText());

        [Then(@"the Employer is able to Sign the Agreement and view the Home page")]
        [When(@"the Employer is able to Sign the Agreement")]
        [Then(@"the Employer is able to Sign the Agreement")]
        [When(@"the Employer Signs the Agreement")]
        [Then(@"the Employer Signs the Agreement")]
        public void SignTheAgreement()
        {
            _homePage = _signAgreementPage
                .SignAgreement()
                .ClickOnViewYourAccountButton();

            SetAgreementId(_homePage);
        }

        private HomePage SetAgreementId(HomePage homePage)
        {
            homePage
                 .GoToYourOrganisationsAndAgreementsPage()
                 .ClickViewAgreementLink()
                 .SetAgreementId();

            return new HomePage(_context, true);
        }

        [When(@"the Employer does not sign the Agreement")]
        public void DoNotSignTheAgreement() => _homePage = _signAgreementPage.DoNotSignAgreement();

        [Then(@"the Employer Home page is displayed")]
        public void TheEmployerHomePageIsDisplayed() => _objectContext.SetAccountId(new HomePage(_context).AccountId());

        [When(@"an Employer creates a Non Levy Account and Signs the Agreement")]
        public void GivenAnEmployerCreatesANonLevyAccountAndSignsTheAgreement() =>
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType.Company);

        [When(@"an Employer creates a Non Levy Account and not Signs the Agreement during registration")]
        public void WhenAnEmployerCreatesANonLevyAccountAndNotSignsTheAgreementDuringRegistration() =>
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType.Company);

        [Given(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Signed")]
        [When(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Signed")]
        [Then(@"a Levy Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Signed")]
        public void GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType orgType)
        {
            _accountCreationStepsHelper.SetFirstAccountOrganisationName(orgType);
            CreateUserAccountAndAddOrg(orgType);
            SignTheAgreement();
        }

        [When(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created")]
        [When(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Not Signed")]
        public void GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType orgType)
        {
            CreateUserAccountAndAddOrg(orgType);
            DoNotSignTheAgreement();
        }

        [When(@"an Employer creates a Levy Account and Signs the Agreement")]
        public void GivenAnEmployerCreatesALevyAccountAndSignsTheAgreement()
        {
            _accountCreationStepsHelper.AddLevyDeclarations();
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType.Company);
        }

        [When(@"an Employer creates a Levy Account and not Signs the Agreement during registration")]
        public void WhenAnEmployerCreatesALevyAccountAndNotSignsTheAgreementDuringRegistration()
        {
            _accountCreationStepsHelper.AddLevyDeclarations();
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType.Company);
        }

        [When(@"the Employer initiates adding same Org of (Company|PublicSector|Charity) Type again")]
        public void WhenTheEmployerInitiatesAddingSameOrgTypeAgain(OrgType orgType) =>
            _selectYourOrganisationPage = _accountCreationStepsHelper.SearchForAnotherOrg(_homePage, orgType);

        [Then(@"'Already added' message is shown to the User")]
        public void ThenAlreadyAddedMessageIsShownToTheUser() => _selectYourOrganisationPage.VerifyOrgAlreadyAddedMessage();

        [Then(@"ApprenticeshipEmployerType in Account table is marked as (.*)")]
        public void ThenApprenticeshipEmployerTypeInAccountTableIsMarkedAs(string expectedApprenticeshipEmployerType)
        {
            var actualApprenticeshipEmployerType = _registrationSqlDataHelper.GetAccountApprenticeshipEmployerType(_registrationDataHelper.RandomEmail);
            Assert.AreEqual(expectedApprenticeshipEmployerType, actualApprenticeshipEmployerType);
        }

        [When(@"Signs the Agreement from Account HomePage Panel")]
        public void WhenSignsTheAgreementFromAccountHomePagePanel() => _accountCreationStepsHelper.SignAgreementFromHomePage(_homePage).ClickOnViewYourAccountButton();

        [Then(@"'Start adding apprentices now' task link is displayed under Tasks pane")]
        public void ThenTaskLinkIsDisplayedUnderTasksPane() => _homePage.VerifyStartAddingApprenticesNowTaskLink();

        [Then(@"'These details are already in use' page is displayed when Another Employer tries to register the account with the same Aorn and Paye details")]
        public void ThenPageIsDisplayedWhenAnotherEmployerTriesToRegisterTheAccountWithTheSameAornAndPayeDetails()
        {
            _accountCreationStepsHelper.SignOut();

            _objectContext.SetRegisteredEmail(_registrationDataHelper.AnotherRandomEmail);

            _addAPAYESchemePage = _accountCreationStepsHelper.RegisterUserAccount().ContinueToGetApprenticeshipFunding();

            _theseDetailsAreAlreadyInUsePage = _accountCreationStepsHelper.ReEnterAornDetails(_addAPAYESchemePage);
        }

        [Then(@"'Add a PAYE Scheme' page is displayed when Employer clicks on 'Use different details' button")]
        public void ThenAddAPAYESchemePageIsDisplayedWhenEmployerClicksOnUseDifferentDetailsButton() =>
            _addAPAYESchemePage = _theseDetailsAreAlreadyInUsePage.CickUseDifferentDetailsButtonInTheseDetailsAreAlreadyInUsePage();

        [Then(@"'Add a PAYE Scheme' page is displayed when Employer clicks on Back link on the 'PAYE scheme already in use' page")]
        public void ThenAddAPAYESchemePageIsDisplayedWhenEmployerClicksOnBackLinkOnThePage() =>
            _addAPAYESchemePage = _accountCreationStepsHelper.ReEnterAornDetails(_addAPAYESchemePage).CickBackLinkInTheseDetailsAreAlreadyInUsePage();

        [When(@"the User is on the 'Check your details' page after adding PAYE details through AORN route")]
        public void WhenTheUserIsOnTheCheckYourDetailsPageAfterAddingPAYEDetailsThroughAORNRoute()
        {
            _tprSqlDataHelper.CreateSingleOrgAornData();
            _checkYourDetailsPage = _accountCreationStepsHelper.AddPayeDetailsForSingleOrgAornRoute(_addAPAYESchemePage);
        }

        [Then(@"choosing to change the AORN number displays 'Enter your PAYE scheme details' page")]
        public void ThenChoosingToChangeTheAORNNumberDisplaysPage() =>
            _checkYourDetailsPage = _checkYourDetailsPage.ClickAornChangeLink().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        [Then(@"choosing to change the PAYE scheme displays 'Enter your PAYE scheme details' page")]
        public void ThenChoosingToChangeThePAYESchemeDisplaysEnterYourPAYESchemeDetailsPage() =>
            _checkYourDetailsPage = _checkYourDetailsPage.ClickPayeSchemeChangeLink().AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        [Then(@"choosing to change the Organisation selected displays 'Search for your Organisation' page")]
        public void ThenChoosingToChangeTheOrganisationSelectedDisplaysSearchForYourOrganisationPage() =>
            _checkYourDetailsPage.ClickOrganisationChangeLink();

        [When(@"the User is on the 'Add a PAYE Scheme' page")]
        public void WhenTheUserIsOnThePage() => _enterYourPAYESchemeDetailsPage = _addAPAYESchemePage.AddAORN();

        [Then(@"choosing to Continue with (BlankAornAndBlankPaye|BlankAornValidPaye|BlankPayeValidAorn|InvalidAornAndInvalidPaye) displays relevant Error text")]
        public void ThenChoosingToContinueWithBlankAornValidPayeDisplaysRelevantErrorText(string errorCase)
        {
            string blankAornFieldErrorMessage = _enterYourPAYESchemeDetailsPage.BlankAornFieldErrorMessage;
            string blankPayeFieldErrorMessage = _enterYourPAYESchemeDetailsPage.BlankPayeFieldErrorMessage;
            string aornInvalidFormatErrorMessage = _enterYourPAYESchemeDetailsPage.AornInvalidFormatErrorMessage;
            string payeInvalidFormatErrorMessage = _enterYourPAYESchemeDetailsPage.PayeInvalidFormatErrorMessage;

            switch (errorCase)
            {
                case "BlankAornAndBlankPaye":
                    _enterYourPAYESchemeDetailsPage.Continue();
                    Assert.AreEqual(blankAornFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAboveAornTextBox());
                    Assert.AreEqual(blankPayeFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAbovePayeTextBox());
                    break;
                case "BlankAornValidPaye":
                    _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue("", _objectContext.GetGatewayPaye(0));
                    Assert.AreEqual(blankAornFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAboveAornTextBox());
                    break;
                case "BlankPayeValidAorn":
                    _tprSqlDataHelper.CreateSingleOrgAornData();
                    _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue(_registrationDataHelper.AornNumber, "");
                    Assert.AreEqual(blankPayeFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAbovePayeTextBox());
                    break;
                case "InvalidAornAndInvalidPaye":
                    _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue("InvalidAorn", "InvalidPaye");
                    Assert.AreEqual(aornInvalidFormatErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAboveAornTextBox());
                    Assert.AreEqual(payeInvalidFormatErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAbovePayeTextBox());
                    break;
            }
        }

        [Then(@"choosing to enter AORN and PAYE details in the right format but non existing ones for 3 times displays 'Sorry Account disabled' Page")]
        public void ThenChoosingToEnterAORNAndPAYEDetailsInTheRightFormatButNonExistingOnesForTimesDisplaysPage()
        {
            string InvalidErrorMessage1stAttempt = _enterYourPAYESchemeDetailsPage.InvalidAornAndPayeErrorMessage1stAttempt;
            string InvalidErrorMessage2ndAttempt = _enterYourPAYESchemeDetailsPage.InvalidAornAndPayeErrorMessage2ndAttempt;

            EnterInvalidAornAndPaye();
            Assert.AreEqual(InvalidErrorMessage1stAttempt, _enterYourPAYESchemeDetailsPage.GetInvalidAornAndPayeErrorMessage());
            EnterInvalidAornAndPaye();
            Assert.AreEqual(InvalidErrorMessage2ndAttempt, _enterYourPAYESchemeDetailsPage.GetInvalidAornAndPayeErrorMessage());
            EnterInvalidAornAndPaye();

            _usingYourGovtGatewayDetailsPage = new SorryAccountDisabledPage(_context).ClickAddViaGGLink();
        }

        [Then(@"Employer is able to complete registration through GG route")]
        public void ThenEmployerIsAbleToCompleteRegistrationThroughGGRoute()
        {
            _searchForYourOrganisationPage = _usingYourGovtGatewayDetailsPage.ContinueToGGSignIn().SignInTo(0);
            AddOrganisationDetails();
            SignTheAgreement();
        }

        [When(@"an User tries to regiser an Account with an Email already registered")]
        public void WhenAnUserTriesToRegiserAnAccountWithAnEMailAlreadyRegistered() => new IndexPage(_context).CreateAccount().EnterRegistrationDetailsAndContinue(_context.GetUser<LevyUser>().Username);

        [Then(@"'Email already regisered' message is shown to the User")]
        public void ThenMessageIsShownToTheUser() => new SetUpAsAUserPage(_context).VerifyEmailAlreadyRegisteredErrorMessage();

        [When(@"Given an User registers an acount with email but does not activate it")]
        public void WhenGivenAnUserRegistersAnAcountWithEmailButDoesNotActivateIt() => _accountCreationStepsHelper.RegisterUserAccount();

        [When(@"the User tries to regiser another Account with the same Email that is pending activation")]
        public void WhenTheUserTriesToRegiserAnotherAccountWithTheSameEmailThatIsPendingActivation()
        {
            VisitEmployerApprenticeshipSite();
            _addAPAYESchemePage = _accountCreationStepsHelper.RegisterUserAccount().ContinueToGetApprenticeshipFunding();
        }

        [Then(@"the User is allowed to activate the account and continue with registration")]
        public void ThenTheUserIsAllowedToActivateTheAccountAndContinueWithRegistration() => AddPayeAndOrgAndSignAgreement();

        [When(@"an Employer creates an Account by skipping the add PAYE part")]
        [Given(@"an Employer creates an Account by skipping the add PAYE part")]
        public void GivenAnEmployerCreatesAnAccountBySkippingTheAddPAYEPart()
        {
            AnUserAccountIsCreated();
            _myAccountWithOutPayePage = _addAPAYESchemePage.DoNotAddPaye();
        }

        [When(@"the Employer chooses to add PAYE from Account Home Page")]
        public void WhenTheEmployerChoosesToAddPAYEFromAccountHomePage() => _addAPAYESchemePage = _myAccountWithOutPayePage.AddYourPAYEScheme();

        [Then(@"the Employer is able to add PAYE and Organisation to the Account")]
        public void ThenTheEmployerIsAbleToAddPAYEAndOrganisationToTheAccount() => AddPayeAndOrgAndSignAgreement();

        [Given(@"an Employer creates an Account by skipping to add PAYE details after choosing AORN route")]
        public void GivenAnEmployerCreatesAnAccountBySkippingToAddPAYEDetailsAfterChoosingAORNRoute()
        {
            AnUserAccountIsCreated();
            _myAccountWithOutPayePage = _addAPAYESchemePage.AddAORN().ClickSkipThisStepForNowLink();
        }

        [Then(@"the Employer is able to add AORN details attached to a SingleOrg to the Account")]
        public void ThenTheEmployerIsAbleToAddAORNDetailsAttachedToASingleOrgToTheAccount() =>
            WhenTheUserAddsPAYEDetailsAttachedToASingleOrgThroughAORNRoute("SingleOrg");

        [Then(@"the Employer is able to rename the Account")]
        public void ThenTheEmployerIsAbleToRenameTheAccount()
        {
            var newOrgName = _objectContext.GetOrganisationName() + "_Renamed";

            _homePage.GoToRenameAccountPage()
                .EnterNewNameAndContinue(newOrgName)
                .VerifySucessSummary("Account renamed")
                .VerifyAccountName(newOrgName);
        }

        [When(@"the User is on the 'Check your details' page after adding PAYE and Company Type Org details")]
        public void WhenTheUserIsOnTheCheckYourDetailsPageAfterAddingPAYEAndCompanyTypeOrgDetails()
        {
            _searchForYourOrganisationPage = CreateAnUserAcountAndAddPaye();
            _checkYourDetailsPage = _accountCreationStepsHelper.SearchAndSelectOrg(_searchForYourOrganisationPage, OrgType.Company);
        }

        [Then(@"the User is able to choose a different Company by clicking on Change Organisation")]
        public void ThenTheUserIsAbleToChooseADifferentCompanyByClickingOnChangeOrganisation()
        {
            _searchForYourOrganisationPage = _checkYourDetailsPage.ClickOrganisationChangeLink();
            _checkYourDetailsPage = _accountCreationStepsHelper.SearchAndSelectOrg(_searchForYourOrganisationPage, OrgType.Company2);
            Assert.AreEqual(_objectContext.GetOrganisationName(), _checkYourDetailsPage.GetOrganisationName());
        }

        [Then(@"the User is able to choose a different PAYE scheme by clicking on Change PAYE scheme and complete registation journey")]
        public void ThenTheUserIsAbleToChooseADifferentPAYESchemeByClickingOnChangePAYESchemeAndCompleteRegistationJourney()
        {
            _addAPAYESchemePage = _checkYourDetailsPage.ClickPayeSchemeChangeLink();
            _searchForYourOrganisationPage = _accountCreationStepsHelper.AddADifferentPaye(_addAPAYESchemePage);
            _checkYourDetailsPage = _accountCreationStepsHelper.SearchAndSelectOrg(_searchForYourOrganisationPage, OrgType.Company2);
            Assert.AreEqual(_objectContext.GetGatewayPaye(1), _checkYourDetailsPage.GetPayeScheme());
        }

        [When(@"the Employer logsout of the Account")]
        public void WhenTheEmployerLogsoutOfTheAccount() => _indexPage = _accountCreationStepsHelper.SignOut();

        [Then(@"an Employer is able to create another Account with the same PublicSector Type Org but with a different PAYE")]
        public void ThenAnEmployerIsAbleToCreateAnotherAccountWithTheSamePublicSectorTypeOrgButWithADifferentPAYE()
        {
            _addAPAYESchemePage = _accountCreationStepsHelper.CreateAnotherUserAccount(_indexPage);
            AddPayeDetails(1);
            AddOrganisationTypeDetails(OrgType.PublicSector);
        }

        [Then(@"the Employer is able to Add Another NonLevy PAYE scheme to the Account")]
        [Then(@"the Employer is able to Add Another Levy PAYE scheme to the Account")]
        public void ThenTheEmployerIsAbleToAddAnotherPAYESchemeToTheAccount() =>
            _homePage = _accountCreationStepsHelper.AddAnotherPayeSchemeToTheAccount(_homePage);

        [Then(@"the Employer is able to Remove the second PAYE scheme added from the Account")]
        public void ThenTheEmployerIsAbleToRemoveTheSecondPAYESchemeAddedFromTheAccount() =>
            _accountCreationStepsHelper.RemovePayeSchemeFromTheAccount(_homePage);

        [Then(@"the Employer is able to add another Account with (Company|PublicSector|Charity) Type Org to the same user login")]
        public void ThenTheEmployerIsAbleToAddAnotherAccountToTheSameUserLogin(OrgType orgType) =>
            _homePage = _accountCreationStepsHelper.AddNewAccount(_homePage, orgType, 1);

        [Then(@"the Employer is able to switch between the Accounts")]
        public void ThenTheEmployerIsAbleToSwitchBetweenTheAccounts()
        {
            OpenAccount(_objectContext.GetFirstAccountOrganisationName());
            OpenAccount(_objectContext.GetSecondAccountOrganisationName());
        }

        [Then(@"the Employer Account is locked with 3 incorrect password attempts")]
        public void ThenTheEmployerAccountIsLockedWithIncorrectPasswordAttempts()
        {
            _signInPage = _accountCreationStepsHelper.SignOut().ClickSignInLinkOnIndexPage();

            _loginEmail = _loginCredentialsHelper.GetLoginCredentials().Username;
            const string password = "InvalidPassword";
            AttemptLogin(_loginEmail, password);
            AttemptLogin(_loginEmail, password);
            AttemptLogin(_loginEmail, password);
        }

        [Then(@"Employer is able to Unlock the Account")]
        public void ThenEmployerIsAbleToUnlockTheAccount() => new AccountLockedPage(_context)
            .EnterDetailsAndClickUnlockButton(_loginEmail)
            .CheckHeaderInformationMessageOnSignInPage("Account Unlocked")
            .Login(_objectContext.GetLoginCredentials());

        [When(@"the User is on the 'Set up as a user' page")]
        public void WhenTheUserIsOnTheSetUpAsAUserPage() => _setUpAsAUserPage = new IndexPage(_context).CreateAccount();

        [Then(@"the User is able to navigate to 'Terms and conditions' page")]
        public void ThenTheUserIsAbleToNavigateToTermsAndConditionsPage() => _setUpAsAUserPage.ClickTermsAndConditionsLink();

        [Then(@"'Confirm your identity' page is displayed when the User tries to login with the Unactivated credentials")]
        public void ThenConfirmYourIdentityPageIsDisplayedWhenTheUserTriesToLoginWithTheUnactivatedCredentials()
        {
            _accountCreationStepsHelper.RelaunchApplication();

            new IndexPage(_context).ClickSignInLinkOnIndexPage()
                .LoginWithUnActivatedAccount(_objectContext.GetRegisteredEmail(), _registrationDataHelper.Password);
        }

        [Then(@"the User is able to change the registered Email")]
        public void ThenTheUserIsAbleToChangeTheRegisteredEmail()
        {
            _addAPAYESchemePage = _addAPAYESchemePage.GoToChangeYourEmailAddressPage()
            .ChangeEmail().EnterSecurityCodeDetailsDuringAccountCreationJourney();

            SignOutAndReLoginFromAddAPayeSchemePageDuringAccountCreation(_addAPAYESchemePage, _registrationDataHelper.Password);
        }

        [Then(@"the User is able to change the account Password")]
        public void ThenTheUserIsAbleToChangeTheAccountPassword()
        {
            _addAPAYESchemePage = _addAPAYESchemePage.GoToChangeYourPasswordPage().ChangePasswordDuringAccountCreationJourney();
            SignOutAndReLoginFromAddAPayeSchemePageDuringAccountCreation(_addAPAYESchemePage, _registrationDataHelper.NewPassword);
        }

        [Then(@"the User is able to reset password using 'Forgot your password' link on SignIn Page")]
        public void ThenTheUserIsAbleToResetPasswordUsingLinkOnSignInPage()
        {
            _accountCreationStepsHelper.RelaunchApplication();

            _addAPAYESchemePage = new IndexPage(_context).ClickSignInLinkOnIndexPage().ClickForgottenYourPasswordLink().EnterEmailToBeReset().ResetPasswordDuringAccountCreation();
            SignOutAndReLoginFromAddAPayeSchemePageDuringAccountCreation(_addAPAYESchemePage, _registrationDataHelper.NewPassword);
        }

        private void CreateUserAccountAndAddOrg(OrgType orgType)
        {
            CreateAnUserAcountAndAddPaye();
            AddOrganisationTypeDetails(orgType);
        }

        private void EnterInvalidAornAndPaye() =>
            _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue(_registrationDataHelper.InvalidAornNumber, _registrationDataHelper.InvalidPaye);

        private SearchForYourOrganisationPage CreateAnUserAcountAndAddPaye()
        {
            AnUserAccountIsCreated();
            return AddPayeDetails();
        }

        private void AddPayeAndOrgAndSignAgreement()
        {
            AddPayeDetails();
            AddOrganisationTypeDetails(OrgType.Company);
            SignTheAgreement();
        }

        private SearchForYourOrganisationPage AddPayeDetails(int payeIndex) =>
            _searchForYourOrganisationPage = _addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo(payeIndex);

        private HomePage OpenAccount(string orgName) => _homePage = _homePage.GoToYourAccountsPage().ClickAccountLink(orgName);

        private void AttemptLogin(string loginId, string password) => _signInPage.EnterLoginDetailsAndClickSignIn(loginId, password);

        private void VisitEmployerApprenticeshipSite() => _tabHelper.GoToUrl(_registrationConfig.EmployerApprenticeshipService_BaseUrl);

        private void SignOutAndReLoginFromAddAPayeSchemePageDuringAccountCreation(AddAPAYESchemePage addAPAYESchemePage, string password) =>
            addAPAYESchemePage.SignOut().CickContinueInYouveLoggedOutPage().ClickSignInLinkOnIndexPage()
            .EnterLoginDetailsAndClickSignIn(_objectContext.GetRegisteredEmail(), password);
    }
}
