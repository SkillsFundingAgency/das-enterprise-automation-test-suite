using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.PAYESchemesPages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;
using static SFA.DAS.Registration.UITests.Project.Helpers.EnumHelper;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationStepsHelper(ScenarioContext context)
    {
        private readonly RegistrationDataHelper _registrationDataHelper = context.Get<RegistrationDataHelper>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly AccountSignOutHelper _accountSignOutHelper = new(context);

        public HomePage CreateUserAccount() => AddNewAccount(RegisterUserAccount(), 0);

        public HomePage AddNewAccount(HomePage homePage, int index, OrgType orgType = OrgType.Default)
        {
            _objectContext.SetAdditionalOrganisationName(GetOrgName(orgType), index);

            return AddNewAccount(homePage.GoToYourAccountsPage().AddNewAccount(), index, orgType);
        }

        internal AddAPAYESchemePage RegisterUserAccount() =>
            RegisterUserAccount(new CreateAnAccountToManageApprenticeshipsPage(context), null);

        internal AddAPAYESchemePage RegisterUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterStubUserAccount(indexPage, email).EnterNameAndContinue(_registrationDataHelper).ConfirmNameAndContinue().ClickContinueButtonToAcknowledge().GoToAddPayeLink().SelectOptionLessThan3Million();

        internal HomePage AcceptUserInvite(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterStubUserAccount(indexPage, email).EnterNameAndContinue(_registrationDataHelper).ConfirmNameAndContinue().ClickContinueToInvitationsPage().ClickAcceptInviteLink();

        internal static StubAddYourUserDetailsPage RegisterUserAccount(StubSignInEmployerPage stubSignInPage, string email) => stubSignInPage.Register(email).ContinueToStubAddYourUserDetailsPage();

        internal static SelectYourOrganisationPage SearchForAnotherOrg(HomePage homepage, OrgType orgType) =>
            homepage.GoToYourOrganisationsAndAgreementsPage().ClickAddNewOrganisationButton().SearchForAnOrganisation(orgType);

        internal static CheckYourDetailsPage AddPayeDetailsForSingleOrgAornRoute(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().EnterAornAndPayeDetailsForSingleOrgScenarioAndContinue();

        internal static TheseDetailsAreAlreadyInUsePage ReEnterAornDetails(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddAORN().ReEnterTheSameAornDetailsAndContinue();

        internal CreateAnAccountToManageApprenticeshipsPage SignOut() => _accountSignOutHelper.SignOut();

        internal static CheckYourDetailsPage SearchAndSelectOrg(SearchForYourOrganisationPage searchForYourOrganistionPage, OrgType org) =>
            searchForYourOrganistionPage.SearchForAnOrganisation(org).SelectYourOrganisation(org);

        internal static SearchForYourOrganisationPage AddADifferentPaye(AddAPAYESchemePage addAPAYESchemePage) =>
            addAPAYESchemePage.AddPaye().ContinueToGGSignIn().SignInTo(1);

        internal AddAPAYESchemePage CreateAnotherUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage) => CreateUserAccount(indexPage, _registrationDataHelper.AnotherRandomEmail);

        internal AddAPAYESchemePage CreateUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) =>
            RegisterUserAccount(indexPage, email);

        internal static HomePage AddAnotherPayeSchemeToTheAccount(HomePage homePage) =>
            homePage
            .GotoPAYESchemesPage()
            .ClickAddNewSchemeButton()
            .ContinueToGGSignIn()
            .EnterPayeDetailsAndContinue(1)
            .ClickContinueInConfirmPAYESchemePage()
            .SelectContinueAccountSetupInPAYESchemeAddedPage();

        internal static PAYESchemesPage RemovePayeSchemeFromTheAccount(HomePage homePage) =>
            homePage
            .GotoPAYESchemesPage()
            .ClickNewlyAddedPayeDetailsLink()
            .ClickRemovePAYESchemeButton()
            .SelectYesRadioButtonAndContinue()
            .VerifyPayeSchemeRemovedInfoMessage();

        internal static HomePage AddNewAccount(AddAPAYESchemePage addAPAYESchemePage, int index, OrgType orgType = OrgType.Default) =>
            GoToSignAgreementPage(addAPAYESchemePage
            .AddPaye()
            .ContinueToGGSignIn()
            .SignInTo(index)
            .SearchForAnOrganisation(orgType)
            .SelectYourOrganisation(orgType))
            .SignAgreement()
            .SelectContinueToCreateYourEmployerAccount()
            .GoToTrainingProviderLink()
            .AddTrainingProviderLater()
            .SelectGoToYourEmployerAccountHomepage();


        internal static DoYouAcceptTheEmployerAgreementOnBehalfOfPage GoToSignAgreementPage(CheckYourDetailsPage checkYourDetailsPage)
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

        internal static YouHaveAcceptedTheEmployerAgreementPage SignAgreementFromHomePage(HomePage homePage) =>
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

        private static StubAddYourUserDetailsPage RegisterStubUserAccount(CreateAnAccountToManageApprenticeshipsPage indexPage, string email) => RegisterUserAccount(indexPage.ClickOnCreateAccountLink(), email);
    }
}
