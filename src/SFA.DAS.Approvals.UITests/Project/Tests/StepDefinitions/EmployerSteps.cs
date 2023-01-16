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
        private readonly EmployerCreateCohortStepsHelper _employerCreateCohortStepsHelper;
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        #endregion

        private ApprenticeRequestsPage _apprenticeRequestsPage;
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private ViewApprenticeDetailsPage _viewApprenticeDetailsPage;
        private ApprenticeDetailsPage _apprenticeDetailsPage;

        public EmployerSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _employerStepsHelper = new EmployerStepsHelper(context);
            _employerCreateCohortStepsHelper = new EmployerCreateCohortStepsHelper(context);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _nonLevyReservationStepsHelper = new NonLevyReservationStepsHelper(context);
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
                .SelectYesAndConfirm()
                .ValidateFlashMessage("Apprenticeship paused");
        }

        [Then(@"Employer is able to Resume the apprentice")]
        public void ThenEmployerIsAbleToResumeTheApprentice()
        {
            _apprenticeDetailsPage = _apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectResumeAndContinue()
                .SelectYesAndConfirm()
                 .ValidateFlashMessage("Apprenticeship resumed");
        }

        [Then(@"Employer is able to Stop the apprentice")]
        public void ThenEmployerIsAbleToStopTheApprentice()
        {
            _apprenticeDetailsPage = _employerStepsHelper
            .StopApprenticeThisMonth(_apprenticeDetailsPage, StopApprentice.Withdrawn)
             .ValidateFlashMessage("Apprenticeship stopped");
        }
        
        [Then(@"Employer is able to edit all apprentices before approval")]
        public void EmployerIsAbleToEditAllApprenticesBeforeApproval()
        {
            int totalApprentices = _approveApprenticeDetailsPage.TotalNoOfApprentices();

            for (int i = 0; i < totalApprentices; i++) _approveApprenticeDetailsPage = _approveApprenticeDetailsPage.SelectEditApprentice(i).EditApprenticePreApprovalAndSubmit();
        }

        [Then(@"Employer can edit stop date to learner start date")]
        public void ThenEmployerCanEditStopDateToLearnerStartDate()
        {
            _apprenticeDetailsPage
                .ClickEditStopDateLink()
                .EditStopDateToCourseStartDateAndSubmit()
                .ValidateFlashMessage("New stop date confirmed");
        }

        [Given(@"Employer adds (\d) apprentices to a new cohort")]
        public void EmployerAddsApprenticesToCurrentCohort(int numberOfApprentices)
        {
            _approveApprenticeDetailsPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices);

            var cohortReference = _approveApprenticeDetailsPage.CohortReferenceFromUrl();
            _objectContext.SetCohortReference(cohortReference);

            _apprenticeRequestsPage = _approveApprenticeDetailsPage.SaveAndExit();
        }

        [Given(@"the Employer approves the cohort")]
        public void EmployerApprovesTheCohort() => _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

        [Then(@"Employer is able to view saved cohort from Draft")]
        public void ThenEmployerIsAbleToViewSavedCohortFromDraft() => _apprenticeRequestsPage.GoToDrafts().SelectViewCurrentCohortDetails();

        [Then(@"Employer is able to delete all apprentices before approval")]
        public void EmployerIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            int totalApprentices = _approveApprenticeDetailsPage.TotalNoOfApprentices();

            for (int i = 0; i < totalApprentices - 1; i++)
            {
                _approveApprenticeDetailsPage = _approveApprenticeDetailsPage.SelectEditApprentice(0)
                     .SelectDeleteApprentice()
                    .ConfirmDeleteAndSubmit();
            }
        }

        [Then(@"Employer is able to delete the cohort before approval")]
        public void ThenEmployerIsAbleToDeleteTheCohortBeforeApproval() => _approveApprenticeDetailsPage.SelectDeleteThisGroup().ConfirmDeleteAndSubmit();

        [Given(@"the Employer approves cohort with (\d) apprentices and sends to provider")]
        [When(@"the Employer approves (\d) cohort and sends to provider")]
        public void TheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            SetCohortReference(cohortReference);
        }

        [When(@"the Employer approves the cohort and sends to provider")]
        public void WhenTheEmployerApprovesTheCohortAndSendsToProvider()
        {
            _approveApprenticeDetailsPage = _employerStepsHelper.EmployerReviewCohort();

            _approveApprenticeDetailsPage.EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [Given(@"the Employer create a cohort and send to provider to add apprentices")]
        [When(@"the Employer create a cohort and send to provider to add apprentices")]
        public void TheEmployerCreateACohortAndSendToProviderToAddApprentices() => _employerCreateCohortStepsHelper.EmployerCreateCohortAndSendsToProvider();        

        [Given(@"the Employer creates (\d) cohorts and sends them to provider to add apprentices")]
        [When(@"the Employer creates (\d) cohorts and sends them to provider to add apprentices")]
        public void TheEmployerCreateACohortAndSendToProviderToAddApprentices(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateCohortsAndSendsToProvider(numberOfCohorts, false);

        [Given(@"the Employer2 creates (\d) cohorts and sends them to provider to add apprentices")]
        public void Employer2AddsApprenticesToCurrentCohort(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateCohortsAndSendsToProvider(numberOfCohorts, true);

        [Given(@"the Employer3 creates (\d) cohorts and sends them to provider to add apprentices")]
        public void Employer3AddsApprenticesToCurrentCohort(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateCohortsAndSendsToProvider(numberOfCohorts, true);

        [When(@"the Employer adds (\d) apprentices and sends to provider")]
        public void WhenTheEmployerAddsApprenticesAndSendsToProvider(int numberOfApprentices)
        {
            _approveApprenticeDetailsPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices);

            var cohortReference = _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            SetCohortReference(cohortReference);
        }

        [When(@"the Employer sends new cohort to provider")]
        public void WhenTheEmployerSendsCohortToProvider()
        {         
            _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview();
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts() => _employerStepsHelper.Approve();

        [StepDefinition(@"the Employer approves multiple cohorts")]
        public void WhenTheEmployerApprovesMultipleCohorts() => _employerStepsHelper.ApproveMultipleCohorts();

        [When(@"the Employer uses the reservation to create and approve (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationToCreateAndApproveCohortAndSendsToProvider(int numberOfApprentices) 
            => SetCohortReference(_employerStepsHelper.EmployerApproveAndSendToProvider(NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, false)));

        [When(@"the Employer uses the reservation and (.*) confirm only standard courses are selectable and adds (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationAndAddsCohortAndSendsToProvider(bool shouldConfirmOnlyStandardCoursesSelectable, int numberOfApprentices) 
            => SetCohortReference(NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, shouldConfirmOnlyStandardCoursesSelectable).EmployerSendsToTrainingProviderForReview().CohortReference());

        [StepDefinition(@"a new live apprentice record is created")]
        public void ANewLiveApprenticeRecordIsCreated() => _employerStepsHelper.ValidateStatusOnManageYourApprenticesPage("Live");

        [Then(@"the apprenticeship status changes to completed")]
        public void ThenTheApprenticeshipStatusChangesToCompleted() => _employerStepsHelper.ValidateCompletionStatus();

        [Then(@"Apprentice status and details cannot be changed except the planned training finish date")]
        public void ThenApprenticeStatusAndDetailsCannotBeChangedExceptThePlannedTrainingFinishDate() => _employerStepsHelper.ValidateApprenticeDetailsCanNoLongerBeChangedExceptEndDate();

        [Then(@"the user can add an apprentices")]
        public void ThenTheUserCanAddAnApprentices() => new ApprenticesHomePage(_context).AddAnApprentice();

        [Then(@"employer validates apprentice is Flexi-job and can edit Delivery Model")]
        public void ThenEmployerValidatesApprenticeIsFlexi_JobAndCanEditDeliveryModel() => _employerStepsHelper.EmployerValidateApprenticeIsFlexiJobAndDeliveryModelEditable();

        [Then(@"the Employer changes the Delivery Model from Regular to Flexi and sends back to provider to review")]
        public void ThenTheEmployerChangesTheDeliveryModelFromRegularToFlexiAndSendsBackToProviderToReview() => _employerStepsHelper.EmployerChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval();

        [Then(@"the Employer sees the cohort in Draft with status of (.*)")]
        public void ThenTheCohortIsInDraftWithStatus(string status)
        {
            if(!(_apprenticeRequestsPage?.IsPageCurrent ?? false))
            {
                _apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            }

            _approveApprenticeDetailsPage = _apprenticeRequestsPage.GoToDrafts().SelectViewCurrentCohortDetails();

            _approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        [Then(@"the Employer sees the cohort in With training providers with status of (.*)")]
        public void ThenTheCohortIsInWithTrainingProvidersWithStatus(string status)
        {
            if (!(_apprenticeRequestsPage?.IsPageCurrent ?? false))
            {
                _apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            }

            _viewApprenticeDetailsPage = _apprenticeRequestsPage.GoToWithTrainingProviders().SelectViewCurrentCohortDetails();

            _viewApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        [Then(@"the Employer sees the cohort in Ready to review with status of (.*)")]
        public void ThenTheCohortIsInReadyToReviewWithStatus(string status)
        {
            if(!(_apprenticeRequestsPage?.IsPageCurrent ?? false))
            {
                _apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            }

            _approveApprenticeDetailsPage = _apprenticeRequestsPage.GoToReadyToReview().SelectViewCurrentCohortDetails();

            _approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        private ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool condition) 
            => _approveApprenticeDetailsPage = _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, condition);

        public void SetCohortReference(string cohortReference) => _cohortReferenceHelper.SetCohortReference(cohortReference);

        [When(@"the employer edits apprentice delivery model to Regular in Post Approvals and Submits changes")]
        public void WhenTheEmployerEditsApprenticeDeliveryModelToRegularInPostApprovalsAndSubmitsChanges() => _employerStepsHelper.EmployerChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval();

        [Then(@"the employer validates Flexi-Job content and approves")]
        public void ThenTheEmployerValidatesFlexi_JobContentAndApproves() => _employerStepsHelper.ValidateFlexiJobContentAndApproveCohort();

        [Then(@"the employer confirms Delivery Model is displayed as ""([^""]*)"" on Apprentice Details and Edit Apprentice screens")]
        public void ThenTheEmployerConfirmsDeliveryModelIsDisplayedAsOnApprenticeDetailsAndEditApprenticeScreens(string deliveryModel) => _employerStepsHelper.ValidateDeliveryModelDisplayedInDMSections(deliveryModel);

        [Then(@"the employer confirms Delivery Model is not displayed on Apprentice Details Screen")]
        public void ThenTheEmployerConfirmsDeliveryModelIsNotDisplayedOnApprenticeDetailsScreen() => _employerStepsHelper.ValidateDeliveryModelNotDisplayed();
    }
}
