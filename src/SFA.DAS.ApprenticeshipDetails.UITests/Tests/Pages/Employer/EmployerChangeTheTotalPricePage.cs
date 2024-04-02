using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerChangeTheTotalPricePage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "Change the total price";
        private static By PriceHintText => By.Id("apprenticeship-price-hint");

        private static By ChangeTotalPriceErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipTotalPrice']");
        private static By EffectiveFromDateErrorMessage => By.CssSelector("div[role='alert'] li a[href='#EffectiveFromDate']");
        private static By EnterAReasonErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ReasonForChangeOfPrice']");
        private static By TotalPriceValidationErrorMessage => By.CssSelector("div[role='alert'] li a[href='#ApprenticeshipTotalPrice']");
        private static By CurrentTotalPrice => By.CssSelector("div.govuk-inset-text");
        private static string ChangeTotalPriceErrorText => "You must change the total price";
        private static string EnterAReasonErrorText => "You must enter a reason for requesting a price change. This will help the training provider when they review your request.";
        private static string EnterADateErrorText => "Enter a date in the correct format";
        private static string TotalPriceMustBeAWholeNumberErrorText => "The total price must be a whole number between 1 - 100,000";
        private static string TotalPriceMustNotBrGreaterThanErrorText => "The total price must not be greater than 100,000";
        private static string EnterDateAfterTrainingStartDateErrorText => "Enter a date that is after the training start date";
        private static string EnterDateBeforePlannedEndDateErrorText => "The date entered must be before the planned end date";

        public EmployerChangeOfPriceCheckYourChangesPage EnterValidChangeOfPriceDetails(string totalPrice, DateTime effectiveFrom, string reason)
        {
            formCompletionHelper.EnterText(TotalPrice, totalPrice);
            formCompletionHelper.EnterText(EffectiveFromDate_Day, effectiveFrom.Day);
            formCompletionHelper.EnterText(EffectiveFromDate_Month, effectiveFrom.Month);
            formCompletionHelper.EnterText(EffectiveFromDate_Year, effectiveFrom.Year);
            formCompletionHelper.EnterText(ReasonPriceChange, reason);

            formCompletionHelper.Click(ContinueButton);
            return new EmployerChangeOfPriceCheckYourChangesPage(context);
        }

        public new EmployerChangeTheTotalPricePage ClickContinueButtonWithValidationErrors()
        {
            formCompletionHelper.Click(ContinueButton);
            return this;
        }

        public new void ConfirmValidationErrorMessagesDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(pageInteractionHelper.GetText(ChangeTotalPriceErrorMessage), ChangeTotalPriceErrorText);
                Assert.AreEqual(pageInteractionHelper.GetText(EffectiveFromDateErrorMessage), EnterADateErrorText);
                Assert.AreEqual(pageInteractionHelper.GetText(EnterAReasonErrorMessage), EnterAReasonErrorText);
            });
        }

        public void ValidateOuterBoundaryValueErrorForTotalPrice(int value)
        {
            formCompletionHelper.EnterText(TotalPrice, value);
            ClickContinueButtonWithValidationErrors();

            if (value < 1)
                Assert.AreEqual(pageInteractionHelper.GetText(TotalPriceValidationErrorMessage), TotalPriceMustBeAWholeNumberErrorText);
            else if (value > 100000)
                Assert.AreEqual(pageInteractionHelper.GetText(TotalPriceValidationErrorMessage), TotalPriceMustNotBrGreaterThanErrorText);
        }

        public void ValidateCurrentTotalPriceText(string totalPrice)
        {
            string expectedText = $"The current total price is £{totalPrice}.";
            Assert.AreEqual(pageInteractionHelper.GetText(CurrentTotalPrice), expectedText);
        }
    }
}
