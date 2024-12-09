using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
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
        private static By ViewChangesLink => By.LinkText("View changes");
        private static By ViewDetailsLink => By.LinkText("View details");
        private static By TriageLinkRestartLink => By.LinkText("View course mismatch");
        private static By TriageLinkUpdateLink => By.LinkText("View price mismatch");
        private static By DeliveryModel => By.Id("apprentice-deliverymodel");
        private static By SimplifiedPaymentsPilotNotificationMessage => By.Id("fix-data-mismatch-email");
        private static By ChangePriceLink => By.Id("linkChangePrice");
        private static By ChangeStartDateLink => By.Id("linkChangeStartDate");
        private static By ChangeOptionLink => By.XPath("/html/body/div[3]/main/div/div/table[3]/tbody/tr[7]/td[2]/a");
        private static By ChangeVersionLink => By.XPath("/html/body/div[3]/main/div/div/table[3]/tbody/tr[6]/td[2]/a");
        private static By ChangeOfPriceRequestSentBanner => By.Id("change-of-price-request-sent-banner");
        private static By ChangeOfStartDateRequestSentBanner => By.Id("change-of-startdate-request-sent-banner");
        private static By ChangeOfPriceRequestSentBannerMessage => By.CssSelector("#change-of-price-request-sent-banner h3");
        private static By ChangeOfStartDateRequestSentBannerMessage => By.CssSelector("#change-of-startdate-request-sent-banner h3");
        private static By ViewDateChangeYouHaveRequestLinkBanner => By.Id("linkViewPendingStartDateBanner");
        private static By ViewPendingStartDateLink => By.Id("linkViewPendingStartDate");
        private static By ChangeOfStartDatePendingRequestTag => By.CssSelector("#pendingStartDateChangeSection strong.govuk-tag.govuk-tag--yellow");
        private static By PriceChangesRequestedHeading => By.XPath("//h2[contains(text(),\"Price changes you've requested\")]");
        private static By ViewPriceChangesLink => By.Id("linkViewPendingPrice");
        private static By PriceChangeCancelledBanner => By.Id("price-change-cancelled-banner");
        private static By StartDateChangeCancelledBanner => By.Id("startdate-change-cancelled-banner");
        private static By PriceChangeCancelBannerMessage => By.CssSelector("#price-change-cancelled-banner h3");
        private static By StartDateChangeCancelBannerMessage => By.CssSelector("#startdate-change-cancelled-banner h3");
        private static By PriceChangePendingBanner => By.CssSelector("div[aria-labelledby='govuk-notification-banner-title']");
        private static By PriceChangeApprovedBanner => By.Id("change-of-price-approved-banner");
        private static By PriceChangeRejectedBanner => By.Id("change-of-price-rejected-banner");
        private static By PriceChangeAutoApprovedBanner => By.Id("change-of-price-auto-approved-banner");
        private static By ReviewPriceChangeRequestedBannerLink => By.Id("linkBannerViewPendingPrice");
        private static By ChangeRequestedTag => By.XPath("//strong[contains(text(),'Change requested')]");
        private static By ReviewPriceChangeLink => By.Id("linkViewPendingPrice");
        private static By ProviderPaymentStatusRowHeading => By.XPath("//td[@id='provider-payments-status']/preceding-sibling::th");
        private static By ProviderPaymentStatusValue => By.Id("provider-payments-status");
        private static By LearnerStatusRowHeading => By.XPath("//td[@id='apprenticeship-learner-status']/preceding-sibling::th");
        private static By LearnerStatusValue => By.CssSelector("#apprenticeship-learner-status strong");
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

        public SelectAStandardOptionpage ClickChangeOptionLink()
        {
            formCompletionHelper.Click(ChangeOptionLink);
            return new SelectAStandardOptionpage(context);
        }

        public SelectAStandardVersionPage ClickChangeVersionLink()
        {
            formCompletionHelper.Click(ChangeVersionLink);
            return new SelectAStandardVersionPage(context);
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

        public void ClickChangeStartDateLink() => formCompletionHelper.Click(ChangeStartDateLink);

        public ProviderApprenticeDetailsPage VerifyChangeStartDateLinkNotDisplayed()
        {
            Assert.IsFalse(pageInteractionHelper.IsElementDisplayedAfterPageLoad(ChangeStartDateLink), "Change of start date link is displayed after qualifying period");
            return this;
        }

        public void ClickViewPriceChangesRequestedLink() => formCompletionHelper.Click(ViewPriceChangesLink);

        public void ClickViewPendingStartDateLink() => formCompletionHelper.Click(ViewPendingStartDateLink);

        public void ValidateChangeOfPriceRequestRaisedSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeOfPriceRequestSentBanner), "Change of Price Request Sent banner not displayed");
                Assert.That(pageInteractionHelper.GetText(ChangeOfPriceRequestSentBannerMessage), Is.EqualTo("Request to change the price sent to employer"));
                Assert.That(pageInteractionHelper.IsElementDisplayed(PriceChangesRequestedHeading), "Price changes you've requested heading not displayed");
                Assert.That(pageInteractionHelper.IsElementDisplayed(ViewPriceChangesLink), "View price changes you've requested link is not displayed");
            }
            );
        }

        public void ValidateChangeOfStartDateRequestRaisedSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateRequestSentBanner), "Change of Start Date Request Sent banner not displayed");
                Assert.That(pageInteractionHelper.GetText(ChangeOfStartDateRequestSentBannerMessage), Is.EqualTo("Request to change the training date sent to employer"));
                Assert.That(pageInteractionHelper.IsElementDisplayed(ViewDateChangeYouHaveRequestLinkBanner), "Request to change the training date sent to employer heading not displayed in the banner");
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDatePendingRequestTag), "Pending request tag for Change of Start Date not displayed");
                Assert.That(pageInteractionHelper.IsElementDisplayed(ViewPendingStartDateLink), "View request link for Change of Start Date not displayed");
            }
            );
        }

        public void ValidateChangeOfPriceRequestCancelledSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(PriceChangeCancelledBanner), "Price Change Cancelled banner not displayed");
                Assert.That(pageInteractionHelper.GetText(PriceChangeCancelBannerMessage), Is.EqualTo("Your request to change the price has been cancelled"));
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangePriceLink), "Price change link not displayed");
            }
           );
        }

        public void ValidateChangeOfStartDateRequestCancelledSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(StartDateChangeCancelledBanner), "Start Date Change Cancelled banner not displayed");
                Assert.That(pageInteractionHelper.GetText(StartDateChangeCancelBannerMessage), Is.EqualTo("Your request to change the start date has been cancelled"));
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeStartDateLink), "Start Date change link not displayed");
            }
           );
        }

        public ProviderApprenticeDetailsPage ValidatePriceChangePendingBannerDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangePendingBanner), "Price Change Pending banner not displayed");
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ReviewPriceChangeRequestedBannerLink), "Review Price Change Requested link not displayed inside banner");
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeRequestedTag), "Change Requested tag for Change of Price request is missing");
            }
            );
            return this;
        }

        public ProviderApprenticeDetailsPage ValidatePriceChangeRejectedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangeRejectedBanner), "Price Change Rejected banner not displayed");
            Assert.False(pageInteractionHelper.IsElementDisplayed(ReviewPriceChangeLink), "Review price change link still displayed after the request was rejected");
            return this;
        }

        public ProviderApprenticeDetailsPage ValidatePriceChangeApprovedBannerDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangeApprovedBanner), "Price Change Approved banner not displayed");
                Assert.False(pageInteractionHelper.IsElementDisplayed(ReviewPriceChangeLink), "Review price change link still displayed after the request was approved");
            }
            );
            return this;
        }

        public ProviderApprenticeDetailsPage ValidatePriceChangeAutoApprovedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangeAutoApprovedBanner), "Price Change Auto Approved banner not displayed");
            return this;
        }

        public void ClickReviewPriceChangeLink() => formCompletionHelper.ClickElement(ReviewPriceChangeLink);

        public ProviderApprenticeDetailsPage ValidateProviderPaymentStatus(string status)
        {
            Assert.AreEqual("Provider payments status", pageInteractionHelper.GetText(ProviderPaymentStatusRowHeading), "Provider Payment status label not displayed");
            Assert.AreEqual(status, pageInteractionHelper.GetText(ProviderPaymentStatusValue), "Incorrect Provider payment status found!");

            return this;
        }

        public ProviderApprenticeDetailsPage ValidateLearnerStatus(string status)
        {
            string expectedLearnerStatus = status.ToUpper() switch
            {
                "INLEARNING" => "In learning",
                "WAITINGTOSTART" => "Waiting to start",
                _ => status
            };

            Assert.AreEqual("Learner Status", pageInteractionHelper.GetText(LearnerStatusRowHeading), "Learner status row not displayed");
            Assert.AreEqual(expectedLearnerStatus, pageInteractionHelper.GetText(LearnerStatusValue), "Incorrect Learner status found!");

            string expectedClass = status.ToUpper() switch
            {
                "INLEARNING" => "govuk-tag--blue",
                "WAITINGTOSTART" => "govuk-tag--green",
                _ => "govuk-tag--blue"
            };

            Assert.IsTrue(pageInteractionHelper.ElementHasClass(LearnerStatusValue, expectedClass),
                $"The element does not have the expected class '{expectedClass}' for status '{status}'.");


            return this;
        }
    }
}
