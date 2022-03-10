using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BulkUploadProviderSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        protected readonly ProviderConfig _providerConfig;
        #endregion

        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;

        public BulkUploadProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
        }

        [When(@"Provider add (.*) apprentice details using bulkupload and sends to employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingV2BulkUploadAndSendsToEmployerForApproval(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices);
        }

        [When(@"Provider add (.*) apprentice details using bulkupload")]
        public void WhenProviderAddApprenticeDetailsUsingV2BulkUpload(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices);
        }

        [When(@"Provider uses BulkUpload to add (.*) apprentice details into existing cohort and (.*) apprentice details into a non-existing cohort")]
        public void WhenProviderUsesBulkUploadToAddApprenticeDetailsIntoExistingCohortAndApprenticeDetailsIntoANon_ExistingCohort(int numberOfApprentices, int numberOfApprenticesWithoutCohortRef)
        {
            _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices, numberOfApprenticesWithoutCohortRef);
        }

        [Given(@"Correct Information is displayed on review apprentices details page")]
        [When(@"Correct Information is displayed on review apprentices details page")]
        [Then(@"Correct Information is displayed on review apprentices details page")]
        public void CorrectInformationIsDisplayedInReviewApprenticeDetailsPage()
        {
            var apprenticeList = GetBulkuploadData();

            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                .VerifyCorrectInformationIsDisplayed(apprenticeList);
        }

        [Given(@"User selects to upload an amended file")]
        [When(@"User selects to upload an amended file")]
        public void UserSelectsToUploadAnAmendedFile()
        {
            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                .SelectToUploadAnAmendedFile();
        }

        [Given(@"Provider uploads another file")]
        [When(@"Provider uploads another file")]
        public void ProviderUploadsAnotherFile()
        {
            new ProviderBulkUploadCsvFilePage(_context)
                .CreateACsvFile()
                .UploadFile(); ;
        }

        [Given(@"Provider selects to save all but don't send to employer")]
        [When(@"Provider selects to save all but don't send to employer")]
        public void ProviderSelectsToSaveAllButDontSendToEmployer()
        {
            var apprenticeList = GetBulkuploadData();

            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                     .SelectsToSaveAllButDontSendToEmployer()
                     .VerifyCorrectInformationIsDisplayed(apprenticeList);



        }

        [Given(@"User selects to upload an amended file through link")]
        [When(@"User selects to upload an amended file through link")]
        public void UserSelectsToUploadAnAmendedFileThroughLink()
        {
            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                .SelectToUploadAnAmendedFileThroughLink();
        }

        [Given(@"Provider selects No on confirmation for upload an amended file")]
        [When(@"Provider selects No on confirmation for upload an amended file")]
        public void ProviderSelectsNoOnConfirmationForUploadAmendedFile()
        {
            new ProviderUploadAmendedFilePage(_context)
                .SelectNoAndContinue();
        }

        [Given(@"Provider selects Yes on confirmation for upload an amended file")]
        [When(@"Provider selects Yes on confirmation for upload an amended file")]
        public void ProviderSelectsYesOnConfirmationForUploadAmendedFile()
        {
            new ProviderUploadAmendedFilePage(_context)
                .SelectYesAndContinue();
        }

        [Given(@"Provider selects to Cancel bulk upload")]
        [When(@"Provider selects to Cancel bulk upload")]
        public void ProviderSelectsToCancelBulkUpload()
        {
            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                 .CancelUpload();
        }

        [Given(@"Provider says No on Confirm cancel confirmation page")]
        [When(@"Provider says No on Confirm cancel confirmation page")]
        public void ProviderSelectsNoOnConfirmCancelConfirmationPage()
        {
            new ProviderFileDiscadPage(_context)
                 .SelectNoAndContinue();
        }

        [Given(@"Provider says Yes on Confirm cancel confirmation page")]
        [When(@"Provider says Yes on Confirm cancel confirmation page")]
        public void ProviderSelectsYesOnConfirmCancelConfirmationPage()
        {
            new ProviderFileDiscadPage(_context)
                 .SelectYesAndContinue();
        }

        [Given(@"Upload cancelled confirmation page is displayed")]
        [When(@"Upload cancelled confirmation page is displayed")]
        public void UploadCancelled()
        {
            new ProviderFileDiscadSuccessPage(_context);
        }

        public List<FileUploadReviewEmployerDetails> GetBulkuploadData()
        {
            var _objectContext = _context.Get<ObjectContext>();
            var apprenticeList = _objectContext.Get<List<ApprenticeDetails>>("BulkuploadApprentices");
            var groupedByEmployers = apprenticeList.GroupBy(x => x.AgreementId);
            var result = new List<FileUploadReviewEmployerDetails>();
            foreach (var employer in groupedByEmployers)
            {
                var employerDetail = new FileUploadReviewEmployerDetails();
                employerDetail.EmployerName = _context.Get<AgreementIdSqlHelper>().GetEmployerNameByAgreementId(employer.Key);
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


    }

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
}