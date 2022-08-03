using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewApprenticeDetailsBulkUploadPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Check new apprentice records";
        protected override By ContinueButton => By.Id("continue-button");

        protected By EmployerDetails => By.ClassName("bu-employer-details");
        protected By EmployerNameAndAgreementId => By.ClassName("bu-employer-name");
        protected By EmployerAgreementId => By.ClassName("bu-agreementId");
        protected By CohortReferences => By.ClassName("bu-cohort-ref");
        protected By ApprenticeCountAndTotalText => By.ClassName("bu-apprentice-count");
        protected By UploadAnAmendedFileRadioButton => By.Id("details-new-file");
        protected By UploadAnAmendedFileActionLink => By.Id("upload-amended-file-link");
        protected By SaveButDontSendToEmployerRadioButton => By.Id("details-save");
        protected By ApproveAllAndSendToEmployerButton => By.Id("details-approve");
        protected By CancelUploadLink => By.Id("cancel-upload-link");


        public ProviderReviewApprenticeDetailsBulkUploadPage(ScenarioContext context) : base(context) { }

        public ProviderReviewApprenticeDetailsBulkUploadPage VerifyCorrectInformationIsDisplayed(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            VerifyEmployerDetails(apprenticeList);
            return this;
        }

        public ProviderUploadAmendedFilePage SelectToUploadAnAmendedFile()
        {
            formCompletionHelper.SelectRadioOptionByLocator(UploadAnAmendedFileRadioButton);
            Continue();
            return new ProviderUploadAmendedFilePage(context);
        }

        public ProviderNewApprenticeDetailsSavedSuccessfully SelectsToSaveAllButDontSendToEmployer()
        {
            formCompletionHelper.SelectRadioOptionByLocator(SaveButDontSendToEmployerRadioButton);
            Continue();
            return new ProviderNewApprenticeDetailsSavedSuccessfully(context, new VerifyBulkUploadApprentices(context));
        }

        public ProviderNewApprenticesAddedAndSentToEmployer SelectToApproveAllAndSendToEmployer()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ApproveAllAndSendToEmployerButton);
            Continue();
            return new ProviderNewApprenticesAddedAndSentToEmployer(context, new VerifyBulkUploadApprentices(context));
        }
        
        public ProviderUploadAmendedFilePage SelectToUploadAnAmendedFileThroughLink()
        {
            formCompletionHelper.Click(UploadAnAmendedFileActionLink);
            return new ProviderUploadAmendedFilePage(context);
        }

        public void CancelUpload() => formCompletionHelper.Click(CancelUploadLink);

        private void VerifyCohortDetails(List<FileUploadReviewCohortDetail> cohortDetails, IWebElement employerDetails)
        {
            VerifyCohortReferences(cohortDetails, employerDetails);

            VerifyApprenticeCountAndTotalAmount(cohortDetails, employerDetails);
        }

        private void VerifyApprenticeCountAndTotalAmount(List<FileUploadReviewCohortDetail> cohortDetails, IWebElement employerDetails)
        {
            int counter = 0;
            var apprenticeCountAndTotalTextWE = employerDetails.FindElements(ApprenticeCountAndTotalText);
            foreach (var apC in apprenticeCountAndTotalTextWE)
            {
                var expectedCohortDetails = cohortDetails[counter];
                if (apC.Text != expectedCohortDetails.NumberOfApprenticeshipAndTotalCost)
                {
                    throw new Exception($"Apprenticeship count and total match not found : {expectedCohortDetails.NumberOfApprenticeshipsText}");
                }
                counter++;
            }
        }

        private void VerifyCohortReferences(List<FileUploadReviewCohortDetail> cohortDetails, IWebElement employerDetails)
        {
            int counter = 0;
            var cohortReferencesWE = employerDetails.FindElements(CohortReferences);
            foreach (var cR in cohortReferencesWE)
            {
                //var expectedCohortDetails = cohortDetails[counter];
                string expectedCohortDetails = cohortDetails[counter].CohortRef == "" ? "This will be created when you save or send to employers" : cohortDetails[counter].CohortRef;
                if (cR.Text != $"Cohort: {expectedCohortDetails}")
                {
                    throw new Exception($"CohortRef match not found : {expectedCohortDetails}");
                }
                counter++;
            }
        }

        private void VerifyEmployerDetails(List<FileUploadReviewEmployerDetails> apprenticeList)
        {
            int counter = 0;
            var employerDetailsWebElement = pageInteractionHelper.FindElements(EmployerDetails);
            foreach (var eD in employerDetailsWebElement)
            {
                var expectedEmployerDetails = apprenticeList[counter];
                var employerNameAndAgreementId = eD.FindElement(EmployerNameAndAgreementId);

                VerifyEmployerName(expectedEmployerDetails, employerNameAndAgreementId);
                VerifyAgreementId(expectedEmployerDetails, employerNameAndAgreementId);
                VerifyCohortDetails(expectedEmployerDetails.CohortDetails, eD);

                counter++;
            }
        }

        private void VerifyAgreementId(FileUploadReviewEmployerDetails expectedEmployerDetails, IWebElement employerNameAndAgreementId)
        {
            var agrreementId = employerNameAndAgreementId.FindElement(EmployerAgreementId);
            if (agrreementId.Text != $"Agreement ID: {expectedEmployerDetails.AgreementId}")
            {
                throw new Exception($"AgreementId match not found : {expectedEmployerDetails.AgreementId}");
            }
        }

        private void VerifyEmployerName(FileUploadReviewEmployerDetails expectedEmployerDetails, IWebElement employerNameAndAgreementId)
        {
            if (!employerNameAndAgreementId.Text.Contains(expectedEmployerDetails.EmployerName.Replace("  ", " ")))
            {
                throw new Exception($"Employer name match not found : {expectedEmployerDetails.EmployerName}");
            }
        }

    }
}
