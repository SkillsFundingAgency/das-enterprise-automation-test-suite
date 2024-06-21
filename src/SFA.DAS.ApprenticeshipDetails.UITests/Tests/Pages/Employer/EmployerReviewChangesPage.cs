using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerReviewChangesPage(ScenarioContext context) : EmployerChangeOfPriceViewChangeRequestPage(context)
    {
        protected override string PageTitle => "Review changes";
        private static By ApproveChangesRadioOption => By.Id("option-yes");
        private static By RejectChangesRadioOption => By.Id("option-no");
        private static By RejectReasonInputField => By.Id("rejectReason");
        private static By TrainingStartDateNewValue => By.Id("TrainingStartDate-NewValue");
        private static By TrainingEndDateNewValue => By.Id("PlannedEndDate-NewValue");

        public EmployerReviewChangesPage ValidateChangeOfPriceRequestedValues(decimal totalPrice, DateTime effectiveFromDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(totalPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(TotalPriceRequestedValue), "Requested Total Price mismatch");
                Assert.AreEqual(effectiveFromDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(EffectiveFromDateValue), "Effective From Date mismatch");
                Assert.AreEqual(reason, pageInteractionHelper.GetText(ReasonForChangeValue), "Requested reason mismatch");
            });
            return this;
        }

        public EmployerReviewChangesPage ValidateChangeOfStartDateRequestedValues(DateTime newTrainingStartDate, DateTime newTrainingEndDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(newTrainingStartDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(TrainingStartDateNewValue), "New Training Start Date mismatch");
                Assert.AreEqual(newTrainingEndDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(TrainingEndDateNewValue), "New Training End Date mismatch");
                Assert.AreEqual(reason, pageInteractionHelper.GetText(ReasonForChangeValue), "Requested reason mismatch");
            });
            return this;
        }

        public ApprenticeDetailsPage SelectApproveChangesRadioButtonAndSend()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ApproveChangesRadioOption);
            formCompletionHelper.Click(SendButton);
            return new ApprenticeDetailsPage(context);
        }

        public ApprenticeDetailsPage SelectRejectChangesRadioButtonAndSend(string reason)
        {
            formCompletionHelper.SelectRadioOptionByLocator(RejectChangesRadioOption);
            formCompletionHelper.EnterText(RejectReasonInputField, reason);
            formCompletionHelper.Click(SendButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}

