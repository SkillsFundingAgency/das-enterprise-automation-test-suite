using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BulkUploadProviderSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        protected readonly ProviderConfig _providerConfig;
        protected readonly ApprovalsConfig approvalsConfig;
        protected readonly PageInteractionHelper pageInteractionHelper;        
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        #endregion

        public BulkUploadProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
            approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());            
            _objectContext = _context.Get<ObjectContext>();
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

        [Then(@"Provider approves the cohorts and send them to employer to approve")]
        public void ThenProviderApprovesTheCohortsAndSendThemToEmployerToApprove()
        {
            var apprenticeList = GetBulkuploadData();

            new ProviderReviewApprenticeDetailsBulkUploadPage(_context)
                .SelectToApproveAllAndSendToEmployer()
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

        [Given(@"the provider has a cohort which is with employer")]
        public void GivenTheProviderHasACohortWhichIsWithEmployer()
        {            
            var employerUser = _context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AgreementIdSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);
            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWhichIsWithEmployer(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);
            
            _objectContext.SetCohortReference(cohortReference);                          
        }

        [When(@"the provider tries a bulk upload file to add apprentices in that cohort")]
        public void WhenTheProviderTriesABulkUploadFileToAddApprenticesInThatCohort()
        {           
            var cohortReference =  _objectContext.GetCohortReference();            
            _providerStepsHelper.AddApprenticeViaBulkUploadV2WithCohortReference(cohortReference);
        }

        [Then(@"Non Editable Cohorts error message is displayed")]
        public void ThenNonEditableCohortsErrorMessageIsDisplayed()
        {
            string errorMessage = "You cannot add apprentices to this cohort, as it is with the employer. You need to add this learner to a different or new cohort.This cohort is not empty. You need to add this learner to a different or new cohort.";
            new ProviderFileUploadValidationErrorsPage(_context)
                 .VerifyErrorMessage(errorMessage);
        }

        [Then(@"Transfer Sender Cohorts error message is displayed")]
        public void ThenTransferSenderCohortsErrorMessageIsDisplayed()
        {
            string errorMessage = "You cannot add apprentices via file on behalf of non-levy employers yet.\r\nYou cannot add apprentices to this cohort, as it is with the transfer sending employer. You need to add this learner to a different or new cohort.\r\nThis cohort is not empty. You need to add this learner to a different or new cohort.";
            new ProviderFileUploadValidationErrorsPage(_context)
                 .VerifyErrorMessage(errorMessage);
        }

        
        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            string errorMessage = "You cannot add apprentices to this cohort, as it is with the employer. You need to add this learner to a different or new cohort.\r\nYou cannot add apprentices to this cohort. You need to add this learner to a different or new cohort.\r\nThis cohort is not empty. You need to add this learner to a different or new cohort.";
            new ProviderFileUploadValidationErrorsPage(_context)
                            .VerifyErrorMessage(errorMessage);
        }

        [Given(@"the provider has a cohort as a result of change of party")]
        public void GivenTheProviderHasACohortAsAResultOfChangeOfParty()
        {
            var employerUser = _context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AgreementIdSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);
            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWithChangeOfParty(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);
                        
            _objectContext.SetCohortReference(cohortReference);
        }

        [Given(@"the provider has a cohort which is with transfer-sender")]
        public void GivenTheProviderHasACohortWhichIsWithTransfer_Sender()
        {   
            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWithTransferSender(Convert.ToInt32(_providerConfig.Ukprn));
           
            _objectContext.SetCohortReference(cohortReference);
        }

        [When(@"Provider add an apprentice uses details from below to create bulkupload")]
        public void WhenProviderAddAnApprenticeUsesDetailsFromBelowToCreateBulkupload(Table table)
        {
            var apprenticeRecords = table.CreateSet<MapApprenticeData>();

            _providerStepsHelper.ValidateApprenticeRecord(apprenticeRecords);
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