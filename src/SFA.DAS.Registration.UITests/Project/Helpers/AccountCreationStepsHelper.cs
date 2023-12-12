using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationDataHelper _registrationDataHelper;
        private readonly ObjectContext _objectContext;
        private readonly AccountSignOutHelper _accountSignOutHelper;

        public AccountCreationStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _registrationDataHelper = context.Get<RegistrationDataHelper>();
            _accountSignOutHelper = new AccountSignOutHelper(context);
        }

        public HomePage CreateUserAccount() => AddNewAccount(RegisterUserAccount(), 0);

        public HomePage AddNewAccount(HomePage homePage, int index, OrgType orgType = OrgType.Default)
        {
            _objectContext.SetAdditionalOrganisationName(GetOrgName(orgType), index);

            return AddNewAccount(homePage.GoToYourAccountsPage().AddNewAccount(), index, orgType);
        }

        internal AddAPAYESchemePage RegisterUserAccount() =>
            RegisterUserAccount(new CreateAnAccountToManageApprenticeshipsPage(_context), null);

        internal AddAPAYESchemePage RegisterUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterStubUserAccount(indexPage, email).EnterNameAndContinue(_registrationDataHelper).ConfirmNameAndContinue().ClickContinueButtonToAcknowledge().GoToAddPayeLink().SelectOptionLessThan3Million();

        internal HomePage AcceptUserInvite(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterStubUserAccount(indexPage, email).EnterNameAndContinue(_registrationDataHelper).ConfirmNameAndContinue().ClickContinueToInvitationsPage().ClickAcceptInviteLink();

        internal StubAddYourUserDetailsPage RegisterUserAccount(StubSignInEmployerPage stubSignInPage, string email) => stubSignInPage.Register(email).ContinueToStubAddYourUserDetailsPage();

        internal SelectYourOrganisationPage SearchForAnotherOrg(HomePage homepage, OrgType orgType) =>
            homepage.GoToYourOrganisationsAndAgreementsPage().ClickAddNewOrganisationButton().SearchForAnOrganisation(orgType);

        internal CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        internal TheseDetailsAreAlreadyInUsePage ReEnterAornDetails(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().ReEnterTheSameAornDetailsAndContinue();

        internal CreateAnAccountToManageApprenticeshipsPage SignOut() => _accountSignOutHelper.SignOut();

        internal CheckYourDetailsPage SearchAndSelectOrg(SearchForYourOrganisationPage searchForYourOrganistionPage, OrgType org) =>
            searchForYourOrganistionPage.SearchForAnOrganisation(org).SelectYourOrganisation(org);

        internal SearchForYourOrganisationPage AddADifferentPaye(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo(1);

        internal AddAPAYESchemePage CreateAnotherUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage) => CreateUserAccount(indexPage, _registrationDataHelper.AnotherRandomEmail);

        internal AddAPAYESchemePage CreateUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterUserAccount(indexPage, email);

        internal HomePage AddAnotherPayeSchemeToTheAccount(HomePage homePage) =>
            homePage
            .GotoPAYESchemesPage()
            .ClickAddNewSchemeButton()
            .ContinueToGGSignIn()
            .EnterPayeDetailsAndContinue(1)
            .ClickContinueInConfirmPAYESchemePage()
            .SelectContinueAccountSetupInPAYESchemeAddedPage();

        internal PAYESchemesPage RemovePayeSchemeFromTheAccount(HomePage homePage) =>
            homePage
            .GotoPAYESchemesPage()
            .ClickNewlyAddedPayeDetailsLink()
            .ClickRemovePAYESchemeButton()
            .SelectYesRadioButtonAndContinue()
            .VerifyPayeSchemeRemovedInfoMessage();

        internal HomePage AddNewAccount(AddAPAYESchemePage addAPAYESchemePage, int index, OrgType orgType = OrgType.Default) =>
            GoToSignAgreementPage(addAPAYESchemePage
            .AddPaye()
            .ContinueToGGSignIn()
            .SignInTo(index)
            .SearchForAnOrganisation(orgType)
            .SelectYourOrganisation(orgType))
            .SignAgreement()
            .GoToTrainingProviderLink()
            .AddTrainingProviderLater()
            .SelectGoToYourEmployerAccountHomepage();


        internal DoYouAcceptTheEmployerAgreementOnBehalfOfPage GoToSignAgreementPage(CheckYourDetailsPage checkYourDetailsPage)
        {
            return checkYourDetailsPage
                .ClickYesThisIsMyOrg()
                .ContinueToConfirmationPage()
                .GoToSetYourAccountNameLink()
                .SelectoptionNo()
                .ContinueToAcknowledge()
                .GoToYourEmployerAgreementLink()
                .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage();
        }

        internal YouHaveAcceptedTheEmployerAgreementPage SignAgreementFromHomePage(HomePage homePage) =>
            homePage.ClickAcceptYourAgreementLinkInHomePagePanel().ClickContinueToYourAgreementButtonInAboutYourAgreementPage().SignAgreement();

        internal void UpdateOrganisationName(OrgType orgType) => _objectContext.UpdateOrganisationName(GetOrgName(orgType));

        private string GetOrgName(OrgType orgType)
        {
            return orgType switch
            {
                OrgType.Company => _registrationDataHelper.CompanyTypeOrg,
                OrgType.PublicSector => _registrationDataHelper.PublicSectorTypeOrg,
                _ => _registrationDataHelper.CharityTypeOrg1Name,
            };
        }

        private StubAddYourUserDetailsPage RegisterStubUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) => RegisterUserAccount(indexPage.ClickOnCreateAccountLink(), email);
    }
}
