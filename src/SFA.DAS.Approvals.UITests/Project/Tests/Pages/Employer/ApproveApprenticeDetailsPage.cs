using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApproveApprenticeDetailsPage : ReviewYourCohort
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private static By ApproveMessage => By.CssSelector("#approve-details");
        private static By ReviewMessage => By.CssSelector("#send-details");
        private static By SaveSubmit => By.CssSelector("#main-content .govuk-button");
        private static By AddAnotherApprenticeLink => By.LinkText("Add another apprentice");
        private static By CohortStatus => By.Id("cohortStatus");
        private static By NotificationBannerHeading => By.XPath("//p[@class='govuk-notification-banner__heading']");
        private static By ApproveRadioButton => By.Id("radio-approve");

        public ApproveApprenticeDetailsPage(ScenarioContext context) : base(context, (x) => x == 1 ? "Approve apprentice details" : $"Approve {x} apprentices' details") { }

        public EditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
            return new EditApprenticeDetailsPage(context);
        }

        public SelectStandardPage SelectAddAnotherApprentice()
        {
            AddAnApprentice();
            return new SelectStandardPage(context);
        }

        public ChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            AddAnApprentice();
            return new ChooseAReservationPage(context);
        }

        public ApprenticeRequestsPage SaveAndExit()
        {
            formCompletionHelper.ClickLinkByText("Save and exit");
            return new ApprenticeRequestsPage(context);
        }

        public ApprenticeDetailsApprovedAndSentToTrainingProviderPage EmployerFirstApproveAndNotifyTrainingProvider()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            formCompletionHelper.EnterText(ApproveMessage, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedAndSentToTrainingProviderPage(context);
        }

        public NotificationSentToTrainingProviderPage EmployerSendsToTrainingProviderForReview()
        {
            SelectRadioOptionByForAttribute("radio-send");
            formCompletionHelper.EnterText(ReviewMessage, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.Click(SaveSubmit);
            return new NotificationSentToTrainingProviderPage(context);
        }

        public ApprenticeDetailsApprovedPage EmployerDoesSecondApproval()
        {
            SelectRadioOptionByForAttribute("radio-approve");
            formCompletionHelper.Click(SaveSubmit);
            return new ApprenticeDetailsApprovedPage(context);
        }

        public ConfirmCohortDeletionPage SelectDeleteThisGroup()
        {
            formCompletionHelper.ClickLinkByText("Delete this group");
            return new ConfirmCohortDeletionPage(context);
        }

        private void AddAnApprentice() => formCompletionHelper.ClickLinkByText("Add another apprentice");

        public ApproveApprenticeDetailsPage IsAddApprenticeLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(AddAnotherApprenticeLink))
                throw new Exception("Link is still available to add another apprentice record");
            else
                return this;
        }

        public EditPersonalDetailsPage SelectEditApprenticeLink(int apprenticeNumber = 0)
        {
            var editApprenticeLinks = TotalNoOfEditableApprentices();
            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
            return new EditPersonalDetailsPage(context);
        }

        public string GetBannerHeading() => pageInteractionHelper.GetText(NotificationBannerHeading);

        public ApproveApprenticeDetailsPage ValidateEmployerCannotApproveCohort()
        {
            string bannerHeading = "You are no longer on the Register of Flexi-Job Apprenticeship Agencies";

            if (!pageInteractionHelper.IsElementDisplayed(NotificationBannerHeading))
                throw new Exception("Notification banner is not displayed");
            if(GetBannerHeading() != bannerHeading)
                throw new Exception($"Expected: {bannerHeading} but actual was: {GetBannerHeading()}");
            if (pageInteractionHelper.IsElementDisplayed(ApproveRadioButton))
                throw new Exception("The approve radio button is displayed to the user");

            return this;
        }

        public ApprenticeDetailsApprovedPage ValidateFlexiJobTagAndApprove()
        {
            validateFlexiJobAgencyTag();
            return EmployerDoesSecondApproval();
        }

        public void ValidateCohortStatus(string status) => pageInteractionHelper.VerifyText(CohortStatus, status);
    }
}