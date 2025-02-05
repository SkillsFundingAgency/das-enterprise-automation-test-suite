using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps(ScenarioContext context)
    {

        #region context&Helpers
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly EmployerStepsHelper _employerStepsHelper = new(context);
        private readonly EmployerCreateCohortStepsHelper _employerCreateCohortStepsHelper = new(context);
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper = new(context);
        private readonly CohortReferenceHelper _cohortReferenceHelper = new(context);
        #endregion

        private ApprenticeRequestsPage _apprenticeRequestsPage;
        private ApproveApprenticeDetailsPage _approveApprenticeDetailsPage;
        private ViewApprenticeDetailsPage _viewApprenticeDetailsPage;
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private AddApprenticeDetailsPage _addApprenticeDetailsPage;

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
            _apprenticeDetailsPage = EmployerStepsHelper.StopApprenticeThisMonth(_apprenticeDetailsPage, StopApprentice.Withdrawn)
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

        [When(@"Employer adds a new cohort and goes to Add Apprentice Details Page")]
        public void EmployerAddsSingleApprenticeToNewCohort() => _addApprenticeDetailsPage = _employerStepsHelper.EmployerGoToAdddApprenticeDetailsFromHomePage();

        [Then(@"Employer can an apprentice details from table below")]
        public void WhenProviderAddAnApprenticeUsesDetailsFromBelowToCreateIndividualApprentices(Table table)
        {
            var apprenticeCourseDataHelper = context.Get<ApprenticeCourseDataHelper>();

            var datahelper = context.Get<ApprenticeDataHelper>();

            var apprenticeRecords = table.CreateSet<ApprenticeDetails>();

            foreach (var record in apprenticeRecords)
            {
                ValidateApprenticeDetailsRule(apprenticeCourseDataHelper, datahelper, record);
            }
        }

        public void ValidateApprenticeDetailsRule(ApprenticeCourseDataHelper apprenticeCourseDataHelper, ApprenticeDataHelper dataHelper, ApprenticeDetails apprenticeRecord)
        {
            var randomApprentice = new ApprenticeDetails
            {
                FirstName = dataHelper.ApprenticeFirstname,
                LastName = dataHelper.ApprenticeLastname,
                EmailAddress = dataHelper.ApprenticeEmail,
                DateOfBirth = dataHelper.ApprenticeDob.ToString("yyyy-MM-dd"),
                StartDate = apprenticeCourseDataHelper.CourseStartDate.ToString("yyyy-MM-dd"),
                EndDate = apprenticeCourseDataHelper.CourseEndDate.ToString("yyyy-MM-dd"),
                TotalPrice = dataHelper.TrainingCost
            };

            static bool IsValid(string x) => x == "valid";

            if (IsValid(apprenticeRecord.FirstName)) apprenticeRecord.FirstName = randomApprentice.FirstName;
            if (IsValid(apprenticeRecord.LastName)) apprenticeRecord.LastName = randomApprentice.LastName;
            if (IsValid(apprenticeRecord.DateOfBirth)) apprenticeRecord.DateOfBirth = randomApprentice.DateOfBirth;
            if (IsValid(apprenticeRecord.EmailAddress)) apprenticeRecord.EmailAddress = randomApprentice.EmailAddress;
            if (IsValid(apprenticeRecord.StartDate)) apprenticeRecord.StartDate = randomApprentice.StartDate;
            if (IsValid(apprenticeRecord.EndDate)) apprenticeRecord.EndDate = randomApprentice.EndDate;
            if (IsValid(apprenticeRecord.TotalPrice)) apprenticeRecord.TotalPrice = randomApprentice.TotalPrice;

            MappedApprenticeDetails mappedApprenticeRecord = new(apprenticeRecord);

            _addApprenticeDetailsPage.SubmitInvalidDetailsAndCheckValidation(mappedApprenticeRecord)
               .ValidateExpectedError(mappedApprenticeRecord);

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
            _approveApprenticeDetailsPage = _employerStepsHelper.EmployerReviewCohort(true);

            _approveApprenticeDetailsPage.EmployerFirstApproveAndNotifyTrainingProvider();
        }

        [Given(@"the Employer create a cohort and send to provider to add apprentices")]
        [When(@"the Employer create a cohort and send to provider to add apprentices")]
        public void TheEmployerCreateACohortAndSendToProviderToAddApprentices() => _employerCreateCohortStepsHelper.EmployerCreateCohortViaLevyFundsAndSendsToProvider();

        [Given(@"the Employer creates (\d) cohorts and sends them to provider to add apprentices")]
        [When(@"the Employer creates (\d) cohorts and sends them to provider to add apprentices")]
        public void TheEmployerCreateACohortAndSendToProviderToAddApprentices(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateMultipleCohortsViaLevyFundsAndSendsToProvider(numberOfCohorts);

        [Given(@"the Employer2 creates (\d) cohorts and sends them to provider to add apprentices")]
        public void Employer2AddsApprenticesToCurrentCohort(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateCohortsViaDirectTransferAndSendsToProvider(numberOfCohorts);

        [Given(@"the Employer3 creates (\d) cohorts and sends them to provider to add apprentices")]
        public void Employer3AddsApprenticesToCurrentCohort(int numberOfCohorts) => _employerCreateCohortStepsHelper.EmployerCreateCohortsViaReserveNewFundsOptionAndSendsToProvider(numberOfCohorts);

        [When(@"the Employer adds (\d) apprentices and sends to provider")]
        public void WhenTheEmployerAddsApprenticesAndSendsToProvider(int numberOfApprentices)
        {
            _approveApprenticeDetailsPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices);

            var cohortReference = _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference();

            SetCohortReference(cohortReference);
        }

        [When(@"the Employer sends new cohort to provider")]
        public void WhenTheEmployerSendsCohortToProvider() => _approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview();

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts() => _employerStepsHelper.Approve();

        [StepDefinition(@"the Employer approves multiple cohorts")]
        public void WhenTheEmployerApprovesMultipleCohorts() => _employerStepsHelper.ApproveMultipleCohorts();

        [When(@"the Employer uses the reservation to create and approve (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationToCreateAndApproveCohortAndSendsToProvider(int numberOfApprentices)
            => SetCohortReference(EmployerStepsHelper.EmployerApproveAndSendToProvider(NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, false)));

        [When(@"the Employer creates 2 reservations")]
        public void ThenEmployerCreatesTwoReservations()
        {
            NonLevyEmployerAddsTwoReservations();
        }

        [Then(@"the employer uses the reservation to add an apprentice")]
        public void ThenEmployerUsesReservationToAddAnApprentice()
        {
            _approveApprenticeDetailsPage = _employerStepsHelper.GoToAddAnApprenticePage()
                .StartNowToSelectFunding()
                .SelectReservedFundingFromContext()
                  .SubmitValidUkprn()
                    .ConfirmProviderDetailsAreCorrect()
                    .NonLevyEmployerAddsApprentices()
                    .VerifyCourseIsPrePopulated()
                    .SubmitValidApprenticeDetails(true);
        }

        [Then(@"the employer uses the second reservation to add another apprentice and approve the cohort and sends to provider")]
        public void ThenEmployerUsesSecondReservationToAddApprenticeThenSendsToProvider()
        {
            _employerStepsHelper.ReplaceApprenticeDataInContext(1);
            _objectContext.SetNoOfApprentices(2);
            _approveApprenticeDetailsPage
                .SelectAddAnApprenticeUsingReservation()
                .ChooseSecondReservationFromContext()
                .SubmitValidApprenticeDetails(true);

            SetCohortReference(_approveApprenticeDetailsPage.EmployerSendsToTrainingProviderForReview().CohortReference());
        }

        [When(@"the Employer uses the reservation and (.*) confirm only standard courses are selectable and adds (\d) cohort and sends to provider")]
        public void TheEmployerUsesTheReservationAndAddsCohortAndSendsToProvider(bool shouldConfirmOnlyStandardCoursesSelectable, int numberOfApprentices)
            => SetCohortReference(NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, shouldConfirmOnlyStandardCoursesSelectable).EmployerSendsToTrainingProviderForReview().CohortReference());

        [StepDefinition(@"a new live apprentice record is created")]
        public void ANewLiveApprenticeRecordIsCreated() => _employerStepsHelper.ValidateStatusOnManageYourApprenticesPage("Live");

        [Then(@"the user can add an apprentices")]
        public void ThenTheUserCanAddAnApprentices() => new ApprenticesHomePage(context).ClickAddAnApprentice();

        [Then(@"employer validates apprentice is Flexi-job and can edit Delivery Model")]
        public void ThenEmployerValidatesApprenticeIsFlexi_JobAndCanEditDeliveryModel() => _employerStepsHelper.EmployerValidateApprenticeIsFlexiJobAndDeliveryModelEditable();

        [Then(@"the Employer changes the Delivery Model from Regular to Flexi and sends back to provider to review")]
        public void ThenTheEmployerChangesTheDeliveryModelFromRegularToFlexiAndSendsBackToProviderToReview() => _employerStepsHelper.EmployerChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval();

        [Then(@"the Employer sees the cohort in Draft with status of (.*)")]
        public void ThenTheCohortIsInDraftWithStatus(string status)
        {
            _approveApprenticeDetailsPage = GoToApprenticeRequestsPage().GoToDrafts().SelectViewCurrentCohortDetails();

            _approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        [Then(@"the Employer sees the cohort in With training providers with status of (.*)")]
        public void ThenTheCohortIsInWithTrainingProvidersWithStatus(string status)
        {
            _viewApprenticeDetailsPage = GoToApprenticeRequestsPage().GoToWithTrainingProviders().SelectViewCurrentCohortDetails();

            _viewApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        [Then(@"the Employer sees the cohort in Ready to review with status of (.*)")]
        public void ThenTheCohortIsInReadyToReviewWithStatus(string status)
        {
            _approveApprenticeDetailsPage = GoToApprenticeRequestsPage().GoToReadyToReview().SelectViewCurrentCohortDetails();

            _approveApprenticeDetailsPage.ValidateCohortStatus(status);
        }

        [Then(@"the employer is removed from the Flexi-job agency register")]
        public void ThenTheEmployerIsRemovedFromTheFlexi_JobAgencyRegister() => _employerStepsHelper.RemoveEmployerFromFlexiJobAgencyRegister();

        [Then(@"employer navigates to Approve Apprentice page and deletes Cohort before approval")]
        public void ThenEmployerNavigatesToApproveApprenticePageAndDeletesCohortBeforeApproval() => _employerStepsHelper.DeleteCurrentCohort();

        [Then(@"the previously registered FJAA employer can no longer approve the draft cohort")]
        public void ThenThePreviouslyRegisteredFJAAEmployerCanNoLongerApproveTheDraftCohort() => _employerStepsHelper.ValidateEmployerCanNoLongerApproveCohort();

        [Then(@"the previously registered FJAA employer can edit delivery model and then approve")]
        public void ThenThePreviouslyRegisteredFJAAEmployerCanEditDeliveryModelAndThenApprove() => _employerStepsHelper.RemovedFJAEmployerEditsDeliveryModelAndApproves();

        [When(@"the employer edits apprentice delivery model to Regular in Post Approvals and Submits changes")]
        public void WhenTheEmployerEditsApprenticeDeliveryModelToRegularInPostApprovalsAndSubmitsChanges() => _employerStepsHelper.EmployerChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval();

        [Then(@"the employer validates Flexi-Job content and approves")]
        public void ThenTheEmployerValidatesFlexi_JobContentAndApproves() => _employerStepsHelper.ValidateFlexiJobContentAndApproveCohort();

        [Then(@"the employer confirms Delivery Model is displayed as ""([^""]*)"" on Apprentice Details and Edit Apprentice screens")]
        public void ThenTheEmployerConfirmsDeliveryModelIsDisplayedAsOnApprenticeDetailsAndEditApprenticeScreens(string deliveryModel) => _employerStepsHelper.ValidateDeliveryModelDisplayedInDMSections(deliveryModel);

        [Then(@"the employer confirms Delivery Model is not displayed on Apprentice Details Screen")]
        public void ThenTheEmployerConfirmsDeliveryModelIsNotDisplayedOnApprenticeDetailsScreen() => _employerStepsHelper.ValidateDeliveryModelNotDisplayed();

        [When(@"the employer edits apprentice delivery model to Flexi in Post Approvals and Submits changes")]
        public void WhenTheEmployerEditsApprenticeDeliveryModelToFlexiInPostApprovalsAndSubmitsChanges() => _employerStepsHelper.EmployerChangeDeliveryModelToFlexiAndSendsBackToProvider_PostApproval();

        private ApprenticeRequestsPage GoToApprenticeRequestsPage()
        {
            if (!(_apprenticeRequestsPage?.IsPageCurrent.Item1 ?? false))
            {
                _apprenticeRequestsPage = _employerStepsHelper.GoToApprenticeRequestsPage();
            }

            return _apprenticeRequestsPage;
        }

        private ApproveApprenticeDetailsPage NonLevyEmployerAddsApprenticesUsingReservations(int numberOfApprentices, bool condition)
            => _approveApprenticeDetailsPage = _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(numberOfApprentices, condition);

        private void NonLevyEmployerAddsTwoReservations()
           => _nonLevyReservationStepsHelper.NonLevyEmployerAddsTwoReservations();

        private void SetCohortReference(string cohortReference) => _cohortReferenceHelper.SetCohortReference(cohortReference);
    }
}
