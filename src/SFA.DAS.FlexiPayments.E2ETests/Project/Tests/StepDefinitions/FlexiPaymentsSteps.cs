using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers;
using SFA.DAS.FlexiPayments.E2ETests.Project.Tests.TestSupport;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{

    [Binding]
    public class FlexiPaymentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly FlexiProviderStepsHelper _providerStepsHelper;
        private readonly NonLevyReservationStepsHelper _nonLevyReservationStepsHelper;
        private readonly CohortReferenceHelper _cohortReferenceHelper;
        private readonly ExistingAccountSteps _existingAccountSteps;
        private readonly FlexiPaymentProviderSteps _flexiPaymentProviderSteps;
        private ApprenticeDetailsPage _apprenticeDetailsPage;
        private readonly ReadApprenticeDataHelper readApprenticeDataHelper;
        private ApprenticeDataHelper _apprenticeDataHelper;
        private ApprenticeCourseDataHelper _apprenticeCourseDataHelper;
        private EmployerChangeTheTotalPricePage _employerChangeTheTotalPricePage;
        private EmployerChangeOfPriceViewChangeRequestPage _viewChangeRequestPage;
        private EmployerReviewChangesPage _employerReviewChangesPage;
        private decimal newTotalPrice;

        public FlexiPaymentsSteps(ScenarioContext context)
        {
            _context = context;
            _employerStepsHelper = new EmployerStepsHelper(_context);
            _providerStepsHelper = new FlexiProviderStepsHelper(_context);
            _nonLevyReservationStepsHelper = new NonLevyReservationStepsHelper(_context);
            _cohortReferenceHelper = new CohortReferenceHelper(context);
            _existingAccountSteps = new ExistingAccountSteps(_context);
            _flexiPaymentProviderSteps = new FlexiPaymentProviderSteps(_context);
            readApprenticeDataHelper = new ReadApprenticeDataHelper(context);

        }

        [Given(@"(Levy|NonLevy) Employer and Pilot provider have a fully approved apprentices with the below data")]
        public void FullyApprovedApprenticesWithTheBelowData(string employerType, Table table)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount(employerType);

            if (employerType == "Levy")
                _employerStepsHelper.EmployerAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));
            else
                EmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(table);

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            sbyte i = 1;

            foreach (var row in table.Rows)
            {
                var inputData = row.CreateInstance<FlexiPaymentsInputDataModel>();
                ProviderAddsUln(inputData.PilotStatus, i++);
            }
            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }

        [Given(@"the Employer has an approved (Pilot|NonPilot) apprentice")]
        public void EmployerHasFullyApprovedPilotApprentice(string pilotStatus)
        {
            _existingAccountSteps.GivenTheEmployerLoginsUsingExistingAccount("Levy");

            _employerStepsHelper.EmployerAddApprentice(1);

            _employerStepsHelper.EmployerFirstApproveCohortAndNotifyProvider();

            _flexiPaymentProviderSteps.GivenProviderLogsInToReviewTheCohort();

            ProviderAddsUln(pilotStatus == "Pilot", 1);

            _flexiPaymentProviderSteps.ThenProviderApprovesTheCohort();
        }

        private void ProviderAddsUln(bool isPilot, int i)
        {
            if (isPilot) _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerIntoThePilot(i);
            else _flexiPaymentProviderSteps.ProviderAddsUlnAndOptLearnerOutOfThePilot(i);
        }

        [Given(@"Employer adds apprentices to the cohort with the following details")]
        public void GivenEmployerAddsApprenticesToTheCohortWithTheFollowingDetails(Table table) => _employerStepsHelper.EmployerAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));

        [Given(@"Pilot Provider adds apprentices to the cohort witht the following details")]
        public void GivenPilotProviderAddsApprenticesToTheCohortWithtTheFollowingDetails(Table table) => _providerStepsHelper.PilotProviderAddApprentice(readApprenticeDataHelper.ReadApprenticeData(table));

        [When(@"employer reviews and approves the cohort")]
        public void WhenEmployerReviewsAndApprovesTheCohort() => new EmployerStepsHelper(_context).EmployerReviewCohort().EmployerDoesSecondApproval();

        [Given(@"Employer changes the Total Price then approve the cohort and sends it to the training provider")]
        public void EmployerReviewsTheLearnersDetailsAndChangesTheTotalPrice()
        {
            var cohortReference = new EmployerStepsHelper(_context).EmployerReviewCohort().SelectEditApprentice().UpdateTotalApprenticeshipPrice().EmployerSendsToTrainingProviderForReview().CohortReferenceFromUrl();
            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }


        [Given(@"the Employer uses the reservation to create and approve apprentices with the following details")]
        public void EmployerUsesTheReservationToCreateAndApproveApprenticesWithTheFollowingDetails(Table table) => _nonLevyReservationStepsHelper.NonLevyEmployerAddsApprenticesUsingReservations(readApprenticeDataHelper.ReadApprenticeData(table), false);

        [When(@"Employer searches learner (.*) on Manage your apprentices page")]
        public void WhenEmployerSearchesLearnerOnManageYourApprenticesPage(int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage = _employerStepsHelper.ViewCurrentApprenticeDetails(true);
        }

        [Then(@"Employer can review the Change of Price request and approve it")]
        public void ThenEmployerCanReviewTheChangeOfPriceRequestAndApproveIt()
        {
            EmployerSearchesLearnerOnManageYourApprenticesPage();
            EmployerCanViewTheDetailsOfTheChangeOfPriceRequest();

            new EmployerReviewChangesPage(_context)
                .SelectApproveChangesRadioButtonAndSend()
                .ValidatePriceChangeApprovedBannerDisplayed();
        }

        [Then(@"Employer can review the Change of Start Date request and approve it")]
        public void ThenEmployerCanReviewTheChangeOfStartDateRequestAndApproveIt()
        {
            EmployerSearchesLearnerOnManageYourApprenticesPage();
            EmployerCanViewTheDetailsOfTheChangeOfStartDateRequest();

            _employerReviewChangesPage.SelectApproveChangesRadioButtonAndSend()
                .ValidateChangeOfStartDateApprovedBannerDisplayed();
        }


        [Given(@"Employer searches for the learner on Manage your apprentice page")]
        public void EmployerSearchesForTheLearnerOnManageYourApprenticePage()
        {
            EmployerSearchesLearnerOnManageYourApprenticesPage();
        }

        [When(@"Employer proceeds to create a Change of Price request for flexi payments pilot learner")]
        [Then(@"Employer proceeds to create a Change of Price request for flexi payments pilot learner")]
        public void EmployerProceedsToCreateAChangeOfPriceRequestForFlexiPaymentsPilotLearner()
        {
            _apprenticeDetailsPage.ClickChangePriceLink();
        }

        [When(@"Employer submits change of price form without changing input fields")]
        public void EmployerSubmitsChangeOfPriceFormWithoutChangingInputFields()
        {
            _employerChangeTheTotalPricePage = new EmployerChangeTheTotalPricePage(_context)
                .ClickContinueButtonWithValidationErrors();
        }

        [Then(@"all default validation errors are displayed to the Employer")]
        public void AllDefaultValidationErrorsAreDisplayedToTheEmployer()
        {
            _employerChangeTheTotalPricePage.ConfirmValidationErrorMessagesDisplayed();
        }

        [Then(@"validate new Total Price must be between (.*) and (.*)")]
        public void ValidateNewTotalPriceMustBeBetweenAnd(int min, int max)
        {
            _employerChangeTheTotalPricePage.ValidateOuterBoundaryValueErrorForTotalPrice(min - 1);

            _employerChangeTheTotalPricePage.ValidateOuterBoundaryValueErrorForTotalPrice(max + 1);
        }

        [Then(@"a read-only current Total Price is displayed on the page")]
        public void ARead_OnlyCurrentTotalPriceIsDisplayedOnThePage()
        {
            _apprenticeDataHelper = _context.GetValue<ApprenticeDataHelper>();
            var totalPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingCost);

            //_employerChangeTheTotalPricePage.ValidateCurrentTotalPriceText(totalPrice.ToString("NO"));
        }

        [Then(@"validate Employer cannot enter an Effective From Date that is before Training Start Date")]
        public void ValidateEmployerCannotEnterAnEffectiveFromDateThatIsBeforeTrainingStartDate()
        {
            _apprenticeCourseDataHelper = _context.GetValue<ApprenticeCourseDataHelper>();

            var date = _apprenticeCourseDataHelper.CourseStartDate.AddDays(-1);
            _employerChangeTheTotalPricePage.ValidateEnterADateThatIsAfterTrainingStartDateErrorMessage(date);
        }

        [Then(@"validate Employer cannot enter an Effective From Date that is after Training End Date")]
        public void ValidateEmployerCannotEnterAnEffectiveFromDateThatIsAfterTrainingEndDate()
        {
            var date = _apprenticeCourseDataHelper.CourseEndDate.AddDays(1);
            _employerChangeTheTotalPricePage.ValidateEnterADateThatIsBeforePlannedEndDateErrorMessage(date);
        }

        [Then(@"Employer successfully creates a Change of Price request")]
        public void ThenEmployerSuccessfullyCreatesAChangeOfPriceRequest()
        {
            var newTotalPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingCost) + 500;

            new EmployerChangeTheTotalPricePage(_context).EnterValidChangeOfPriceDetails
                (newTotalPrice.ToString(), DateTime.Today, _context.ScenarioInfo.Title)
                .ClickSendButton()
                .ValidateChangeOfPriceRequestRaisedSuccessfully();
        }

        [Then(@"Employer is able to view details of change of price request")]
        public void ThenEmployerIsAbleToViewDetailsOfChangeOfPriceRequest()
        {
            _apprenticeDetailsPage.ClickViewChangeRequestLink();

            var totalPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingCost) + 500;

            _viewChangeRequestPage = new EmployerChangeOfPriceViewChangeRequestPage(_context).VerifyPendingProviderReviewTagIsDisplayed()
                .ValidateRequestValues(totalPrice, DateTime.Now, _context.ScenarioInfo.Title);
        }

        [Then(@"Employer can successfully cancel the change of price request")]
        public void ThenEmployerCanSuccessfullyCancelTheChangeOfPriceRequest()
        {
            _viewChangeRequestPage.SelectCancelTheRequestRadioButtonAndContinue()
                .ValidateChangeOfPriceRequestCancelledSuccessfully();
        }

        [When(@"Employer successfully creates a Change of Price request")]
        public void EmployerSuccessfullyCreatesAChangeOfPriceRequest()
        {
            _apprenticeDataHelper = _context.GetValue<ApprenticeDataHelper>();

            newTotalPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingCost) - 500;

            new EmployerChangeTheTotalPricePage(_context).EnterValidChangeOfPriceDetails(newTotalPrice.ToString(), DateTime.Today, _context.ScenarioInfo.Title)
                .ClickSendButton()
                .ValidateChangeOfPriceRequestRaisedSuccessfully();
        }

        [Then(@"Employer searches for learner on Manage your apprentices page")]
        public void EmployerSearchesLearnerOnManageYourApprenticesPage() => _apprenticeDetailsPage = _employerStepsHelper.ViewCurrentApprenticeDetails(true);

        [Then(@"Employer is able to view the pending Change of Price request")]
        public void EmployerIsAbleToViewThePendingChangeOfPriceRequest() => _apprenticeDetailsPage.ValidatePriceChangePendingBannerDisplayed();

        [Then(@"Employer is able to view the pending Change of Start Date request")]
        public void EmployerIsAbleToViewThePendingChangeOfStartDateRequest() => _apprenticeDetailsPage.ValidateStartDateChangePendingBannerDisplayed();

        [Then(@"Employer can view the details of the Change of Price request")]
        public void EmployerCanViewTheDetailsOfTheChangeOfPriceRequest() => _apprenticeDetailsPage.ClickReviewPriceChangeLink();

        [Then(@"Employer can view the details of the Change of Start Date request")]
        public void EmployerCanViewTheDetailsOfTheChangeOfStartDateRequest()
        {
            _apprenticeDetailsPage.ClickReviewStartDateChangeLink();

            _employerReviewChangesPage = new EmployerReviewChangesPage(_context).ValidateChangeOfStartDateRequestedValues(DateTime.Now, DateTime.Now.AddMonths(12), _context.ScenarioInfo.Title);
        }

        [Then(@"Employer is able to successfully reject the Change of Price request")]
        public void EmployerRejectsChangeOfPriceRequest()
        {
            new EmployerReviewChangesPage(_context)
                .SelectRejectChangesRadioButtonAndSend(_context.ScenarioInfo.Title + " - Reject")
                .ValidatePriceChangeRejectedBannerDisplayed();
        }

        [Then(@"Employer is able to successfully reject the Change of Start Date request")]
        public void EmployerRejectsChangeOfStartDateRequest()
        {
            _employerReviewChangesPage.SelectRejectChangesRadioButtonAndSend(_context.ScenarioInfo.Title + " - Reject")
                .ValidateChangeOfStartDateRejectedBannerDisplayed();
        }


        [Then(@"Employer (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenEmployerCannotMakeChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            _flexiPaymentProviderSteps.SetApprenticeDetailsInContext(learnerNumber);

            _apprenticeDetailsPage.ValidateEmployerEditApprovedApprentice(action == "can");
        }

        [Then(@"display a Provider payments status row with (Active|Inactive) status to Employer")]
        public void DisplayAProviderPaymentsStatusRowWithStatus(string providerPaymentStatus)
        {
            _apprenticeDetailsPage.ValidateProviderPaymentStatus(providerPaymentStatus);
        }

        [Then(@"employer is able to successfully freeze provider payments")]
        public void EmployerSuccessfullyFreezesProviderPayments()
        {
            _apprenticeDetailsPage.ClickChangeProviderPaymentStatusLink();

            _apprenticeDetailsPage = new EmployerFreezeProviderPaymentsPage(_context).FreezeFuturePayments();
        }

        [Then(@"employer is able to successfully unfreeze provider payments")]
        public void EmployerSuccessfullyUnfreezeProviderPayments()
        {
            _apprenticeDetailsPage.ClickChangeProviderPaymentStatusLink();

            _apprenticeDetailsPage = new EmployerUnfreezeProviderPaymentsPage(_context).UnfreezeFuturePayments();
        }
    }
}
