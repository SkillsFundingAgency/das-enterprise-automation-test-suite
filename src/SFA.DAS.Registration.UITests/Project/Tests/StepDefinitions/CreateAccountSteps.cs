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
        private readonly RegistrationDatahelpers _registrationDataHelper;
        private HomePage _homePage;
        private AddAPAYESchemePage _addAPAYESchemePage;
        private GgSignInPage _gGSignInPage;
        private OrganisationSearchPage _organistionSearchPage;
        private SelectYourOrganisationPage _selectYourOrganisationPage;
        private SignAgreementPage _signAgreementPage;
        private OrganisationHasBeenAddedPage _organisationHasBeenAddedPage;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;

        public CreateAccountSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDatahelpers>();
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

        [When(@"enters an Invalid Company number for Org search")]
        public void WhenEntersAnInvalidCompanyNumberForOrgSearch()
        {
            _selectYourOrganisationPage = _organistionSearchPage.SearchForAnOrganisation(_registrationDataHelper.InvalidCompanyNumber);
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

        private void CreateUserAccountAndAddOrg(OrgType orgType)
        {
            AnUserAccountIsCreated();
            AddPayeDetails();
            AddOrganisationTypeDetails(orgType);
        }

        [When(@"the Employer initiates adding another Org of (Company|PublicSector|Charity) Type")]
        public void WhenTheEmployerInitiatesAddingAnotherOrgType(OrgType orgType)
        {
            _organisationHasBeenAddedPage = SearchForAnotherOrg(orgType)
                .SelectYourOrganisation(orgType)
                .ClickYesContinueButton();
        }

        [When(@"the Employer initiates adding another same Org of (Company|PublicSector|Charity) Type again")]
        public void WhenTheEmployerInitiatesAddingAnotherSameOrgTypeAgain(OrgType orgType) =>
            _selectYourOrganisationPage = SearchForAnotherOrg(orgType);

        [Then(@"the new Org added is shown in the Account Organisations list")]
        public void ThenTheNewOrgAddedIsShownInTheAccountOrganisationsList()
        {
            _organisationHasBeenAddedPage
            .GoToYourOrganisationsAndAgreementsPage()
            .VerifyNewlyAddedOrgIsPresent();
        }

        [Then(@"'Already added' message is shown to the User")]
        public void ThenAlreadyAddedMessageIsShownToTheUser() =>
            _selectYourOrganisationPage.VerifyOrgAlreadyAddedMessage(_registrationDataHelper.PublicSectorTypeOrg);

        private SelectYourOrganisationPage SearchForAnotherOrg(OrgType orgType)
        {
            return _homePage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(orgType);
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
    }
}
