using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => apprenticeDataHelper?.ApprenticeFullName;

        protected override string AccessibilityPageTitle => "Employer view apprentice full name";
        private static By ViewChangesLink => By.LinkText("View changes");
        private static By ReviewChangesLink => By.LinkText("Review changes");
        private static By ReviewCopChangesLink => By.Id("change-of-party-review-changes-link");
        private static By EditApprenticeStatusLink => By.LinkText("Edit status");
        private static By EditStopDateLink => By.LinkText("Edit");
        private static By EditEndDateLink => By.Id("edit-end-date-link");
        private static By EditApprenticeDetailsLink => By.CssSelector("#edit-apprentice-link");
        private static By ApprenticeshipStatus => By.CssSelector("#app-status tbody tr td");
        private static By StatusDateTitle => By.CssSelector("#app-status tbody tr:nth-child(2) th");
        private static By CompletionDate => By.Id("completionDate");
        private static By ChangeTrainingProviderLink => By.Id("change-training-provider-link");
        private static By AlertBox => By.CssSelector("p.govuk-body-s, p.govuk-notification-banner__heading");
        private static By FlashMsgBox => PanelTitle;
        private static By DeliveryModel => By.XPath("//*[@id='main-content']/div/div/table[3]/tbody/tr[2]/td");
        private static By OverlappingTrainingDateRequestLink => By.CssSelector("#overlapping-trainingDate-requests-link");
        private static By ChangePriceLink => By.Id("linkChangeApprenticeshipPrice");
        private static By ChangeOptionLink => By.Id("change-option-link");
        private static By ChangeVersionLink => By.XPath("/html/body/div[2]/main/div/div/table[3]/tbody/tr[2]/td[2]/a");
        private static By PriceChangePendingBanner => By.Id("price-change-pending-banner");
        private static By StartDateChangePendingBanner => By.Id("start-date-change-pending-banner");
        private static By ViewPendingStartDateChangeLinkBanner => By.Id("linkViewPendingStartDateBanner");
        private static By ChangeOfStartDatePendingRequestTag => By.CssSelector("#change-of-start-date strong");
        private static By ChangeOfStartDateReviewRequestLink => By.CssSelector("#change-of-start-date a");
        private static By PriceChangeRejectedBanner => By.Id("price-change-rejected-banner");
        private static By PriceChangeApprovedBanner => By.Id("price-change-approved-banner");
        private static By ChangeOfStartDateApprovedBanner => By.Id("change-approved-banner");
        private static By ChangeOfStartDateRejectedBanner => By.Id("startdate-change-rejected-banner");
        private static By ViewPriceChangeRequestBannerLink => By.Id("linkViewPendingPriceBanner");
        private static By PendingPriceChangeTag => By.XPath("//strong[text()='Pending']");
        private static By ReviewPriceChangeLink => By.Id("linkViewPendingPrice");
        private static By ChangeOfPriceRequestSentBanner => By.Id("change-of-price-request-sent-banner");
        private static By ChangeOfPriceRequestSentBannerMessage => By.CssSelector("#change-of-price-request-sent-banner h3");
        private static By PriceChangesRequestedHeading => By.XPath("//h2[contains(text(),\"Price change requested\")]");
        private static By ViewPriceChangeLink => By.Id("linkViewPendingPrice");
        private static By PriceChangeCancelledBanner => By.Id("cancelled-price-change-banner");
        private static By PriceChangeCancelBannerMessage => By.CssSelector("#cancelled-price-change-banner h3");
        private static By ProviderPaymentStatusRowHeading => By.XPath("//td[@id='provider-payments-status']/preceding-sibling::th");
        private static By ProviderPaymentStatusValue => By.Id("provider-payments-status");
        private static By ProviderPaymentsInactiveTemporaryBannerHeading => By.CssSelector("#provider-payments-inactive-banner h3");
        private static By ProviderPaymentsInactivePermanentBannerHeading => By.CssSelector("#provider-payments-inactive-permanent-banner h3");
        private static By LearnerStatusRowHeading => By.XPath("//th[text()='Learner Status']");
        private static By LearnerStatusValue => By.XPath("//th[text()='Learner Status']/parent::tr/td/strong");
        private static By ChangeProviderPaymentStatusLink => By.Id("linkChangePaymentStatus");

        public bool CanEditApprenticeDetails() => pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink);

        public EditApprenticeDetailsPage ClickEditApprenticeDetailsLink()
        {
            formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new EditApprenticeDetailsPage(context);
        }

        public ReviewChangesPage ClickReviewChanges()
        {
            formCompletionHelper.ClickElement(ReviewChangesLink);
            return new ReviewChangesPage(context);
        }

        public ChangeApprenticeStatusPage ClickEditStatusLink()
        {
            formCompletionHelper.ClickElement(EditApprenticeStatusLink);
            return new ChangeApprenticeStatusPage(context);
        }

        public ThisApprenticeshipTrainingStopPage ClickEditStopDateLink()
        {
            formCompletionHelper.ClickElement(EditStopDateLink);
            return new ThisApprenticeshipTrainingStopPage(context);
        }

        public bool VerifyIfChangeRequestWasApproved()
        {
            if (pageInteractionHelper.IsElementDisplayed(ViewChangesLink))
                throw new Exception("Change request was not approved");
            else
                return true;
        }

        public void VerifyApprenticeshipStatus(string status) => VerifyPageAfterRefresh(ApprenticeshipStatus, status);

        public string GetApprenticeshipStatus() => pageInteractionHelper.GetText(ApprenticeshipStatus);
        public string GetStatusDateTitle() => pageInteractionHelper.GetText(StatusDateTitle);
        public string GetCompletionDate() => pageInteractionHelper.GetText(CompletionDate);
        public bool IsEditApprenticeStatusLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditApprenticeStatusLink);
        public bool IsEditApprenticeDetailsLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink);
        public bool IsEditEndDateLinkVisible() => pageInteractionHelper.IsElementDisplayed(EditEndDateLink);
        public bool IsChangeOfProviderLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(ChangeTrainingProviderLink);
        public bool IsOverlappingTrainingDateRequestLinkDisplayed() => pageInteractionHelper.IsElementDisplayed(OverlappingTrainingDateRequestLink);
        public string GetAlertBanner() => pageInteractionHelper.GetText(AlertBox);
        public string GetFlashMsg() => pageInteractionHelper.GetText(FlashMsgBox);

        public ChangingTrainingProviderPage ClickOnChangeOfProviderLink()
        {
            formCompletionHelper.ClickElement(ChangeTrainingProviderLink);
            return new ChangingTrainingProviderPage(context);
        }

        public ViewChangesPage ClickViewChangesLink()
        {
            formCompletionHelper.Click(ViewChangesLink);
            return new ViewChangesPage(context);
        }

        public ViewChangesPage ClickReviewChangesLink()
        {
            formCompletionHelper.Click(ReviewCopChangesLink);
            return new ViewChangesPage(context);
        }

        public ApprenticeDetailsPage ValidateFlashMessage(string expectedMsg)
        {
            pageInteractionHelper.VerifyText(GetFlashMsg(), expectedMsg);
            return this;
        }

        public ApprenticeDetailsPage ValidateDeliveryModelDisplayed(string deliveryModel)
        {
            string expected = deliveryModel;
            string actual = GetDeliveryModel();
            Assert.IsTrue(actual.Contains(expected), $"Incorrect delivery model is displayed, expected {expected} but actual was {actual}");
            return this;
        }

        public string GetDeliveryModel() => pageInteractionHelper.GetText(DeliveryModel);

        public ApprenticeDetailsPage ValidateDeliveryModelNotDisplayed()
        {
            string actual = GetDeliveryModel();
            if (actual.Contains("Regular") || actual.Contains("Flexi-job agency") || actual.Contains("Portable flexi-job"))
            {
                throw new Exception("Apprentice details page references delivery model");
            }
            else return this;
        }

        public ConfirmWhenApprenticeshipTrainingStoppedPage ClickOnChangeOfOverlappingTrainingDateRequestLink()
        {
            formCompletionHelper.ClickElement(OverlappingTrainingDateRequestLink);
            return new ConfirmWhenApprenticeshipTrainingStoppedPage(context);
        }

        public ThisApprenticeshipEndDatePage ClickEndDateLink()
        {
            formCompletionHelper.ClickElement(EditEndDateLink);
            return new ThisApprenticeshipEndDatePage(context);
        }

        public void ValidateEmployerEditApprovedApprentice(bool isDisplayed)
        {
            string message() => isDisplayed ? "is NOT displayed" : "is displayed";

            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(EditApprenticeDetailsLink), Is.EqualTo(isDisplayed), $"Edit Apprentice Details link {message}");
                Assert.That(pageInteractionHelper.IsElementDisplayed(EditApprenticeStatusLink), Is.EqualTo(isDisplayed), $"Edit Apprentice Status link {message}");

            });
        }

        public ApprenticeDetailsPage ValidatePriceChangePendingBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangePendingBanner), "Price Change Pending banner not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ViewPriceChangeRequestBannerLink), "View Price Change Request link not displayed inside banner");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PendingPriceChangeTag), "Pending tag for Change of Price request is missing ");
            return this;
        }

        public ApprenticeDetailsPage ValidatePriceChangeRejectedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangeRejectedBanner), "Price Change Rejected banner not displayed");
            Assert.False(pageInteractionHelper.IsElementDisplayed(ReviewPriceChangeLink), "Review price change link still displayed after the request was rejected");
            return this;
        }

        public ApprenticeDetailsPage ValidatePriceChangeApprovedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(PriceChangeApprovedBanner), "Price Change Approved banner not displayed");
            Assert.False(pageInteractionHelper.IsElementDisplayed(ReviewPriceChangeLink), "Review price change link still displayed after the request was approved");
            return this;
        }

        public ApprenticeDetailsPage ValidateStartDateChangePendingBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(StartDateChangePendingBanner), "Start Date Change Pending banner not displayed");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ViewPendingStartDateChangeLinkBanner), "View request link not displayed inside Change of Start Date banner");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDatePendingRequestTag), "Pending request tag for Change of Start Date is missing ");
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateReviewRequestLink), "Review request link for Change of Start Date is missing ");
            return this;
        }

        public ApprenticeDetailsPage ValidateChangeOfStartDateRejectedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateRejectedBanner), "Change of Start Date Rejected banner not displayed");
            Assert.False(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateReviewRequestLink), "Change of Start date review link still displayed after the request was approved");
            return this;
        }

        public ApprenticeDetailsPage ValidateChangeOfStartDateApprovedBannerDisplayed()
        {
            Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateApprovedBanner), "Change of Start Date Approved banner not displayed");
            Assert.False(pageInteractionHelper.IsElementDisplayed(ChangeOfStartDateReviewRequestLink), "Change of Start date review link still displayed after the request was approved");
            return this;
        }

        public void ClickReviewPriceChangeLink() => formCompletionHelper.ClickElement(ReviewPriceChangeLink);
        public void ClickReviewStartDateChangeLink() => formCompletionHelper.ClickElement(ChangeOfStartDateReviewRequestLink);

        public void ClickChangePriceLink() => formCompletionHelper.Click(ChangePriceLink);

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

        public void ValidateChangeOfPriceRequestRaisedSuccessfully()
        {
            Assert.Multiple(() =>
            {
                Assert.That(pageInteractionHelper.IsElementDisplayed(ChangeOfPriceRequestSentBanner), "Change of Price Request Sent banner not displayed");
                Assert.That(pageInteractionHelper.GetText(ChangeOfPriceRequestSentBannerMessage), Is.EqualTo("Request to change the price sent to training provider"));
                Assert.That(pageInteractionHelper.IsElementDisplayed(PriceChangesRequestedHeading), "Price changes you've requested heading not displayed");
                Assert.That(pageInteractionHelper.IsElementDisplayed(ViewPriceChangeLink), "View change request link is not displayed");
            }
            );
        }

        public void ClickViewChangeRequestLink() => formCompletionHelper.Click(ViewPriceChangeLink);

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

        public ApprenticeDetailsPage ValidateProviderPaymentStatus(string status)
        {
            Assert.AreEqual("Provider payments status", pageInteractionHelper.GetText(ProviderPaymentStatusRowHeading), "Provider Payment status label not displayed");
            Assert.AreEqual(status, pageInteractionHelper.GetText(ProviderPaymentStatusValue), "Incorrect Provider payment status found!");

            return this;
        }

        public ApprenticeDetailsPage ValidateProviderPaymentsWithheldTemporaryBannerIsDisplayed()
        {
            Assert.AreEqual("Provider payments have been set to \"Withheld\"", pageInteractionHelper.GetText(ProviderPaymentsInactiveTemporaryBannerHeading));
            return this;
        }

        public ApprenticeDetailsPage ValidateProviderPaymentsWithheldPermanentBannerIsDisplayed()
        {
            Assert.AreEqual("Provider payments set to \"Withheld\" on the " + DateTimeExtensions.ToGdsHumanisedDate(DateTime.Today), pageInteractionHelper.GetText(ProviderPaymentsInactivePermanentBannerHeading));
            return this;
        }

        public ApprenticeDetailsPage ValidateLearnerStatus(string status)
        {
            string expectedLearnerStatus = status.ToUpper() switch
            {
                "INLEARNING" => "In learning",
                "WAITINGTOSTART" => "Waiting to start",
                _ => status
            };

            Assert.AreEqual("Learner Status", pageInteractionHelper.GetText(LearnerStatusRowHeading), "Learner Status label not displayed");
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

        public void ClickChangeProviderPaymentStatusLink() => formCompletionHelper.Click(ChangeProviderPaymentStatusLink);

    }
}