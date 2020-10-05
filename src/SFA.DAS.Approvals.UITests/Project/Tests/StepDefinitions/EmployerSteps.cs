using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.NServiceBusHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        #region context&Helpers
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private ApprenticeRequestsPage _apprenticeRequestsPage;
        private ReviewYourCohortPage _reviewYourCohortPage;        
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private readonly PublishPaymentEvent _publishPaymentEvent;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _publishPaymentEvent = context.Get<PublishPaymentEvent>();
        }

        [StepArgumentTransformation(@"(does ?.*)")]
        public bool DoesToBool(string value) => value == "does";


        [Then(@"Employer is able to Pause the apprentice")]
        public void ThenEmployerIsAbleToPauseTheApprentice()
        {
            _apprenticeDetailsPage = _employerStepsHelper
                .ViewCurrentApprenticeDetails()
                .ClickEditStatusLink()
                .SelectPauseAndContinue()
                .SelectYesAndConfirm();
        }

        [Then(@"Employer is able to Resume the apprentice")]
        public void ThenEmployerIsAbleToResumeTheApprentice()
        {
            _apprenticeDetailsPage = _apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectResumeAndContinue()
                .SelectYesAndConfirm();
        }

        [Then(@"Employer is able to Stop the apprentice")]
        public void ThenEmployerIsAbleToStopTheApprentice()
        {
            _apprenticeDetailsPage = _employerStepsHelper
            .StopApprenticeThisMonth(_apprenticeDetailsPage);
        }

        [Then(@"Employer can edit stop date to learner start date")]
        public void ThenEmployerCanEditStopDateToLearnerStartDate()
        {
            _apprenticeDetailsPage
                .ClickEditStopDateLink()
                .EditStopDateToCourseStartDateAndSubmit();
        }

        [Given(@"Employer adds (\d) apprentices to current cohort")]
        public void EmployerAddsApprenticesToCurrentCohort(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices, false);

            var x = _reviewYourCohortPage.CohortReferenceFromUrl();
            _objectContext.SetCohortReference(x);

            _apprenticeRequestsPage = _reviewYourCohortPage.SaveAndExit();
        }

        [Then(@"Employer is able to view saved cohort from Draft")]
        public void ThenEmployerIsAbleToViewSavedCohortFromDraft()
        {
            _apprenticeRequestsPage.GoToDrafts()
                .SelectViewCurrentCohortDetails();
        }

        [Then(@"Employer is able to edit all apprentices before approval")]
        public void EmployerIsAbleToEditAllApprenticesBeforeApproval()
        {
            int totalApprentices = _reviewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _reviewYourCohortPage = _reviewYourCohortPage.SelectEditApprentice(i)
                    .EditApprenticePreApprovalAndSubmit();
            }
        }

        [Then(@"Employer is able to delete all apprentices before approval")]
        public void EmployerIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            int totalApprentices = _reviewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices - 1; i++)
            {
                _reviewYourCohortPage = _reviewYourCohortPage.SelectEditApprentice(0)
                     .SelectDeleteApprentice()
                    .ConfirmDeleteAndSubmit();
            }
        }

        [Then(@"Employer is able to delete the cohort before approval")]
        public void ThenEmployerIsAbleToDeleteTheCohortBeforeApproval()
        {
            _reviewYourCohortPage.SelectDeleteThisGroup()
                .ConfirmDeleteAndSubmit();
        }

        [When(@"the Employer approves (\d) cohort and sends to provider")]
        public void TheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"the Employer approves the cohort and sends to provider")]
        public void WhenTheEmployerApprovesTheCohortAndSendsToProvider()
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerReviewCohort();

			_reviewYourCohortPage.EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [Given(@"the Employer create a cohort and send to provider to add apprentices")]
        [When(@"the Employer create a cohort and send to provider to add apprentices")]
        public void TheEmployerCreateACohortAndSendToProviderToAddApprentices()
        {
            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider(false);
        }


        [When(@"the Employer adds (\d) apprentices and sends to provider")]
        public void WhenTheEmployerAddsApprenticesAndSendsToProvider(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices, false);

            var cohortReference = _reviewYourCohortPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts()
        {
            _employerStepsHelper.Approve();
        }

        [When(@"the Employer uses the reservation to create and approve (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationToCreateAndApproveCohortAndSendsToProvider(int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(_reviewYourCohortPage);
            
            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"the Employer uses the reservation and (.*) confirm only standard courses are selectable and adds (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationAndAddsCohortAndSendsToProvider(bool shouldConfirmOnlyStandardCoursesSelectable, int numberOfApprentices)
        {
            _reviewYourCohortPage = _employerStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, shouldConfirmOnlyStandardCoursesSelectable);

            var cohortReference = _reviewYourCohortPage.EmployerSendsToTrainingProviderForReview()
                .CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"PaymentsCompletion event is received")]
        public void WhenPaymentsCompletionEventIsReceived() => _publishPaymentEvent.PublishRecordedAct1CompletionPaymentEvent(_dataHelper.ApprenticeshipId());

        [Given(@"a new live apprentice record is created")]
        [Then(@"a new live apprentice record is created")]
        public void ANewLiveApprenticeRecordIsCreated()
        {
            _employerStepsHelper.ValidateStatusOnManageYourApprenticesPage("Live");
        }

        [Then(@"the apprenticeship status changes to completed")]
        public void ThenTheApprenticeshipStatusChangesToCompleted() => _employerStepsHelper.ValidateCompletionStatus();

        [Then(@"Apprentice status and details cannot be changed except the planned training finish date")]
        public void ThenApprenticeStatusAndDetailsCannotBeChangedExceptThePlannedTrainingFinishDate() => _employerStepsHelper.ValidateApprenticeDetailsCanNoLongerBeChangedExceptEndDate();

        [Given(@"the Employer adds (.*) apprentices (Aged16to24|AgedAbove25) as of 01AUG2020 with start date as Month (.*) and Year (.*)")]
        [When(@"the Employer adds (.*) apprentices (Aged16to24|AgedAbove25) as of 01AUG2020 with start date as Month (.*) and Year (.*)")]
        public void TheEmployerAddsApprenticesOfSpecifiedAgeCategorywithStartDateAsMentioned(int numberOfApprentices, string eIAgeCategoryAsOfAug2020, int eIStartmonth, int eIStartyear)
        {
            _objectContext.SetIsEIJourney(true);
            _objectContext.SetEIAgeCategoryAsOfAug2020(eIAgeCategoryAsOfAug2020);
            _objectContext.SetEIStartMonth(eIStartmonth);
            _objectContext.SetEIStartYear(eIStartyear);
            TheEmployerApprovesCohortAndSendsToProvider(numberOfApprentices);
        }

        [Then(@"the user can add an apprentices")]
        public void ThenTheUserCanAddAnApprentices() => new ApprenticesHomePage(_context, true).AddAnApprentice();
    }
}
