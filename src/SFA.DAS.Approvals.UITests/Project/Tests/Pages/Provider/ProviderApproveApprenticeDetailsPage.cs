using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderApproveApprenticeDetailsPage : ReviewYourCohort
    {
        protected override By PageHeader => By.ClassName("govuk-heading-xl");
        protected override string PageTitle => _pageTitle;

        #region Helpers and Context
        private readonly string _pageTitle;
        #endregion

        private By PireanPreprodButton => By.XPath("//span[contains(text(),'Pirean Preprod')]");
        private By AddAnApprenticeButton => By.CssSelector(".govuk-link.add-apprentice");
        private By ApprenticeUlnField => By.CssSelector("tbody tr td:nth-of-type(2)");
        private new By EditApprenticeLink => By.ClassName("edit-apprentice");
        protected override By ContinueButton => By.Id("continue-button");
        protected override By TotalApprentices => By.CssSelector(".providerList tbody tr");
        private By DeleteThisCohortLink => By.PartialLinkText("Delete this cohort");
        private By BulkUploadLink => By.PartialLinkText("Upload apprentice(s) using a CSV file");
        private By MessageBox => By.Name("sendmessage");
        private By CohortApproveOptions => By.CssSelector(".govuk-radios__label");
        private By SaveAndExitCohort => By.Id("save-and-exit-cohort");
        private By FlashMessage => By.ClassName("govuk-panel__title");

        public ProviderApproveApprenticeDetailsPage(ScenarioContext context) : base(context, false)
        {
            var noOfApprentice = TotalNoOfApprentices();
            _pageTitle = noOfApprentice < 2 ? "Approve apprentice details" : $"Approve {noOfApprentice} apprentices' details";
            VerifyPage();
        }

        internal ProviderChooseAReservationPage SelectAddAnApprenticeUsingReservation()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeButton);
            return new ProviderChooseAReservationPage(context);
        }

        internal ProviderAddApprenticeDetailsPage SelectAddAnApprentice()
        {
            formCompletionHelper.ClickElement(AddAnApprenticeButton);
            if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
            {
                formCompletionHelper.ClickElement(PireanPreprodButton);
            }
            return new ProviderAddApprenticeDetailsPage(context);
        }

        public List<IWebElement> ApprenticeUlns()
        {
            return base.pageInteractionHelper.FindElements(ApprenticeUlnField);
        }

        public ProviderEditApprenticeDetailsPage SelectEditApprentice(int apprenticeNumber = 0)
        {
            IList<IWebElement> editApprenticeLinks = base.pageInteractionHelper.FindElements(EditApprenticeLink);
            formCompletionHelper.ClickElement(editApprenticeLinks[apprenticeNumber]);
            if (pageInteractionHelper.IsElementDisplayed(PireanPreprodButton))
            {
                formCompletionHelper.ClickElement(PireanPreprodButton);
            }
            return new ProviderEditApprenticeDetailsPage(context);
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
            formCompletionHelper.SelectRadioOptionByForAttribute(CohortApproveOptions, option);
            if (sendMessageToEmployer)
                formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToEmployer);            
            Continue();
        }

        
       

    }
}