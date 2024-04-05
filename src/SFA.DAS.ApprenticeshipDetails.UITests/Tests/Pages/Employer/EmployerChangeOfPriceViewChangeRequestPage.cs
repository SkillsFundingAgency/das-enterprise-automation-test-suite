using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Employer
{
    public class EmployerChangeOfPriceViewChangeRequestPage(ScenarioContext context) : ChangeOfPriceViewChangeRequestPage(context)
    {
        protected override string PageTitle => "View change request";
        private static By PendingProviderReviewTag => By.XPath("//strong[text()='Pending provider review']");
        private static By TotalPriceCurrentValue => By.XPath("//*[@id='TotalPrice']/preceding-sibling::*[1]");
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

        public EmployerChangeOfPriceViewChangeRequestPage VerifyPendingProviderReviewTagIsDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PendingProviderReviewTag), "Pending Provider Review tag not displayed");
            return this;
        }

        public new ApprenticeDetailsPage SelectCancelTheRequestRadioButtonAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CancelRequestOptionYes);
            formCompletionHelper.Click(ContinueButton);
            return new ApprenticeDetailsPage(context);
        }
    }
}

