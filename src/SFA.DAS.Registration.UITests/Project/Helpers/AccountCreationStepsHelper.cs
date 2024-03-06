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


        internal StubAddYourUserDetailsPage UserLogsIntoStub()
        {
            return RegisterStubUserAccount(new CreateAnAccountToManageApprenticeshipsPage(context), null);
        }

        internal ConfirmYourUserDetailsPage UserEntersNameAndContinue(StubAddYourUserDetailsPage stubUserDetailsPage)
        {
            return stubUserDetailsPage.EnterNameAndContinue(_registrationDataHelper);
        }


        internal ConfirmYourUserDetailsPage UserChangesUserDetails(ConfirmYourUserDetailsPage confirmDetailsPage) =>
           confirmDetailsPage.ClickChange().EnterNameAndContinue(_registrationDataHelper);

        internal CreateYourEmployerAccountPage UserClicksContinueButtonToAcknowledge(ConfirmYourUserDetailsPage confirmDetailsPage) =>
          confirmDetailsPage.ConfirmNameAndContinue().ClickContinueButtonToAcknowledge();

        internal CreateYourEmployerAccountPage UserChangesDetailsFromTaskList(CreateYourEmployerAccountPage confirmDetailsPage) =>
         confirmDetailsPage.GoToAddYouUserDetailsLink().EnterName().ConfirmNameAndContinue(true).ClickContinueButtonToAcknowledge();

        internal CreateYourEmployerAccountPage UserCanClickAddAPAYEScheme(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToAddPayeLink().GoBackToCreateYourEmployerAccountPage();

        internal CreateYourEmployerAccountPage UserCannotAmendPAYEScheme(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToAddPayeLinkWhenAlreadyAdded().GoBackToCreateYourEmployerAccountPage();

        internal CreateYourEmployerAccountPage UserCanClickAddAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToSetYourAccountNameLink().GoBackToCreateYourEmployerAccountPage();

        internal CreateYourEmployerAccountPage UserCannotClickAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.AccountNameItemText);

        internal CreateYourEmployerAccountPage UserCannotClickAcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.EmployerAgreementItemText);

        internal CreateYourEmployerAccountPage UserCanClickAcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToYourEmployerAgreementLink().GoBackToCreateYourEmployerAccountPage();
       
        internal CreateYourEmployerAccountPage UserAcknowledgesEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .DoNotSignAgreement();

        internal CreateYourEmployerAccountPage UserCannotClickTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.TrainingProviderItemText);

        internal CreateYourEmployerAccountPage UserCanClickTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage) =>
        createEmployerAccountPage.GoToTrainingProviderLink().GoBackToCreateYourEmployerAccountPage();

        internal CreateYourEmployerAccountPage UserCannotClickTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.TrainingProviderPermissionsItemText);

        internal CreateYourEmployerAccountPage UserCanClickTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
        createEmployerAccountPage.GoToTrainingProviderPermissionsLink().GoBackToCreateYourEmployerAccountPage();      

        internal CreateYourEmployerAccountPage AddPAYEFromTaskListForCloseTo3Million(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToAddPayeLink()
            .SelectOptionCloseTo3Million()
            .AgreeAndContinue()
            .SignInTo(0)
            .SearchForAnOrganisation()
            .SelectYourOrganisation()
            .ClickYesThisIsMyOrg().ContinueToConfirmationPage();

        internal CreateYourEmployerAccountPage ConfirmEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToSetYourAccountNameLink().SelectoptionYes().ContinueToAcknowledge();
        
        internal CreateYourEmployerAccountPage UpdateEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToSetYourAccountNameLink()
            .SelectoptionNo(_registrationDataHelper.CompanyTypeOrg2)
            .ContinueToAcknowledge(_registrationDataHelper.CompanyTypeOrg2)
            .ContinueToCreateYourEmployerAccountPage();

        internal CreateYourEmployerAccountPage AcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .SignAgreement()
            .SelectContinueToCreateYourEmployerAccount();

        internal CreateYourEmployerAccountPage AcceptEmployerAgreementWhenAlreadyAcknowledged(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .SignAgreementHavingAlreadyAcknowledged()
            .ClickOnViewYourAccountButtonToReturnToTaskList();

        internal CreateYourEmployerAccountPage AddTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage, string ukprn) =>
         createEmployerAccountPage.GoToTrainingProviderLink()
           .AddTrainingProviderNow()
           .SelectAddATrainingProvider()
           .SearchForATrainingProvider(ukprn)
           .ConfirmTrainingProvider()
           .SelectSaveAndComeBackLater()
           .SelectContinueCreatingYourAccount();

        internal HomePage GrantTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToTrainingProviderPermissionsLink()
            .SelectSetPermissions(string.Empty)
            .ClickAddApprentice(AddApprenticePermissions.Allow)
            .ClickRecruitApprentice(RecruitApprenticePermissions.Allow)
            .ConfirmAndGoToEmployerAccountCreatedPage()
            .GoToHomePage();

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
                .SelectoptionYes()
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
