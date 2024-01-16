using NUnit.Framework;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages;
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
        private ApprenticeCourseDataHelper _apprenticeCourseDataHelper = context.GetValue<ApprenticeCourseDataHelper>();
        private ApprenticeDataHelper _apprenticeDataHelper = context.GetValue<ApprenticeDataHelper>();

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
        public void ProviderSearchesLearnerOnManageYourApprenticesPage()
        {
            _providerApprenticeDetailsPage = _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails();
        }


        [Then(@"Provider (can|cannot) make changes to fully approved learner (.*)")]
        public void ThenProviderIsUnableToMakeAnyChangesToFullyApprovedLearner(string action, int learnerNumber)
        {
            SetApprenticeDetailsInContext(learnerNumber);

            new ProviderManageYourApprenticesPage(context).SelectViewCurrentApprenticeDetails().ValidateProviderEditApprovedApprentice(action == "can");
        }

        [When(@"Provider proceeds to create a Change of Price request for flexi payments pilot learner")]
        public void ProviderProceedsToCreateAChangeOfPriceRequestForFlexiPaymentsPilotLearner()
        {
            _providerApprenticeDetailsPage.ClickChangePriceLink();
        }

        [When(@"Provider successfully creates a Change of Price request")]
        public void ProviderSuccessfullyCreatesAChangeOfPriceRequest()
        {
            new ChangePriceNegotiationAmountsPage(context).EnterValidChangeOfPriceDetails
                (_apprenticeDataHelper.TrainingPrice, _apprenticeDataHelper.EndpointAssessmentPrice, DateTime.Today, "FLP_CoC_02_Test")
                .ClickSendButton();

            _providerApprenticeDetailsPage.ValidateChangeOfPriceRequestRaisedSuccessfully();
        }


        [When(@"Provider submits change of price form without changing input fields")]
        public void WhenProviderSubmitsChangeOfPriceFormWithoutChangingInputFields()
        {
            _changePriceNegotiationAmountPage = new ChangePriceNegotiationAmountsPage(context).ClickContinueButtonWithValidationErrors();
        }

        [Then(@"all default validation errors are displayed to the Provider")]
        public void ThenValidationErrorsAreDisplayedToTheProvider()
        {
            _changePriceNegotiationAmountPage.ConfirmValidationErrorMessagesDisplayed();
        }

        [Then(@"validate Training Price and EPA price must be between (.*) and (.*)")]
        public void ValidateTrainingPriceAndEPAPriceMustBeBetweenValues(int min, int max)
        {
            _changePriceNegotiationAmountPage.ValidateOuterBoundaryValuesErrorsForTrainingAndEPAPrices(min-1);

            _changePriceNegotiationAmountPage.ValidateOuterBoundaryValuesErrorsForTrainingAndEPAPrices(max+1);
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
