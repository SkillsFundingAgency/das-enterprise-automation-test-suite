using Azure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages
{
    public class ChangeOfPriceViewChangeRequestPage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "View change request";
        private static By PendingEmployerReviewTag => By.XPath("//strong[text()='Pending employer review']");
        private static By TrainingPriceRequestedValue => By.Id("Trainingprice");
        private static By TrainingPriceCurrentValue => By.XPath("//*[@id='Trainingprice']/preceding-sibling::*[1]");
        private static By EndPointAssessmentPriceRequestedValue => By.Id("EndPointAssessmentPrice");
        private static By EndPointAssessmentPriceCurrentValue => By.XPath("//*[@id='EndPointAssessmentPrice']/preceding-sibling::*[1]");
        private static By TotalPriceRequestedValue => By.Id("TotalPrice");
        private static By TotalPriceCurrentValue => By.XPath("//*[@id='TotalPrice']/preceding-sibling::*[1]");
        private static By EffectiveFromDateValue => By.Id("EffectiveFromDate");
        private static By ReasonForChangeValue => By.Id("ReasonForChange");
        private static By CancelRequestOptionYes => By.Id("option-yes");
        private static By CancelRequestOptionNo => By.Id("option-no");

        public ChangeOfPriceViewChangeRequestPage VerifyPendingEmployerReviewTagIsDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PendingEmployerReviewTag), "Pending Employer Review tag not displayed");
            return this;
        }

        public ChangeOfPriceViewChangeRequestPage ValidateRequestedValues(decimal trainingPrice, decimal endPointAssessmentPrice, decimal totalPrice, DateTime effectiveFromDate, string reason)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(trainingPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(TrainingPriceRequestedValue), "Requested Training Price mismatch");
                Assert.AreEqual(endPointAssessmentPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(EndPointAssessmentPriceRequestedValue), "Requested Endpoint Assessment Price mismatch");
                Assert.AreEqual(totalPrice.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("en-GB")), pageInteractionHelper.GetText(TotalPriceRequestedValue), "Requested Total Price mismatch");
                Assert.AreEqual(effectiveFromDate.ToString("dd MMM yyyy"), pageInteractionHelper.GetText(EffectiveFromDateValue), "Effective From Date mismatch");
                Assert.AreEqual(reason, pageInteractionHelper.GetText(ReasonForChangeValue), "Requested reason mismatch");
            });
            return this;
        }

        public ProviderApprenticeDetailsPage SelectKeepTheRequestRadioButtonAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CancelRequestOptionNo);
            return new ProviderApprenticeDetailsPage(context);
        }

        public ProviderApprenticeDetailsPage SelectCancelTheRequestRadioButtonAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByLocator(CancelRequestOptionYes);
            formCompletionHelper.Click(ContinueButton);
            return new ProviderApprenticeDetailsPage(context);
        }

    }

}