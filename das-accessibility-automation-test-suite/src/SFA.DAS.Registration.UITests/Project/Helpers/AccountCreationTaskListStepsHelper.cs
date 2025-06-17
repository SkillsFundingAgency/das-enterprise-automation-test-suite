namespace SFA.DAS.Registration.UITests.Project.Helpers;

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

    internal static CreateYourEmployerAccountPage AddPAYEFromTaskListForCloseTo3Million(CreateYourEmployerAccountPage createEmployerAccountPage) =>
     createEmployerAccountPage.GoToAddPayeLink()
        .SelectOptionCloseTo3Million()
        .AgreeAndContinue()
        .SignInTo(0)
        .SearchForAnOrganisation()
        .SelectYourOrganisation()
        .ClickYesThisIsMyOrg().ContinueToConfirmationPage();

    internal static CreateYourEmployerAccountPage ConfirmEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
       createEmployerAccountPage.GoToSetYourAccountNameLink().SelectoptionToSkipNameChange().ContinueToAcknowledge();

    internal CreateYourEmployerAccountPage UpdateEmployerAccountName(CreateYourEmployerAccountPage createEmployerAccountPage) =>
       createEmployerAccountPage.GoToSetYourAccountNameLink()
        .SelectoptionToChangeAccountName(_registrationDataHelper.CompanyTypeOrg2)
        .ContinueToAcknowledge(_registrationDataHelper.CompanyTypeOrg2)
        .ContinueToCreateYourEmployerAccountPage();

    internal static CreateYourEmployerAccountPage AcceptEmployerAgreement(CreateYourEmployerAccountPage createEmployerAccountPage) =>
      createEmployerAccountPage.GoToYourEmployerAgreementLink()
        .ClickContinueToYourAgreementButtonToDoYouAcceptTheEmployerAgreementPage()
        .SignAgreement()
        .SelectContinueToCreateYourEmployerAccount();

    internal static HomePage AddTrainingProviderAndGrantPermission(CreateYourEmployerAccountPage createEmployerAccountPage, ProviderConfig providerConfig) =>
     createEmployerAccountPage.GoToTrainingProviderLink()
       .AddTrainingProviderNow()
       .SearchForATrainingProvider(providerConfig)
       .AddOrSetPermissionsAndCreateAccount((AddApprenticePermissions.YesAddApprenticeRecords, RecruitApprenticePermissions.YesRecruitApprentices))
       .SelectGoToYourEmployerAccountHomepage();
}
