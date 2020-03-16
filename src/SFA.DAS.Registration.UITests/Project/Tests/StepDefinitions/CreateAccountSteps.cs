using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using static SFA.DAS.RAA_V1.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;
        private readonly TprSqlDataHelper _tprSqlDataHelper;
        private HomePage _homePage;
        private SetUpAsAUserPage _setUpAsAUserPage;
        private AddAPAYESchemePage _addAPAYESchemePage;
        private GgSignInPage _gGSignInPage;
        private SearchForYourOrganisationPage _organistionSearchPage;
        private SelectYourOrganisationPage _selectYourOrganisationPage;
        private SignAgreementPage _signAgreementPage;
        private CheckYourDetailsPage _checkYourDetailsPage;
        private YourOrganisationsAndAgreementsPage _yourOrganisationsAndAgreementsPage;
        private TheseDetailsAreAlreadyInUsePage _theseDetailsAreAlreadyInUsePage;
        private EnterYourPAYESchemeDetailsPage _enterYourPAYESchemeDetailsPage;
        private UsingYourGovtGatewayDetailsPage _usingYourGovtGatewayDetailsPage;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
            _tprSqlDataHelper = context.Get<TprSqlDataHelper>();
        }

        [Given(@"an User Account is created")]
        [When(@"an User Account is created")]
        public void AnUserAccountIsCreated() => _addAPAYESchemePage = RegisterUser();

        [Then(@"My Account Home page is displayed when PAYE details are not added")]
        public void DoNotAddPayeDetails() => _addAPAYESchemePage.DoNotAddPaye();

        [Given(@"the User adds PAYE details")]
        [When(@"the User adds PAYE details")]
        [When(@"the User adds valid PAYE details")]
        public void AddPayeDetails() => _organistionSearchPage = _addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo();

        [Given(@"the User adds PAYE details attached to a (SingleOrg|MultiOrg) through AORN route")]
        [When(@"the User adds PAYE details attached to a (SingleOrg|MultiOrg) through AORN route")]
        public void WhenTheUserAddsPAYEDetailsAttachedToASingleOrgThroughAORNRoute(string org)
        {
            if (org.Equals("SingleOrg"))
            {
                _tprSqlDataHelper.CreateSingleOrgAornData();
                _checkYourDetailsPage = AddPayeDetailsForSingleOrgAornRoute();
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
        public void WhenTheUserAddsInvalidPAYEDetails()
        {
            _gGSignInPage = _addAPAYESchemePage
                .AddPaye().ContinueToGGSignIn()
                .SignInWithInvalidDetails();
        }

        [Then(@"the '(.*)' error message is shown")]
        public void ThenTheErrorMessageIsShown(string error)
        {
            Assert.AreEqual(error, _gGSignInPage.GetErrorMessage());
        }

        [When(@"the User adds valid PAYE details on Gateway Sign In Page")]
        public void WhenTheUserAddsValidPAYEDetailsOnGatewaySignInPage()
        {
            _organistionSearchPage = _gGSignInPage.SignInTo();
        }

        [When(@"adds Organisation details")]
        public void AddOrganisationDetails() => AddOrganisationTypeDetails(OrgType.Default);

        [When(@"adds (Company|PublicSector|Charity) Type Organisation details")]
        public void AddOrganisationTypeDetails(OrgType orgType)
        {
            _signAgreementPage = _organistionSearchPage
                .SearchForAnOrganisation(orgType)
                .SelectYourOrganisation(orgType)
                .ContinueToAboutYourAgreementPage()
                .SelectViewAgreementNowAndContinue();
        }

        [When(@"the Employer Creates a new organisation and adds the details manually")]
        public CheckYourDetailsPage WhenTheEmployerCreatesANewOrganisationAndAddsTheDetailsManually()
        {
            _checkYourDetailsPage = WhenAnEmployerEntersAnInvalidCompanyNumberForOrgSearchInOrganisationSearchPage()
                .ClickEnterYourDetailsManuallyLinkInSelectYourOrganisationPage()
                .EnterOrganisationNameAndContinueInEnterYourOrganisationNamePage()
                .ClickEnterAddressManullyLinkInFindOrganisationAddressPage()
                .EnterAddressDetailsAndContinue();

            _objectContext.UpdateOrganisationName(_registrationDataHelper.OrgNameForManualEntry);

            return new CheckYourDetailsPage(_context);
        }

        [Then(@"the Employer validates error messages for manually entering blank Organisation and Address details")]
        public void ThenTheEmployerValidatesErrorMessagesForManuallyEnteringBlankOrganisationAndAddressDetails()
        {
            WhenAnEmployerEntersAnInvalidCompanyNumberForOrgSearchInOrganisationSearchPage()
                .ClickEnterYourDetailsManuallyLinkInSelectYourOrganisationPage()
                .LeaveOrganisationNameBlankAndContinueInEnterYourOrganisationNamePage()
                .VerifyErrorMessagesInEnterYourOrganisationNamePage()
                .EnterOrganisationNameAndContinueInEnterYourOrganisationNamePage()
                .ClickEnterAddressManullyLinkInFindOrganisationAddressPage()
                .ClickContinueWithOutEnteringDetailsInEnterYourOrganisationsAddressPage()
                .VerifyErrorMessagesInEnterYourOrganisationsAddressPage();
        }

        [When(@"enters an Invalid Company number for Org search")]
        public SelectYourOrganisationPage WhenAnEmployerEntersAnInvalidCompanyNumberForOrgSearchInOrganisationSearchPage()
        {
            _selectYourOrganisationPage = _organistionSearchPage.SearchForAnOrganisation(_registrationDataHelper.InvalidCompanyNumber);
            return new SelectYourOrganisationPage(_context);
        }

        [Then(@"the '(.*)' message is shown")]
        public void ThenTheMessageIsShown(string resultMessage)
        {
            Assert.AreEqual(resultMessage, _selectYourOrganisationPage.GetSearchResultsText());
        }

        [Then(@"the Employer is able to Sign the Agreement and view the Home page")]
        [When(@"the Employer is able to Sign the Agreement")]
        [Then(@"the Employer is able to Sign the Agreement")]
        [When(@"the Employer Signs the Agreement")]
        public void SignTheAgreement()
        {
            _homePage = _signAgreementPage
                .SignAgreement();

            _homePage.VerifySucessSummary();

            SetAgreementId(_homePage);
        }

        [When(@"the Employer does not sign the Agreement")]
        public void DoNotSignTheAgreement()
        {
            _homePage = _signAgreementPage
                .DoNotSignAgreement();
        }

        [Then(@"the Employer Home page is displayed")]
        public void TheEmployerHomePageIsDisplayed()
        {
            var accountid = new HomePage(_context)
                .HomePage()
                .AccountId();

            _objectContext.SetAccountId(accountid);
        }

        private HomePage SetAgreementId(HomePage homePage)
        {
            homePage
                 .GoToYourOrganisationsAndAgreementsPage()
                 .SetAgreementId();

            return new HomePage(_context, true);
        }

        [When(@"an Employer creates a Non Levy Account and Signs the Agreement")]
        public void GivenAnEmployerCreatesANonLevyAccountAndSignsTheAgreement() =>
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType.Company);

        [When(@"an Employer creates a Non Levy Account and not Signs the Agreement during registration")]
        public void WhenAnEmployerCreatesANonLevyAccountAndNotSignsTheAgreementDuringRegistration() =>
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType.Company);

        [Given(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Signed")]
        [When(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Signed")]
        public void GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType orgType)
        {
            CreateUserAccountAndAddOrg(orgType);
            SignTheAgreement();
        }

        [When(@"an Employer Account with (Company|PublicSector|Charity) Type Org is created and agreement is Not Signed")]
        public void GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType orgType)
        {
            CreateUserAccountAndAddOrg(orgType);
            DoNotSignTheAgreement();
        }

        [When(@"an Employer creates a Levy Account and Signs the Agreement")]
        public void GivenAnEmployerCreatesALevyAccountAndSignsTheAgreement()
        {
            AddLevyDeclarations();
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsSigned(OrgType.Company);
        }

        [When(@"an Employer creates a Levy Account and not Signs the Agreement during registration")]
        public void WhenAnEmployerCreatesALevyAccountAndNotSignsTheAgreementDuringRegistration()
        {
            AddLevyDeclarations();
            GivenAnEmployerAccountWithSpecifiedTypeOrgIsCreatedAndAgeementIsNotSigned(OrgType.Company);
        }

        [Given(@"the Employer initiates adding another Org of (Company|PublicSector|Charity|Charity2) Type")]
        [When(@"the Employer initiates adding another Org of (Company|PublicSector|Charity|Charity2) Type")]
        public void WhenTheEmployerInitiatesAddingAnotherOrgType(OrgType orgType)
        {
            _checkYourDetailsPage = SearchForAnotherOrg(orgType)
                .SelectYourOrganisation(orgType);
        }

        [When(@"the Employer initiates adding another Org of 'ManuallyAddredOrg' Type")]
        public void WhenTheEmployerInitiatesAddingAnotherOrgOfManuallyAddredOrgType()
        {
            _homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton();

            WhenTheEmployerCreatesANewOrganisationAndAddsTheDetailsManually();
        }

        [When(@"the Employer initiates adding same Org of (Company|PublicSector|Charity) Type again")]
        public void WhenTheEmployerInitiatesAddingSameOrgTypeAgain(OrgType orgType) =>
            _selectYourOrganisationPage = SearchForAnotherOrg(orgType);

        [Then(@"the new Org added is shown in the Account Organisations list")]
        public void ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList()
        {
            _yourOrganisationsAndAgreementsPage = _checkYourDetailsPage.ClickYesContinueButton()
                                                        .GoToYourOrganisationsAndAgreementsPage()
                                                        .VerifyNewlyAddedOrgIsPresent();
        }

        [Then(@"'Already added' message is shown to the User")]
        public void ThenAlreadyAddedMessageIsShownToTheUser() =>
            _selectYourOrganisationPage.VerifyOrgAlreadyAddedMessage();

        [Then(@"the Employer is able check the details of the Charity Org added are displayed in the 'Check your details' page and Continue")]
        public void ThenTheEmployerIsAbleToCheckTheDetailsOfTheCharityOrgAddedAreDisplayedInThePageAndContinue() =>
            VerifyOrgDetailsAndContinue(_registrationDataHelper.CharityTypeOrg1Number, _registrationDataHelper.CharityTypeOrg1Name, _registrationDataHelper.CharityTypeOrg1Address);

        [Then(@"the Employer is able check the details of the 2nd Charity Org added are displayed in the 'Check your details' page and Continue")]
        public void ThenTheEmployerIsAbleToCheckTheDetailsOfThe2ndCharityOrgAddedAreDisplayedInThePageAndContinue() =>
            VerifyOrgDetailsAndContinue(_registrationDataHelper.CharityTypeOrg2Number, _registrationDataHelper.CharityTypeOrg2Name, _registrationDataHelper.CharityTypeOrg2Address);

        [Then(@"the Employer is able check the details entered in the 'Check your details' page and complete registration")]
        public void ThenTheEmployerChecksTheDetailsEnteredAndCompletesRegistration()
        {
            Assert.AreEqual(_registrationDataHelper.CharityTypeOrg3Number, _checkYourDetailsPage.GetManuallyAddedOrganisationNumber());
            Assert.AreEqual(_registrationDataHelper.CharityTypeOrg3Name, _checkYourDetailsPage.GetManuallyAddedOrganisationName());
            AssertManuallyAddedAddressDetailsAndCompleteRegistration();
        }

        [Then(@"the Employer is able check the details entered manually in the 'Check your details' page and complete registration")]
        public void ThenTheEmployerIsAbleCheckTheDetailsEnteredManuallyInThePageAndCompleteRegistration()
        {
            Assert.AreEqual(_registrationDataHelper.OrgNameForManualEntry, _checkYourDetailsPage.GetManuallyAddedOrganisationName());
            AssertManuallyAddedAddressDetailsAndCompleteRegistration();
        }

        [Then(@"ApprenticeshipEmployerType in Account table is marked as (.*)")]
        public void ThenApprenticeshipEmployerTypeInAccountTableIsMarkedAs(string expectedApprenticeshipEmployerType)
        {
            var actualApprenticeshipEmployerType = _registrationSqlDataHelper.GetAccountApprenticeshipEmployerType(_registrationDataHelper.RandomEmail);
            Assert.AreEqual(expectedApprenticeshipEmployerType, actualApprenticeshipEmployerType);
        }

        [When(@"Signs the Agreement from Account HomePage Panel")]
        public void WhenSignsTheAgreementFromAccountHomePagePanel()
        {
            _homePage.ClickAcceptYourAgreementLinkInHomePagePanel()
                .ClickContinueToYourAgreementButtonInAboutYourAgreementPage()
                .SignAgreement();
        }

        [When(@"an Employer initiates adding an Org of Charity Type Whose Address is Not in the Charity Commission database")]
        public void WhenAnEmployerInitiatesAddingAnOrgOfCharityTypeWhoseAddressIsNotInTheCharityCommissionDatabase()
            => CreateAnUserAcountAndAddPaye();

        [When(@"adds the Organisation address details manually")]
        public void WhenAddsTheOrganisationAddressDetailsManually()
        {
            _checkYourDetailsPage = _organistionSearchPage.SearchForAnOrganisation(_registrationDataHelper.CharityTypeOrg3Number)
                                        .SelectYourOrganisation(_registrationDataHelper.CharityTypeOrg3Name)
                                        .ClickEnterAddressManullyLinkInFindOrganisationAddressPage()
                                        .EnterAddressDetailsAndContinue();

            _objectContext.UpdateOrganisationName(_registrationDataHelper.CharityTypeOrg3Name);
        }

        [Then(@"'Start adding apprentices now' task link is displayed under Tasks pane")]
        public void ThenTaskLinkIsDisplayedUnderTasksPane() => _homePage.VerifyStartAddingApprenticesNowTaskLink();

        private void CreateUserAccountAndAddOrg(OrgType orgType)
        {
            CreateAnUserAcountAndAddPaye();
            AddOrganisationTypeDetails(orgType);
        }

        [Then(@"the Employer is Not allowed to Remove the first Org added")]
        public void ThenTheEmployerIsNotAllowedToRemoveTheFirstOrgAdded()
        {
            _homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickOnRemoveAnOrgFromYourAccountLink()
                .VerifyCantBeRemovedMessageTextOnRemoveAnOrganisationPage();

            _homePage = GoToHomePage();
        }

        [Then(@"Employer is Allowed to remove the second Org added from the account")]
        public void ThenEmployerIsAllowedToRemoveTheSecondOrgAddedFromTheAccount()
        {
            _yourOrganisationsAndAgreementsPage.ClickOnRemoveAnOrgFromYourAccountLink()
                .ClickOnRemoveLinkBesideNewlyAddedOrgInRemoveAnOrganisationPage()
                .SelectYesRadioOptionAndClickContinueInRemoveOrganisationPage()
                .VerifyOrgRemovedMessageInHeader();
        }

        [Then(@"'These details are already in use' page is displayed when Another Employer tries to register the account with the same Aorn and Paye details")]
        public void ThenPageIsDisplayedWhenAnotherEmployerTriesToRegisterTheAccountWithTheSameAornAndPayeDetails()
        {
            _homePage.SignOut().CickContinueInYouveLoggedOutPage();

            _objectContext.SetRegisteredEmail(_registrationDataHelper.AnotherRandomEmail);

            _addAPAYESchemePage = RegisterUser();

            _theseDetailsAreAlreadyInUsePage = ReEnterAornDetails();
        }

        [Then(@"'Add a PAYE Scheme' page is displayed when Employer clicks on 'Use different details' button")]
        public void ThenAddAPAYESchemePageIsDisplayedWhenEmployerClicksOnUseDifferentDetailsButton() =>
            _addAPAYESchemePage = _theseDetailsAreAlreadyInUsePage.CickUseDifferentDetailsButtonInTheseDetailsAreAlreadyInUsePage();

        [Then(@"'Add a PAYE Scheme' page is displayed when Employer clicks on Back link on the 'PAYE scheme already in use' page")]
        public void ThenAddAPAYESchemePageIsDisplayedWhenEmployerClicksOnBackLinkOnThePage() =>
            _addAPAYESchemePage = ReEnterAornDetails().CickBackLinkInTheseDetailsAreAlreadyInUsePage();

        [When(@"the User is on the 'Check your details' page after adding PAYE details through AORN route")]
        public void WhenTheUserIsOnTheCheckYourDetailsPageAfterAddingPAYEDetailsThroughAORNRoute()
        {
            _tprSqlDataHelper.CreateSingleOrgAornData();
            _checkYourDetailsPage = AddPayeDetailsForSingleOrgAornRoute();
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
            const string blankAornFieldErrorMessage = EnterYourPAYESchemeDetailsPage.BlankAornFieldErrorMessage;
            const string blankPayeFieldErrorMessage = EnterYourPAYESchemeDetailsPage.BlankPayeFieldErrorMessage;
            const string aornInvalidFormatErrorMessage = EnterYourPAYESchemeDetailsPage.AornInvalidFormatErrorMessage;
            const string payeInvalidFormatErrorMessage = EnterYourPAYESchemeDetailsPage.PayeInvalidFormatErrorMessage;

            switch (errorCase)
            {
                case "BlankAornAndBlankPaye":
                    _enterYourPAYESchemeDetailsPage.Continue();
                    Assert.AreEqual(blankAornFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAboveAornTextBox());
                    Assert.AreEqual(blankPayeFieldErrorMessage, _enterYourPAYESchemeDetailsPage.GetErrorMessageAbovePayeTextBox());
                    break;
                case "BlankAornValidPaye":
                    _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue("", _objectContext.GetGatewayPaye());
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
            const string InvalidErrorMessage1stAttempt = EnterYourPAYESchemeDetailsPage.InvalidAornAndPayeErrorMessage1stAttempt;
            const string InvalidErrorMessage2ndAttempt = EnterYourPAYESchemeDetailsPage.InvalidAornAndPayeErrorMessage2ndAttempt;

            EnterInvalidAornAndPaye();
            Assert.AreEqual(InvalidErrorMessage1stAttempt, _enterYourPAYESchemeDetailsPage.GetInvalidAornAndPayeErrorMessage());
            EnterInvalidAornAndPaye();
            Assert.AreEqual(InvalidErrorMessage2ndAttempt, _enterYourPAYESchemeDetailsPage.GetInvalidAornAndPayeErrorMessage());
            EnterInvalidAornAndPaye();

            _usingYourGovtGatewayDetailsPage = new SorryAccountDisabledPage(_context)
                .ClickAddViaGGLink();
        }

        [Then(@"Employer is able to complete registration through GG route")]
        public void ThenEmployerIsAbleToCompleteRegistrationThroughGGRoute()
        {
            _organistionSearchPage = _usingYourGovtGatewayDetailsPage.ContinueToGGSignIn().SignInTo();
            AddOrganisationDetails();
            SignTheAgreement();
        }

        [When(@"an User tries to regiser an Account with email an e-mail already registered")]
        public void WhenAnUserTriesToRegiserAnAccountWithEmailAnE_MailAlreadyRegistered()
        {
            _setUpAsAUserPage = new IndexPage(_context)
                .CreateAccount()
                .EnterRegistrationDetailsAndContinue(_context.GetUser<LevyUser>().Username);
        }

        [Then(@"'Email already regisered' message is shown to the User")]
        public void ThenMessageIsShownToTheUser() => _setUpAsAUserPage.VerifyEmailAlreadyRegisteredErrorMessage();

        private void EnterInvalidAornAndPaye() =>
            _enterYourPAYESchemeDetailsPage.EnterAornAndPayeAndContinue(_registrationDataHelper.InvalidAornNumber, _registrationDataHelper.InvalidPaye);

        private void CreateAnUserAcountAndAddPaye()
        {
            AnUserAccountIsCreated();
            AddPayeDetails();
        }

        private SelectYourOrganisationPage SearchForAnotherOrg(OrgType orgType)
        {
            return _homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(orgType);
        }

        private void AddLevyDeclarations() => new BackgroundDataSteps(_context).GivenLevyDeclarationsIsAddedForPastMonthsWithLevypermonthAs("5", "10000");

        private void VerifyOrgDetailsAndContinue(string orgNumber, string OrgName, string orgAddress)
        {
            Assert.AreEqual(orgNumber, _checkYourDetailsPage.GetOrganisationNumber());
            Assert.AreEqual(OrgName, _checkYourDetailsPage.GetOrganisationName());
            Assert.AreEqual(orgAddress, _checkYourDetailsPage.GetOrganisationAddress());

            ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList();
        }

        private void AssertManuallyAddedAddressDetailsAndCompleteRegistration()
        {
            var manuallyEnteredAddress = $"{_registrationDataHelper.FirstLineAddressForManualEntry} " +
                                            $"{_registrationDataHelper.CityNameForManualEntry} " +
                                            $"{_registrationDataHelper.PostCodeForManualEntry}";
            Assert.AreEqual(manuallyEnteredAddress, _checkYourDetailsPage.GetManuallyAddedOrganisationAddress());

            _checkYourDetailsPage.ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                        .SelectViewAgreementNowAndContinue()
                        .SignAgreement();
        }

        private CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute() =>
            _addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        private AddAPAYESchemePage RegisterUser()
        {
            return new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding();
        }

        private TheseDetailsAreAlreadyInUsePage ReEnterAornDetails() => _addAPAYESchemePage.AddAORN()
                .ReEnterTheSameAornDetailsAndContinue();

        private HomePage GoToHomePage() => new HomePage(_context, true);
    }
}

