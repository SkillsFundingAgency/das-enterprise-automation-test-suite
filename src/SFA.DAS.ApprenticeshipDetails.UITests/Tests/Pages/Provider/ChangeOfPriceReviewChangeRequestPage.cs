using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public class ChangeOfPriceReviewChangeRequestPage(ScenarioContext context) : ChangeOfPriceViewChangeRequestPage(context)
    {
        protected override string PageTitle => "Review changes";
        private static By RejectReasonInputField => By.Id("rejectReason");
        private static By ApproveChangesRadioOption => By.Id("option-yes");
        private static By RejectChangesRadioOption => By.Id("option-no");

        public ChangeOfPriceReviewChangeRequestPage ValidateRequestedValues(decimal totalPrice, DateTime effectiveFromDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(totalPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(TotalPriceRequestedValue), "Requested Total Price mismatch");
                Assert.AreEqual(effectiveFromDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(EffectiveFromDateValue), "Effective From Date mismatch");
                Assert.AreEqual(reason, pageInteractionHelper.GetText(ReasonForChangeValue), "Requested reason mismatch");
            });
            return this;
        }

        public ConfirmNewTrainingAndEndpointAssessmentPricePage SelectApproveChangesRadioButtonAndSend()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ApproveChangesRadioOption);
            formCompletionHelper.Click(ContinueButton);
            return new ConfirmNewTrainingAndEndpointAssessmentPricePage(context);
        }

        public ApprenticeDetailsPage SelectRejectChangesRadioButtonAndSend(string reason)
        {
            formCompletionHelper.SelectRadioOptionByLocator(RejectChangesRadioOption);
            formCompletionHelper.EnterText(RejectReasonInputField, reason);
            formCompletionHelper.Click(ContinueButton);
            return new ApprenticeDetailsPage(context);
        }

    }

}