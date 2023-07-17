using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => apprenticeDataHelper?.ApprenticeFullName;
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
        private By FlashMsgBox => PanelTitle;

        private static By DeliveryModel => By.XPath("//*[@id='main-content']/div/div/table[3]/tbody/tr[2]/td");

        private static By OverlappingTrainingDateRequestLink => By.CssSelector("#overlapping-trainingDate-requests-link");
        public ApprenticeDetailsPage(ScenarioContext context) : base(context)  { }

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
    }
}