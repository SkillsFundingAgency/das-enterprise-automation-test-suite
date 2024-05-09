using NUnit.Framework;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using static SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ProviderManageYourApprenticesPage;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentProviderSteps(ScenarioContext context)
    {
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);
        private readonly ProviderEditStepsHelper _providerEditStepsHelper = new(context);
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDataHelper = new(context);
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper = new(context);
        private ProviderApprenticeDetailsPage _providerApprenticeDetailsPage;
        private ChangePriceNegotiationAmountsPage _changePriceNegotiationAmountPage;
        private ChangeTrainingStartDatePage _changeTrainingStartDatePage;
        private ChangeOfPriceViewChangeRequestPage _viewPriceChangeRequestPage;
        private ViewChangeOfStartDate _viewChangeOfStartDateRequestPage;
        private ApprenticeCourseDataHelper _apprenticeCourseDataHelper = context.GetValue<ApprenticeCourseDataHelper>();
        private ApprenticeDataHelper _apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();
        private decimal newTrainingPrice;
        private decimal newEndpointAssessmentPrice;

        [Given(@"provider logs in to review the cohort")]
        [When(@"provider logs in to review the cohort")]
        public void GivenProviderLogsInToReviewTheCohort() => _providerApproveApprenticeDetailsPage = _providerCommonStepsHelper.CurrentCohortDetails();

        [When(@"the Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerApproveStepsHelper.EditAndApprove();

        [Given(@"the provider adds Ulns and opts the learners out of the pilot")]
        [When(@"the provider adds Ulns and opts the learners out of the pilot")]
        public void WhenTheProviderAddsUlnsAndOptsTheLearnersOutOfThePilot() => _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditFlexiPilotApprentice(false);

        [When(@"Provider successfully approves the cohort")]
        [Then(@"Provider successfully approves the cohort")]
        public void ThenProviderApprovesTheCohort() => _providerApproveApprenticeDetailsPage.SubmitApprove();

        [Given(@"the provider adds Ulns and Opt the learners into the pilot")]
        [When(@"the provider adds Ulns and Opt the learners into the pilot")]
        public void ThenTheProviderAddsUlnsAndOptTheLearnersIntoThePilot() => _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditFlexiPilotApprentice(true);


        [Given(@"the provider adds Uln and Opt learner (.*) into the pilot")]
        public void ProviderAddsUlnAndOptLearnerIntoThePilot(int learnerNumber) => _providerEditStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, true);

        [Given(@"Simplified Payments Pilot tags and additional columns are displayed on Approve apprentice details page")]
        public void GivenSimplifiedPaymentsPilotTagsAndAdditionalColumnsAreDisplayedOnApproveApprenticeDetailsPage() => _providerApproveApprenticeDetailsPage.VerifySimplifiedPaymentsPilotTagAndColumns(true);

        [Given(@"Simplified Payments Pilot tags and additional columns are NOT displayed on Approve apprentice details page")]
        public void GivenSimplifiedPaymentsPilotTagsAndAdditionalColumnsAreNOTDisplayedOnApproveApprenticeDetailsPage() => _providerApproveApprenticeDetailsPage.VerifySimplifiedPaymentsPilotTagAndColumns(false);


        [Given(@"the provider adds Uln and Opt learner (.*) out of the pilot")]
        public void ProviderAddsUlnAndOptLearnerOutOfThePilot(int learnerNumber) => _providerEditStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, false);

        [Given(@"pilot provider approves the cohort")]
        [When(@"pilot provider approves the cohort")]
        public void WhenPilotProviderApprovesCohort() => new ProviderApproveApprenticeDetailsPage(context).SubmitApprove();

        [Given(@"Provider can search learner (.*) using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        [When(@"Provider can search learner (.*) using Simplified Payments Pilot filter set to (yes|no) on Manage your apprentices page")]
        public void ProviderSearchesLearnerOnManageYourApprenticesPageWithSimplifiedPaymentsPilotFilter(int learnerNumber = 1, string filter = "")
        {
            SetApprenticeDetailsInContext(learnerNumber);

            SimplifiedPaymentsPilot filterValue = filter == "yes" ? SimplifiedPaymentsPilot.True : filter == "no" ? SimplifiedPaymentsPilot.False : SimplifiedPaymentsPilot.All;

            Assert.IsTrue(_providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage()
                .IsPaymentsPilotLearnerDisplayed(filterValue));
        }

        [Given(@"Provider searches for the learner on Manage your apprentice page")]
        [Then(@"Provider searches for the learner on Manage your apprentice page")]
        public void ProviderSearchesLearnerOnManageYourApprenticesPage()
        {
            _providerApprenticeDetailsPage = _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails();
        }

        [Then(@"Provider can review the Change of Price request and approve it")]
        public void ThenProviderCanReviewTheChangeOfPriceRequestAndApproveIt()
        {
            var newTotalPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingCost) - 500;
            var trainingPrice = (newTotalPrice * 80)/100;
            var epa = newTotalPrice - trainingPrice;
            
            ProviderSearchesLearnerOnManageYourApprenticesPage();
            ProviderIsAbleToViewThePendingChangeOfPriceRequest();
            ProviderCanViewTheDetailsOfTheChangeOfPriceRequest();

            new ChangeOfPriceReviewChangeRequestPage(context)
                .SelectApproveChangesRadioButtonAndSend()
                .EnterTrainingAndEndpointAssessmentPrices(trainingPrice.ToString(),epa.ToString())
                .ValidatePriceChangeApprovedBannerDisplayed();
        }

        [Then(@"Provider (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenProviderIsUnableToMakeAnyChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            SetApprenticeDetailsInContext(learnerNumber);

            new ProviderManageYourApprenticesPage(context).SelectViewCurrentApprenticeDetails().ValidateProviderEditApprovedApprentice(action == "can");
        }

        [When(@"Provider proceeds to create a Change of Price request for flexi payments pilot learner")]
        [Then(@"Provider proceeds to create a Change of Price request for flexi payments pilot learner")]
        public void ProviderProceedsToCreateAChangeOfPriceRequestForFlexiPaymentsPilotLearner()=> _providerApprenticeDetailsPage.ClickChangePriceLink();

        [When(@"Provider proceeds to create a Change of Start Date request for flexi payments pilot learner")]
        public void ProviderProceedsToCreateAChangeOfStartDateRequestForFlexiPaymentsPilotLearner() => _providerApprenticeDetailsPage.ClickChangeStartDateLink();


        [When(@"Provider creates a Change of Price request where Training Price is increased by (.*)")]
        [Then(@"Provider creates a Change of Price request where Training Price is increased by (.*)")]
        public void ProviderCreatesAChangeOfPriceRequestWhereTrainingPriceIsIncreasedBy(int priceIncrease)
        {
            newTrainingPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingPrice) + priceIncrease;

            context.Set(newTrainingPrice, "NewTrainingPrice");

            new ChangePriceNegotiationAmountsPage(context).EnterValidChangeOfPriceDetails
                (newTrainingPrice.ToString(), _apprenticeDataHelper.EndpointAssessmentPrice, DateTime.Today, context.ScenarioInfo.Title)
                .ClickSendButton()
                .ValidateChangeOfPriceRequestRaisedSuccessfully();
        }

        [Then(@"Provider successfully creates a Change of Start Date request")]
        public void ThenProviderSuccessfullyCreatesAChangeOfStartDateRequest()
        {
            new ChangeTrainingStartDatePage(context).EnterValidChangeOfPriceDetails(DateTime.Today.Date, context.ScenarioInfo.Title)
                .ValidateChangeOfStartDateRequestRaisedSuccessfully();
        }



        [When(@"Provider creates a Change of Price request where Training Price for the apprenticeship is reduced by (.*)")]
        public void ProviderCreatesAChangeOfPriceRequestWhereTotalPriceForTheApprenticeshipIsReducedBy(int priceReduction)
        {
            newTrainingPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingPrice) - priceReduction;

            context.Set(newTrainingPrice, "NewTrainingPrice");

            new ChangePriceNegotiationAmountsPage(context).EnterValidChangeOfPriceDetails
                (newTrainingPrice.ToString(), _apprenticeDataHelper.EndpointAssessmentPrice, DateTime.Today, context.ScenarioInfo.Title, true)
                .ValidateEmployerDoesNotNeedToApproveRequestHeadingDisplayed()
                .ClickSendButton()
                .ValidatePriceChangeAutoApprovedBannerDisplayed();
        }

        [When(@"Provider creates a Change of Price request where Total price remains the same")]
        public void ProviderCreatesAChangeOfPriceRequestWhereTotalPriceRemainsTheSame()
        {
            newTrainingPrice = Convert.ToDecimal(_apprenticeDataHelper.TrainingPrice) - 500;
            newEndpointAssessmentPrice = Convert.ToDecimal(_apprenticeDataHelper.EndpointAssessmentPrice) + 500;

            context.Set(newTrainingPrice, "NewTrainingPrice");
            context.Set(newEndpointAssessmentPrice, "NewEndpointAssessmentPrice");

            new ChangePriceNegotiationAmountsPage(context).EnterValidChangeOfPriceDetails
                (newTrainingPrice.ToString(), newEndpointAssessmentPrice.ToString(), DateTime.Today, context.ScenarioInfo.Title, true)
                .ValidateEmployerDoesNotNeedToApproveRequestHeadingDisplayed()
                .ClickSendButton()
                .ValidatePriceChangeAutoApprovedBannerDisplayed();
        }


        [Then(@"Provider is able to view the pending Change of Price request")]
        public void ProviderIsAbleToViewThePendingChangeOfPriceRequest()
        {
            _providerApprenticeDetailsPage.ValidatePriceChangePendingBannerDisplayed();
        }

        [Then(@"Provider can view the details of the Change of Price request")]
        public void ProviderCanViewTheDetailsOfTheChangeOfPriceRequest()
        {
            _providerApprenticeDetailsPage.ClickReviewPriceChangeLink();
        }

        [Then(@"Provider is able to successfully reject the Change of Price request")]
        public void ProviderIsAbleToSuccessfullyRejectTheChangeOfPriceRequest()
        {
            new ChangeOfPriceReviewChangeRequestPage(context)
                .SelectRejectChangesRadioButtonAndSend(context.ScenarioInfo.Title)
                .ValidatePriceChangeRejectedBannerDisplayed();
        }

        [Then(@"Provider is able to view details of change of price request")]
        public void ProviderIsAbleToViewDetailsOfChangeOfPriceRequest()
        {
            _providerApprenticeDetailsPage.ClickViewPriceChangesRequestedLink();

            var totalPrice = newTrainingPrice + Convert.ToDecimal(_apprenticeDataHelper.EndpointAssessmentPrice);

            _viewPriceChangeRequestPage = new ChangeOfPriceViewChangeRequestPage(context).VerifyPendingEmployerReviewTagIsDisplayed()
                .ValidateRequestedValues(newTrainingPrice, Convert.ToDecimal(_apprenticeDataHelper.EndpointAssessmentPrice), totalPrice, DateTime.Now, context.ScenarioInfo.Title);          
        }

        [Then(@"Provider is able to view details of change of Start Date request")]
        public void ThenProviderIsAbleToViewDetailsOfChangeOfStartDateRequest()
        {
            _providerApprenticeDetailsPage.ClickViewPendingStartDateLink();

            _viewChangeOfStartDateRequestPage = new ViewChangeOfStartDate(context).VerifyPendingEmployerReviewTagIsDisplayed()
                .ValidateRequestedValues(DateTime.Today.Date, context.ScenarioInfo.Title);
        }


        [Then(@"Provider can successfully cancel the change of price request")]
        public void ThenProviderCanSuccessfullyCancelTheChangeOfPriceRequest()
        {
            _viewPriceChangeRequestPage.SelectCancelTheRequestRadioButtonAndContinue()
                .ValidateChangeOfPriceRequestCancelledSuccessfully();
        }

        [When(@"Provider submits change of price form without changing input fields")]
        public void WhenProviderSubmitsChangeOfPriceFormWithoutChangingInputFields()
        {
            _changePriceNegotiationAmountPage = new ChangePriceNegotiationAmountsPage(context).ClickContinueButtonWithValidationErrors();
        }

        [When(@"Provider submits change of start date form without changing input fields")]
        public void ProviderSubmitsChangeOfStartDateFormWithoutChangingInputFields()
        {
            _changeTrainingStartDatePage = new ChangeTrainingStartDatePage(context).ClickContinueButtonWithValidationErrors();
        }

        [Then(@"all default change of price validation errors are displayed to the Provider")]
        public void AllDefaultChangeOfPriceValidationErrorsAreDisplayedToTheProvider()
        {
            _changePriceNegotiationAmountPage.ConfirmValidationErrorMessagesDisplayed();
        }

        [Then(@"all default change of start date validation errors are displayed to the Provider")]
        public void AllDefaultChangeOfStartDateValidationErrorsAreDisplayedToTheProvider()
        {
            _changeTrainingStartDatePage.ConfirmDefaultValidationErrorMessagesDisplayed();
        }


        [Then(@"validate Training Price and EPA price must be between (.*) and (.*)")]
        public void ValidateTrainingPriceAndEPAPriceMustBeBetweenValues(int min, int max)
        {
            _changePriceNegotiationAmountPage.ValidateOuterBoundaryValuesErrorsForTrainingAndEPAPrices(min - 1);

            _changePriceNegotiationAmountPage.ValidateOuterBoundaryValuesErrorsForTrainingAndEPAPrices(max + 1);
        }

        [Then(@"a dynamic Total price field is displayed with the sum of Training price and End-point assessment price")]
        public void DynamicTotalPriceFieldIsDisplayedWithTheSumOfTrainingPriceAndEnd_PointAssessmentPrice()
        {
            _changePriceNegotiationAmountPage.ValidateApprenticeshipTotalPrice();
        }


        [Then(@"validate Effective From Date cannot be before Training Start Date")]
        public void ValidateEffectiveFromDateCannotBeBeforeTrainingStartDate()
        {
            var date = _apprenticeCourseDataHelper.CourseStartDate.AddDays(-1);
            _changePriceNegotiationAmountPage.ValidateEnterADateThatIsAfterTrainingStartDateErrorMessage(date);
        }

        [Then(@"validate Effective From Date cannot be after Training End Date")]
        public void ThenValidateEffectiveFromDateCannotBeAfterTrainingEndDate()
        {
            var date = _apprenticeCourseDataHelper.CourseEndDate.AddDays(1);
            _changePriceNegotiationAmountPage.ValidateEnterADateThatIsBeforePlannedEndDateErrorMessage(date);
        }

        [Then(@"validate provider (can|cannot) view Pilot DataLock message")]
        public void ThenValidateProviderCanViewPilotDataLockMessage(string action)
        {
            _providerCommonStepsHelper.GoToProviderHomePage(false)
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ValidateFlexiPaymentDataLockMessageDisplayed(action == "can");
        }

        [Then(@"validate Training Price and EPA price have been reset with blue warning message displayed")]
        public void ThenValidateTrainingPriceAndEPAPriceHaveBeenResetWithBlueWarningMessageDisplayed() => _providerApproveApprenticeDetailsPage.ValidateTrainingPriceAndEPAValuesHaveBeenReset();

        [Then(@"verify training provider cannot approve the cohort")]
        public void ThenValidateCohortCannotBeApproved() => _providerApproveApprenticeDetailsPage.VerifyRadioOptionToApproveCohortIsNotDisplayed();

        internal void SetApprenticeDetailsInContext(int learnerNumber) => _replaceApprenticeDataHelper.ReplaceApprenticeDataInContext(learnerNumber - 1);
    }
}
