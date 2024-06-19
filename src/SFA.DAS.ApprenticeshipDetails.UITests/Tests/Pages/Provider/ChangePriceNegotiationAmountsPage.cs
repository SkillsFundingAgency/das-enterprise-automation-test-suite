using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ChangePriceNegotiationAmountsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change the training price and/or the end-point assessment price";
        protected override By ContinueButton => By.Id("buttonSubmitForm");
        public static By TrainingPrice => By.Id("ApprenticeshipTrainingPrice");
        public static By EndpointAssessmentPrice => By.Id("ApprenticeshipEndPointAssessmentPrice");
        public static By TotalPrice => By.Id("ApprenticeshipTotalPrice");

        public static By EffectiveFromDate_Day => By.Id("EffectiveFromDate_Day");

        public static By EffectiveFromDate_Month => By.Id("EffectiveFromDate_Month");

        public static By EffectiveFromDate_Year => By.Id("EffectiveFromDate_Year");

        public static By ReasonPriceChange => By.Id("ReasonForChangeOfPrice");

        private static By ChangeTrainingAndOrEpaPriceErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipTrainingPrice']");
        private static By EffectiveFromDateErrorMessage => By.CssSelector("div[role='alert'] li a[href='#EffectiveFromDate']");

        private static By EnterAReasonErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ReasonForChangeOfPrice']");

        private static By TrainingPriceMustBeAWholeNumberErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipTrainingPrice']");

        private static By EndPointAssessmentPriceMustBeAWholeNumberErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipEndPointAssessmentPrice']");

        private static string ChangeTrainingAndOrEpaPriceErrorText => "You must change the training price and/or the end-point assessment price";

        private static string EnterADateErrorText => "Enter a date in the correct format";

        private static string EnterAReasonErrorText => "You must enter a reason for requesting a price change. This will help the employer when they review your request.";

        private static string TrainingPriceMustBeAWholeNumberErrorText => "The training price must be a whole number between 1 - 100,000";

        private static string EndPointAssessmentPriceMustBeAWholeNumberErrorText => "The end-point assessment price must be a whole number between 1 - 100,000";

        private static string EnterDateAfterTrainingStartDateErrorText => "Enter a date that is after the training start date";

        private static string EnterDateBeforePlannedEndDateErrorText => "The date entered must be before the planned end date";

        public ChangePriceNegotiationAmountsPage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public CheckYourChangesBeforeSendingToEmployerPage EnterValidChangeOfPriceDetails(string trainingPrice, string epaPrice, DateTime effectiveFrom, string reason, bool isAutoApprove = false)
        {
            formCompletionHelper.EnterText(TrainingPrice, trainingPrice);
            formCompletionHelper.EnterText(EndpointAssessmentPrice, epaPrice);
            formCompletionHelper.EnterText(EffectiveFromDate_Day, effectiveFrom.Day);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, effectiveFrom.Month);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, effectiveFrom.Year);
            formCompletionHelper.EnterText(ReasonPriceChange, reason);

            formCompletionHelper.Click(ContinueButton);
            return new CheckYourChangesBeforeSendingToEmployerPage(context, isAutoApprove);
        }

        public ChangePriceNegotiationAmountsPage ClickContinueButtonWithValidationErrors()
        {
            formCompletionHelper.Click(ContinueButton);
            return this;
        }

        public void ConfirmValidationErrorMessagesDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(pageInteractionHelper.GetText(ChangeTrainingAndOrEpaPriceErrorMessage), ChangeTrainingAndOrEpaPriceErrorText);
                Assert.AreEqual(pageInteractionHelper.GetText(EffectiveFromDateErrorMessage), EnterADateErrorText);
                Assert.AreEqual(pageInteractionHelper.GetText(EnterAReasonErrorMessage), EnterAReasonErrorText);
            });
        }

        public void ValidateOuterBoundaryValuesErrorsForTrainingAndEPAPrices(int value)
        {
            formCompletionHelper.EnterText(TrainingPrice, value);
            formCompletionHelper.EnterText(EndpointAssessmentPrice, value);

            ClickContinueButtonWithValidationErrors();

            ValidateTrainingAndEPAPricesBoundaryValuesErrorMessagesAreDisplayed();
        }

        public void ValidateEnterADateThatIsAfterTrainingStartDateErrorMessage(DateTime date)
        {
            formCompletionHelper.EnterText(EffectiveFromDate_Day, date.Day);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, date.Month);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, date.Year);

            ClickContinueButtonWithValidationErrors();

            Assert.AreEqual(pageInteractionHelper.GetText(EffectiveFromDateErrorMessage), EnterDateAfterTrainingStartDateErrorText);
        }

        public void ValidateEnterADateThatIsBeforePlannedEndDateErrorMessage(DateTime date)
        {
            formCompletionHelper.EnterText(EffectiveFromDate_Day, date.Day);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, date.Month);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, date.Year);

            ClickContinueButtonWithValidationErrors();

            Assert.AreEqual(pageInteractionHelper.GetText(EffectiveFromDateErrorMessage), EnterDateBeforePlannedEndDateErrorText);
        }

        private void ValidateTrainingAndEPAPricesBoundaryValuesErrorMessagesAreDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(pageInteractionHelper.GetText(TrainingPriceMustBeAWholeNumberErrorMessage), TrainingPriceMustBeAWholeNumberErrorText);
                Assert.AreEqual(pageInteractionHelper.GetText(EndPointAssessmentPriceMustBeAWholeNumberErrorMessage), EndPointAssessmentPriceMustBeAWholeNumberErrorText);
            });
        }

        public void ValidateApprenticeshipTotalPrice()
        {
            formCompletionHelper.EnterText(TrainingPrice, 3000);
            formCompletionHelper.EnterText(EndpointAssessmentPrice, 1000);

            var totalPrice = pageInteractionHelper.GetText(TotalPrice);

            Assert.AreEqual("£4000", totalPrice);
        }
    }
}
