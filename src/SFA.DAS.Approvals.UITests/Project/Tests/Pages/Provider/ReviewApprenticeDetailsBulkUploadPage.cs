using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderReviewApprenticeDetailsBulkUploadPage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.Id("continue-button");

        protected By EmployerDetails => By.ClassName("bu-employer-details");
        protected By EmployerNameAndAgreementId => By.ClassName("bu-employer-name");
        protected By EmployerAgreementId => By.ClassName("bu-agreementId");

        protected By CohortReferences => By.ClassName("bu-cohort-ref");
        protected By ApprenticeCountAndTotalText => By.ClassName("bu-apprentice-count");

        protected By UploadAnAmendedFileRadioButton => By.Id("details-new-file");

        protected By UploadAnAmendedFileActionLink => By.Id("upload-amended-file-link");
        protected By SaveButDontSendToEmployerRadioButton => By.Id("details-save");

        protected By CancelUploadLink => By.Id("cancel-upload-link");

        protected override string PageTitle => "Check new apprentice records";

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
            return new ProviderNewApprenticeDetailsSavedSuccessfully(context);
        }

        public ProviderUploadAmendedFilePage SelectToUploadAnAmendedFileThroughLink()
        {
            formCompletionHelper.Click(UploadAnAmendedFileActionLink);
            return new ProviderUploadAmendedFilePage(context);
        }

        public void CancelUpload()
        {
            formCompletionHelper.Click(CancelUploadLink);
        }

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
                    throw new System.Exception($"Apprenticeship count and total match not found : {expectedCohortDetails.NumberOfApprenticeshipsText}");
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
                var expectedCohortDetails = cohortDetails[counter];
                if (cR.Text != $"Cohort: {expectedCohortDetails.CohortRefText}")
                {
                    throw new System.Exception($"CohortRef match not found : {expectedCohortDetails.CohortRefText}");
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
                throw new System.Exception($"AgreementId match not found : {expectedEmployerDetails.AgreementId}");
            }
        }

        private void VerifyEmployerName(FileUploadReviewEmployerDetails expectedEmployerDetails, IWebElement employerNameAndAgreementId)
        {
            if (!employerNameAndAgreementId.Text.Contains(expectedEmployerDetails.EmployerName))
            {
                throw new System.Exception($"Employer name match not found : {expectedEmployerDetails.EmployerName}");
            }
        }

        /*
        private List<FileUploadReviewEmployerDetails> GetBulkuploadData()
        {
            var apprenticeList = objectContext.Get<List<ApprenticeDetails>>("BulkuploadApprentices");
            var groupedByEmployers = apprenticeList.GroupBy(x => x.AgreementId);
            var result = new List<FileUploadReviewEmployerDetails>();
            foreach (var employer in groupedByEmployers)
            {
                var employerDetail = new FileUploadReviewEmployerDetails();
                employerDetail.EmployerName = context.Get<AgreementIdSqlHelper>().GetEmployerNameByAgreementId(employer.Key);
                employerDetail.AgreementId = employer.Key;

                employerDetail.CohortDetails = new List<FileUploadReviewCohortDetail>();

                var cohortGroups = employer.GroupBy(x => x.CohortRef);
                foreach (var cohortGroup in cohortGroups)
                {
                    var cohortDetail = new FileUploadReviewCohortDetail();
                    cohortDetail.CohortRef = cohortGroup.Key;
                    cohortDetail.NumberOfApprentices = cohortGroup.Count();
                    cohortDetail.TotalCost = cohortGroup.Sum(x => int.Parse(x.TotalPrice));
                    employerDetail.CohortDetails.Add(cohortDetail);
                }

                result.Add(employerDetail);
            }

            return result;
        }
        /*
     
    }

    /*

    #region Helper Classes

    public class FileUploadReviewEmployerDetails
    {
        public string EmployerName { get; set; }
        public string AgreementId { get; set; }
        public string CohortRef { get; set; }
        public List<FileUploadReviewCohortDetail> CohortDetails { get; set; }
    }

    public class FileUploadReviewCohortDetail
    {
        public const string EmptyCohortRefText = "This will be created when you save or send to employers";
        public string CohortRef { get; set; }
        public int NumberOfApprentices { get; set; }
        public int TotalCost { get; set; }

        public string CohortRefText => CohortRef ?? EmptyCohortRefText;

        public string NumberOfApprenticeshipsText
        {
            get
            {
                var text = NumberOfApprentices + " " + "apprentice";
                if (NumberOfApprentices > 1)
                {
                    text += "s";
                }

                return text;
            }
        }

        public string NumberOfApprenticeshipAndTotalCost =>
             $"{NumberOfApprenticeshipsText}, total cost: £{TotalCost:n0}";

    }

    #endregion

    */
    
    }
}
