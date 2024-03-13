using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerChangeOfPriceViewChangeRequestPage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "View change request";

        private static By TotalPriceRequestedValue => By.Id("TotalPrice");
        private static By PendingProviderReviewTag => By.XPath("//strong[text()='Pending provider review']");
        private static By TotalPriceCurrentValue => By.XPath("//*[@id='TotalPrice']/preceding-sibling::*[1]");
        private static By EffectiveFromDateValue => By.Id("EffectiveFromDate");
        private static By ReasonForChangeValue => By.Id("ReasonForChange");
        private static By ApproveChangesRadioOption => By.Id("option-yes");
        private static By RejectChangesRadioOption => By.Id("option-no");
        private static By RejectReasonInputField => By.Id("rejectReason");
        protected static By SendButton => By.Id("buttonSubmitForm");
        private static By CancelRequestOptionYes => By.Id("option-yes");

        public EmployerChangeOfPriceViewChangeRequestPage ValidateRequestValues(decimal totalPrice, DateTime effectiveFromDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(totalPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(TotalPriceRequestedValue), "Requested Total Price mismatch");
                Assert.AreEqual(effectiveFromDate.ToString("dd MMMM yyyy"), pageInteractionHelper.GetText(EffectiveFromDateValue), "Effective From Date mismatch");
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

        public EmployerChangeOfPriceViewChangeRequestPage VerifyPendingProviderReviewTagIsDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PendingProviderReviewTag), "Pending Provider Review tag not displayed");
            return this;
        }

        public ApprenticeDetailsPage SelectCancelTheRequestRadioButtonAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CancelRequestOptionYes);
            formCompletionHelper.Click(ContinueButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}

