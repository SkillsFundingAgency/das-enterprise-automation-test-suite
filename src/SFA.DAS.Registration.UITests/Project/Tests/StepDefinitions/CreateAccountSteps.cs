using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
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
        private HomePage _homePage;
        private AddAPAYESchemePage _addAPAYESchemePage;
        private GgSignInPage _gGSignInPage;
        private OrganisationSearchPage _organistionSearchPage;
        private SelectYourOrganisationPage _selectYourOrganisationPage;
        private SignAgreementPage _signAgreementPage;
        private CheckYourDetailsPage _checkYourDetailsPage;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        }

        [Given(@"an User Account is created")]
        [When(@"an User Account is created")]
        public void AnUserAccountIsCreated()
        {
            TestContext.Progress.WriteLine($"Email : {_registrationDataHelper.RandomEmail}");

            _addAPAYESchemePage = new IndexPage(_context)
                .CreateAccount()
                .Register()
                .ContinueToGetApprenticeshipFunding();
        }

        [Then(@"My Account Home page is displayed when PAYE details are not added")]
        public void DoNotAddPayeDetails()
        {
            _addAPAYESchemePage.DoNotAddPaye();
        }

        [Given(@"the User adds PAYE details")]
        [When(@"the User adds PAYE details")]
        [When(@"the User adds valid PAYE details")]
        public void AddPayeDetails()
        {
            _organistionSearchPage = _addAPAYESchemePage
                .AddPaye().ContinueToGGSignIn()
                .SignInTo();
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
            _checkYourDetailsPage = WhenEntersAnInvalidCompanyNumberForOrgSearch()
                .ClickEnterYourDetailsManuallyLink()
                .EnterOrganisationNameAndContinue()
                .ClickEnterAddressManullyLink()
                .EnterAddressDetailsAndContinue();

            _objectContext.UpdateOrganisationName(_registrationDataHelper.ManuallyAddedOrgName);

            return new CheckYourDetailsPage(_context);
        }


        [When(@"enters an Invalid Company number for Org search")]
        public SelectYourOrganisationPage WhenEntersAnInvalidCompanyNumberForOrgSearch()
        {
            _selectYourOrganisationPage = _organistionSearchPage.SearchForAnOrganisation(_registrationDataHelper.InvalidCompanyNumber);
            return new SelectYourOrganisationPage(_context);
        }

        [Then(@"the '(.*)' message is shown")]
        public void ThenTheMessageIsShown(string resultMessage)
        {
            Assert.AreEqual(resultMessage, _selectYourOrganisationPage.GetSearchResultsText());
        }

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
            _checkYourDetailsPage
                .ClickYesContinueButton()
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
            AssertManuallyAddedAddressDetails();

            ContinueInCheckYourDetailsPageAndCompleteRegistration();
        }

        [Then(@"the Employer is able check the details entered manually in the 'Check your details' page and complete registration")]
        public void ThenTheEmployerIsAbleCheckTheDetailsEnteredManuallyInThePageAndCompleteRegistration()
        {
            Assert.AreEqual(_registrationDataHelper.ManuallyAddedOrgName, _checkYourDetailsPage.GetManuallyAddedOrganisationName());
            AssertManuallyAddedAddressDetails();
            ContinueInCheckYourDetailsPageAndCompleteRegistration();
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
                                        .ClickEnterAddressManullyLink()
                                        .EnterAddressDetailsAndContinue();

            _objectContext.UpdateOrganisationName(_registrationDataHelper.CharityTypeOrg3Name);
        }

        private void CreateUserAccountAndAddOrg(OrgType orgType)
        {
            CreateAnUserAcountAndAddPaye();
            AddOrganisationTypeDetails(orgType);
        }

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

        private void ContinueInCheckYourDetailsPageAndCompleteRegistration()
        {
            _checkYourDetailsPage.ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                        .SelectViewAgreementNowAndContinue()
                        .SignAgreement();
        }

        private void AssertManuallyAddedAddressDetails()
        {
            var manuallyEnteredAddress = $"{_registrationDataHelper.CharityTypeOrg3FirstLineAddressForEnteringManually} " +
                                            $"{_registrationDataHelper.CharityTypeOrg3CityForEnteringManually} " +
                                            $"{_registrationDataHelper.CharityTypeOrg3PostCodeForEnteringManually}";
            Assert.AreEqual(manuallyEnteredAddress, _checkYourDetailsPage.GetManuallyAddedOrganisationAddress());
        }
    }
}
