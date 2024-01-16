using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApprenticeDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => apprenticeDataHelper?.ApprenticeFullName;

        protected override string AccessibilityPageTitle => "Provider view apprentice full name";
        private static By ReviewChangesLink => By.LinkText("Review changes");
        private static By EditApprenticeDetailsLink => By.LinkText("Edit apprentice");
        private static By ViewIlrMismatchDetailsLink => By.LinkText("View details");
        private static By ChangeEmployerLink => By.Id("change-employer-link");
        private static By ChangeRequestHeading => By.XPath("//h2[contains(text(),'Changes to this apprenticeship')]");
        private static By ChangeRequestMessage => By.CssSelector("p.govuk-body");
        private static By Name => By.Id("apprentice-name");
        private static By DateOfBirth => By.Id("apprentice-dob");
        private static By Reference => By.Id("apprentice-reference");
        private static By ChangeOfPartyBanner => By.Id("change-of-party-status-text");
        private static By ViewChanges => By.Id("change-employer-link");
        private static By ViewChangesLink => By.LinkText("View changes");
        private static By ViewDetailsLink => By.LinkText("View details");
        private static By TriageLinkRestartLink => By.LinkText("View course mismatch");
        private static By TriageLinkUpdateLink => By.LinkText("View price mismatch");
        private static By DeliveryModel => By.Id("apprentice-deliverymodel");
        private static By SimplifiedPaymentsPilotNotificationMessage => By.Id("fix-data-mismatch-email");
        private static By ChangePriceLink => By.Id("linkChangePrice");
        private static By ChangeOfPriceRequestSentBanner => By.Id("change-of-price-request-sent-banner");
        private static By TrainingPricePendingTag => By.CssSelector("#apprentice-price strong.govuk-tag--yellow");
        private static string SimplifiedPaymentsPilotText => "Contact simplifiedpaymentspilot@education.gov.uk if the details on this page are incorrect. We aim to respond within 2 working days.";

        public ProviderReviewChangesPage ClickReviewChanges()
        {
            formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ProviderReviewChangesPage(context);
        }

        public ProviderEditApprenticeCoursePage EditApprentice()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderEditApprenticeCoursePage(context);
        }

        public ProviderEditApprenticeDetailsPage ClickEditApprenticeLink()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderEditApprenticeDetailsPage(context);
        }


        public ProviderAccessDeniedPage ClickEditApprenticeDetailsLinkGoesToAccessDenied()
        {
            ClickEditApprenticeDetailsLink();
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewIlrMismatchDetails()
        {
            formCompletionHelper.ClickElement(ViewIlrMismatchDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(context);
        }

        public ProviderInformPage ClickChangeEmployerLink()
        {
            formCompletionHelper.Click(ChangeEmployerLink);
            return new ProviderInformPage(context);
        }

        public ProviderAccessDeniedPage ClickChangeEmployerLinkGoesToAccessDenied()
        {
            formCompletionHelper.Click(ChangeEmployerLink);
            return new ProviderAccessDeniedPage(context);
        }

        public void ConfirmChangeRequestPendingMessage()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeRequestHeading));
            string confirmationMessgage = pageInteractionHelper.GetText(ChangeRequestMessage);
            pageInteractionHelper.VerifyText(confirmationMessgage, "Change request pending:");
        }

        public void ConfirmNameDOBAndReferenceChanged(string expectedName, DateTime expectedDateOfBirth, string expectedReference)
        {
            var actualName = pageInteractionHelper.GetText(Name);
            var actualDateOfBirth = DateTime.Parse(pageInteractionHelper.GetText(DateOfBirth));
            var actualReference = pageInteractionHelper.GetText(Reference);

            pageInteractionHelper.VerifyText(actualName, expectedName);
            pageInteractionHelper.VerifyText(actualDateOfBirth.ToString(), expectedDateOfBirth.ToString());
            pageInteractionHelper.VerifyText(actualReference, expectedReference.ToString());
        }

        public ProviderViewChangesPage ClickViewChangesLink()
        {
            formCompletionHelper.Click(ViewChanges);
            return new ProviderViewChangesPage(context);
        }

        public ProviderViewChangesPage ClickViewChanges()
        {
            formCompletionHelper.ClickElement(ViewChangesLink);
            return new ProviderViewChangesPage(context);
        }

        public ProviderDetailsOfILRDataMismatchPage ClickViewDetails()
        {
            formCompletionHelper.ClickElement(ViewDetailsLink);
            return new ProviderDetailsOfILRDataMismatchPage(context);
        }

        public bool IsCoELinkDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeEmployerLink);

        public string GetCoPBanner() => pageInteractionHelper.GetText(ChangeOfPartyBanner);

        public bool IsPricemismatchLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(TriageLinkUpdateLink);

        public bool IsCoursemismatchLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(TriageLinkRestartLink);

        private void ClickEditApprenticeDetailsLink() => formCompletionHelper.ClickElement(EditApprenticeDetailsLink);

        public ProviderApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(expected), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModel);

        public void ValidateProviderEditApprovedApprentice(bool isDisplayed)
        {
            string message() => isDisplayed ? "is NOT displayed" : "is displayed";

            Assert.That(pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink), Is.EqualTo(isDisplayed), $"Edit Apprentice Details link {message}");
        }

        public void ValidateFlexiPaymentDataLockMessageDisplayed(bool isDisplayed)
        {
            if (isDisplayed) Assert.That(pageInteractionHelper.GetText(SimplifiedPaymentsPilotNotificationMessage), Is.EqualTo(SimplifiedPaymentsPilotText), "Incorrect Pilot DLock message displayed");
            else Assert.That(!pageInteractionHelper.IsElementDisplayed(SimplifiedPaymentsPilotNotificationMessage));
        }

        public void ClickChangePriceLink() => formCompletionHelper.Click(ChangePriceLink);

        public void ValidateChangeOfPriceRequestRaisedSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeOfPriceRequestSentBanner), "Change of Price Request Sent banner not displayed");
                Assert.That(pageInteractionHelper.IsElementDisplayed(TrainingPricePendingTag), "Training Price Pending tag not displayed");
            }   
            );
        }
    }
}
