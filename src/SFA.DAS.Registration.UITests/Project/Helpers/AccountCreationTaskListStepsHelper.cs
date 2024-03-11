using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class AccountCreationTaskListStepsHelper(ScenarioContext context)
    {
        private readonly RegistrationDataHelper _registrationDataHelper = context.Get<RegistrationDataHelper>();

        internal ConfirmYourUserDetailsPage UserEntersNameAndContinue(StubAddYourUserDetailsPage stubUserDetailsPage) => stubUserDetailsPage.EnterNameAndContinue(_registrationDataHelper);

        internal ConfirmYourUserDetailsPage UserChangesUserDetails(ConfirmYourUserDetailsPage confirmDetailsPage) =>
           confirmDetailsPage.ClickChange().EnterNameAndContinue(_registrationDataHelper);

        internal static CreateYourEmployerAccountPage UserClicksContinueButtonToAcknowledge(ConfirmYourUserDetailsPage confirmDetailsPage) =>
          confirmDetailsPage.ConfirmNameAndContinue().ClickContinueButtonToAcknowledge();

        internal static CreateYourEmployerAccountPage UserChangesDetailsFromTaskList(CreateYourEmployerAccountPage confirmDetailsPage) =>
         confirmDetailsPage.GoToAddYouUserDetailsLink().EnterName().ConfirmNameAndContinue(true).ClickContinueButtonToAcknowledge();

        internal static CreateYourEmployerAccountPage UserCanClickAddAPAYEScheme(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToAddPayeLink().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage UserCannotAmendPAYEScheme(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToAddPayeLinkWhenAlreadyAdded().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage UserCanClickAddAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToSetYourAccountNameLink().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage UserCannotClickAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.AccountNameItemText);

        internal static CreateYourEmployerAccountPage UserCannotClickAcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.EmployerAgreementItemText);

        internal static CreateYourEmployerAccountPage UserCanClickAcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToYourEmployerAgreementLink().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage UserAcknowledgesEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .DoNotSignAgreement();

        internal static CreateYourEmployerAccountPage UserCannotClickTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.TrainingProviderItemText);

        internal static CreateYourEmployerAccountPage UserCanClickTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage) =>
        createEmployerAccountPage.GoToTrainingProviderLink().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage UserCannotClickTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.VerifyStepCannotBeStartedYet(CreateYourEmployerAccountPage.TrainingProviderPermissionsItemText);

        internal static CreateYourEmployerAccountPage UserCanClickTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
        createEmployerAccountPage.GoToTrainingProviderPermissionsLink().GoBackToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage AddPAYEFromTaskListForCloseTo3Million(CreateYourEmployerAccountPage createEmployerAccountPage) =>
         createEmployerAccountPage.GoToAddPayeLink()
            .SelectOptionCloseTo3Million()
            .AgreeAndContinue()
            .SignInTo(0)
            .SearchForAnOrganisation()
            .SelectYourOrganisation()
            .ClickYesThisIsMyOrg().ContinueToConfirmationPage();

        internal static CreateYourEmployerAccountPage ConfirmEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToSetYourAccountNameLink().SelectoptionYes().ContinueToAcknowledge();

        internal CreateYourEmployerAccountPage UpdateEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
           createEmployerAccountPage.GoToSetYourAccountNameLink()
            .SelectoptionNo(_registrationDataHelper.CompanyTypeOrg2)
            .ContinueToAcknowledge(_registrationDataHelper.CompanyTypeOrg2)
            .ContinueToCreateYourEmployerAccountPage();

        internal static CreateYourEmployerAccountPage AcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .SignAgreement()
            .SelectContinueToCreateYourEmployerAccount();

        internal static CreateYourEmployerAccountPage AcceptEmployerAgreementWhenAlreadyAcknowledged(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToYourEmployerAgreementLink()
            .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
            .SignAgreementHavingAlreadyAcknowledged()
            .ClickOnViewYourAccountButtonToReturnToTaskList();

        internal static CreateYourEmployerAccountPage AddTrainingProvider(CreateYourEmployerAccountPage createEmployerAccountPage, string ukprn) =>
         createEmployerAccountPage.GoToTrainingProviderLink()
           .AddTrainingProviderNow()
           .SelectAddATrainingProvider()
           .SearchForATrainingProvider(ukprn)
           .ConfirmTrainingProvider()
           .SelectSaveAndComeBackLater()
           .SelectContinueCreatingYourAccount();

        internal static HomePage GrantTrainingProviderPermissions(CreateYourEmployerAccountPage createEmployerAccountPage) =>
          createEmployerAccountPage.GoToTrainingProviderPermissionsLink()
            .SelectSetPermissions(string.Empty)
            .ClickAddApprentice(AddApprenticePermissions.Allow)
            .ClickRecruitApprentice(RecruitApprenticePermissions.Allow)
            .ConfirmAndGoToEmployerAccountCreatedPage()
            .GoToHomePage();

    }
}
