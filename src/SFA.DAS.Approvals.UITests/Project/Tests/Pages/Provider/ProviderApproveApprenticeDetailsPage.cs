using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApproveApprenticeDetailsPage : ReviewYourCohort
    {
        protected override By PageHeader => By.ClassName("govuk-heading-xl");

        private static By AddAnApprenticeButton => By.CssSelector(".govuk-link.add-apprentice");
        private static By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");
        private static new By EditApprenticeLink => By.ClassName("edit-apprentice");
        protected override By ContinueButton => By.Id("continue-button");
        protected override By TotalApprentices => By.CssSelector(".providerList tbody tr");
        private static By DeleteThisCohortLink => By.PartialLinkText("Delete this cohort");
        private static By BulkUploadLink => By.PartialLinkText("Upload apprentice(s) using a CSV file");
        private static By MessageBox => By.Name("sendmessage");
        private static By SaveAndExitCohort => By.Id("save-and-exit-cohort");
        private static By FlashMessage => By.ClassName("govuk-panel__title");
        private static By NotificationBanner => By.CssSelector(".govuk-notification-banner");

        private static By InsertText => By.CssSelector(".govuk-inset-text");

        private static By ApproveRadioButton => By.Id("radio-approve");

        protected override string AccessibilityPageTitle => "Provider approve apprentice details";

        public ProviderApproveApprenticeDetailsPage(ScenarioContext context) : base(context, (x) => x < 2 ? "Approve apprentice details" : $"Approve {x} apprentices' details") { }

        internal ProviderChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            AddAnApprentice();
            return new ProviderChooseAReservationPage(context);
        }

        internal SelectStandardPage SelectAddAnApprentice()
        {
            AddAnApprentice();

            return new SelectStandardPage(context);
        }

        internal SimplifiedPaymentsPilotPage SelectAddAnApprenticeForFlexiPaymentsProvider()
        {
            AddAnApprentice();

            return new SimplifiedPaymentsPilotPage(context);
        }

        public List<IWebElement> ApprenticeUlns() => pageInteractionHelper.FindElements(ApprenticeUlnField);

        public ProviderEditApprenticeDetailsPage SelectEditApprentice() => SelectEditApprentice(0, false);

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber) => SelectEditApprentice(apprenticeNumber, false);

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber, bool isFlexiPaymentPilotLearner)
        {
            IList<IWebElement> editApprenticeLinks = pageInteractionHelper.FindElements(EditApprenticeLink);

            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);

            return new ProviderEditApprenticeDetailsPage(context, isFlexiPaymentPilotLearner);
        }

        public ProviderConfirmCohortDeletionPage SelectDeleteCohort()
        {
            formCompletionHelper.ClickElement(DeleteThisCohortLink);
            return new ProviderConfirmCohortDeletionPage(context);
        }

        public ProviderBulkUploadApprenticesPage SelectBulkUploadApprentices()
        {
            formCompletionHelper.ClickElement(BulkUploadLink);
            return new ProviderBulkUploadApprenticesPage(context);
        }

        public ProviderApproveApprenticeDetailsPage IsAddApprenticeLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(AddAnApprenticeButton))
                throw new Exception("Link is still available to add an apprentice record");
            else
                return this;
        }

        public ProviderApproveApprenticeDetailsPage IsBulkUpLoadLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(BulkUploadLink))
                throw new Exception("Link is still available to upload bulk apprentices record");
            else
                return this;
        }

        public bool IsEditApprenticeLinkDisplayed()
        {
            if (pageInteractionHelper.IsElementDisplayed(EditApprenticeLink))
                return true;
            else
                return false;
        }

        public ProviderAccessDeniedPage SelectEditApprenticeGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(EditApprenticeLink);
            return new ProviderAccessDeniedPage(context);
        }

        internal ProviderAccessDeniedPage SelectAddAnApprenticeGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeButton);
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderAccessDeniedPage SelectDeleteCohortGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(DeleteThisCohortLink);
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderAccessDeniedPage SelectBulkUploadApprenticesGoesToAccessDenied()
        {
            formCompletionHelper.ClickElement(BulkUploadLink);
            return new ProviderAccessDeniedPage(context);
        }

        public ProviderCohortSentForReviewPage SubmitSendToEmployerToReview()
        {
            SelectOption("radio-send");
            return new ProviderCohortSentForReviewPage(context);
        }

        public ProviderCohortApprovedPage SubmitApprove()
        {
            SelectOption("radio-approve", false);
            return new ProviderCohortApprovedPage(context);
        }

        public ProviderCohortApprovedPage ValidateFlexiJobTagAndSubmitApprove()
        {
            ValidateFlexiJobAgencyTag();
            return SubmitApprove();
        }

        public ProviderCohortApprovedPage ValidatePortableFlexiJobTagAndSubmitApprove()
        {
            ValidatePortableFlexiJobTag();
            return SubmitApprove();
        }

        public ProviderCohortSentForReviewPage SubmitApproveAndSendToEmployerForApproval()
        {
            SelectOption("send-details");
            return new ProviderCohortSentForReviewPage(context);
        }

        public ProviderApprenticeRequestsPage SubmitSaveButDontSendToEmployer()
        {
            formCompletionHelper.ClickElement(SaveAndExitCohort);
            return new ProviderApprenticeRequestsPage(context);
        }

        public string GetFlashMessage() => pageInteractionHelper.GetTextFromElementsGroup(FlashMessage);

        public int? GetNumberOfEditableApprentices() => pageInteractionHelper.FindElements(EditApprenticeLink).Count;

        private void SelectOption(string option, bool sendMessageToEmployer = true)
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, option);

            if (sendMessageToEmployer) formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToEmployer);
                
            Continue();
        }

        private void AddAnApprentice() => formCompletionHelper.ClickElement(AddAnApprenticeButton);

        public void VerifyLimitingStandardRestriction()
        {
            VerifyPage(NotificationBanner, "One or more training courses is not on your declared list");

            VerifyPage(() => pageInteractionHelper.FindElements(InsertText), "This training course has not been declared. You can change it or add it ");

            VerifyProviderCanNotApprove();
        }

        public void ValidateProviderCannotApproveCohort()
        {
            VerifyPage(NotificationBanner, "is no longer on the Register of Flexi-Job Apprenticeship Agencies");

            VerifyProviderCanNotApprove();
        }

        public ProviderApproveApprenticeDetailsPage VerifySimplifiedPaymentsPilotTagAndColumns(bool isDisplayed)
        {
            ValidateSimplifiedPaymentsPilotTagAndColumns(isDisplayed);
            return this;
        }
        public void VerifyRadioOptionToApproveCohortIsNotDisplayed() => Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(ApproveRadioButton), "Unexpected behavior - Option to approve the Cohort is displayed");

        private void VerifyProviderCanNotApprove()
        {
            if (pageInteractionHelper.IsElementDisplayed(ApproveRadioButton)) throw new Exception("The approve radio button is displayed to the user");
        }
    }
}