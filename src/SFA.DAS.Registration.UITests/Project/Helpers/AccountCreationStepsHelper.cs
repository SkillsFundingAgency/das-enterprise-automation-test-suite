using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly MongoDbDataGenerator _mongoDbDataGenerator;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;
        private readonly ObjectContext _objectContext;

        public AccountCreationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);
            _objectContext = _context.Get<ObjectContext>();
        }

        public ConfirmPage RegisterUserAccount() => new IndexPage(_context).CreateAccount().Register();

        public SelectYourOrganisationPage SearchForAnotherOrg(HomePage homepage, OrgType orgType)
        {
            return homepage.GoToYourOrganisationsAndAgreementsPage()
                .ClickAddNewOrganisationButton()
                .SearchForAnOrganisation(orgType);
        }

        public void AddLevyDeclarations()
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds("5", "10000");
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
            _loginCredentialsHelper.SetIsLevy();
        }

        public void AssertManuallyAddedAddressDetailsAndCompleteRegistration(CheckYourDetailsPage checkYourDetailsPage)
        {
            var manuallyEnteredAddress = $"{_registrationDataHelper.FirstLineAddressForManualEntry} " +
                                            $"{_registrationDataHelper.CityNameForManualEntry} " +
                                            $"{_registrationDataHelper.PostCodeForManualEntry}";
            Assert.AreEqual(manuallyEnteredAddress, checkYourDetailsPage.GetManuallyAddedOrganisationAddress());

            checkYourDetailsPage.ClickYesTheseDetailsAreCorrectButtonInCheckYourDetailsPage()
                        .SelectViewAgreementNowAndContinue()
                        .SignAgreement();
        }

        public CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        public TheseDetailsAreAlreadyInUsePage ReEnterAornDetails(AddAPAYESchemePage addAPAYESchemePage) => addAPAYESchemePage.AddAORN()
                .ReEnterTheSameAornDetailsAndContinue();

        public IndexPage SignOut() => new HomePage(_context, true).SignOut().CickContinueInYouveLoggedOutPage();

        public CheckYourDetailsPage SearchAndSelectOrg(SearchForYourOrganisationPage searchForYourOrganistionPage, OrgType org) =>
            searchForYourOrganistionPage.SearchForAnOrganisation(org).SelectYourOrganisation(org);

        public SearchForYourOrganisationPage AddADifferentPaye(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo(1);

        public AddAPAYESchemePage CreateAnotherUserAccount(IndexPage indexPage) =>
            indexPage.CreateAccount()
                .Register(_registrationDataHelper.AnotherRandomEmail)
                .EnterAccessCode()
                .ContinueToGetApprenticeshipFunding();

        public HomePage AddAnotherPayeSchemeToTheAccount(HomePage homePage) =>
            homePage.GotoPAYESchemesPage()
                .ClickAddNewSchemeButton()
                .ContinueToGGSignIn()
                .EnterPayeDetailsAndContinue(1)
                .ClickContinueInConfirmPAYESchemePage()
                .SelectContinueAccountSetupInPAYESchemeAddedPage();

        public PAYESchemesPage RemovePayeSchemeFromTheAccount(HomePage homePage) =>
            homePage.GotoPAYESchemesPage()
                .ClickNewlyAddedPayeDetailsLink()
                .ClickRemovePAYESchemeButton()
                .SelectYesRadioButtonAndContinue()
                .VerifyPayeSchemeRemovedInfoMessage();

        public HomePage AddNewAccount(HomePage homePage, OrgType orgType, int index)
        {
            _objectContext.SetSecondAccountOrganisationName(GetOrgName(orgType));

            return homePage.GoToYourAccountsPage().AddNewAccount()
                 .ContinueToGGSignIn()
                 .SignInTo(index)
                 .SearchForAnOrganisation(orgType)
                 .SelectYourOrganisation(orgType)
                 .ContinueToAboutYourAgreementPage()
                 .SelectViewAgreementNowAndContinue()
                 .SignAgreement();
        }

        public void SetFirstAccountOrganisationName(OrgType orgType) =>
            _objectContext.SetFirstAccountOrganisationName(GetOrgName(orgType));

        private string GetOrgName(OrgType orgType)
        {
            switch (orgType)
            {
                case OrgType.Company:
                    return _registrationDataHelper.CompanyTypeOrg;
                case OrgType.PublicSector:
                    return _registrationDataHelper.PublicSectorTypeOrg;
                default:
                    return _registrationDataHelper.CharityTypeOrg1Name;
            }
        }
    }
}
