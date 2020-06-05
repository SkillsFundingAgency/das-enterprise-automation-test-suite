using NUnit.Framework;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_CreateAnAccountPage accountCreationPage;
        
        public FAASteps(ScenarioContext context) => _faaStepsHelper = new FAAStepsHelper(context);

        [When(@"the Applicant withdraw the application")]
        public void WhenTheApplicantWithdrawTheApplication() => _faaStepsHelper.WithdrawVacancy();

        [When(@"an Applicant initiates Account creation journey")]
        [Given(@"an Applicant initiates Account creation journey")]
        public void WhenAnApplicantInitiatesAccountCreationJourney() => accountCreationPage = _faaStepsHelper.StartFAAAccountCreation();
        
        [Then(@"Applicant is redirected to Activation Page when Login With Unactivated email")]
        public void ThenApplicantIsRedirectedToActivationPageWhenLoginWithUnactivatedEmail() => _faaStepsHelper.CreateFAAAccountWithNoActivation(accountCreationPage);
                       
        [Then(@"the Applicant is able to create a FAA Account")]
        [When(@"the Applicant is able to create a FAA Account")]

        public void ThenTheApplicantIsAbleToCreateAFAAAccount() => _faaStepsHelper.CreateFAAAccount(accountCreationPage);

        [Given(@"the Applicant creates a new FAA account")]
        public void GivenTheApplicantCreatesANewFAAAccount()
        {
            accountCreationPage = _faaStepsHelper.StartFAAAccountCreation();
            _faaStepsHelper.CreateFAAAccount(accountCreationPage);
        }

        [Then(@"the status of the Application is shown as '(successful|unsuccessful)' in FAA")]
        public void ThenTheStatusOfTheApplicationIsShownAsInFAA(string expectedStatus)
        {
            var actualStatus = _faaStepsHelper.GetApplicationStatus();
            StringAssert.Contains(expectedStatus, actualStatus);
        }

        [Then(@"the Applicant should be told that Email is already registered")]
        public void ThenTheApplicantShouldBeToldThatEmailIsAlreadyRegistered() => accountCreationPage.SubmitAccountCreationDetailsWithRegisteredEmail();

        [Then(@"the candidate is able to dismiss the Notifications in FAA '(Successful|Unsuccessful)'")]
        public void ThenTheCandidateIsAbleToDismissTheNotificationsInFAA(string expectedStatus) => _faaStepsHelper.DismissNotification(expectedStatus);

        [Then(@"the Vacancy dates is changed in FAA")]
        public void ThenTheVacancyDatesIsChangedInFAA() => _faaStepsHelper.FindAnApprenticeship().SearchByReferenceNumber().VerifyNewDates();

        [Then(@"the Wage is changed in FAA")]
        public void ThenTheWageIsChangedInFAA() => _faaStepsHelper.FindAnApprenticeship().SearchByReferenceNumber().VerifyNewWages();

        [Then(@"the Vacancy is not found on FAA")]
        public void ThenTheVacancyIsIsNotFoundOnFAA() => _faaStepsHelper.FindAnApprenticeship().SearchClosedVacancy();

        [Then(@"the Trainneship Vacancy dates is changed in FAA")]
        public void ThenTheTrainneshipVacancyDatesIsChangedInFAA() => _faaStepsHelper.FindATraineeship().SearchByReferenceNumber().VerifyNewDates();
        
        [When(@"Applicant Deletes the FAA Account")]
        public void WhenApplicantDeletesTheFAAAccount() 
        {
            _faaStepsHelper.GoToFAAHomePage()
                .GoToSettings()
                .DeleteYourAccount()
                .DeleteAccount()
                .ConfirmAccountDeletion();            
        }
      
        [When(@"the Candidate changes Personal Settings")]
        public void WhenTheCandidateChangesPersonalSettings() => _faaStepsHelper.ChangePersonalSettings();

        [Then(@"the Traineeship Vacancy is not found on FAA")]
        public void ThenTheTraineeshipVacancyIsNotFoundOnFAA() => _faaStepsHelper.FindATraineeship().SearchClosedVacancy();

        [Then(@"Candidate is able to delete draft application")]
        public void ThenCandidateIsAbleToDeleteDraftApplication() => _faaStepsHelper.ConfirmDraftVacancyDeletion();
    }
}