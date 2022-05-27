using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        protected readonly ProviderConfig _providerConfig;
        protected readonly ApprovalsConfig approvalsConfig;
        protected readonly PageInteractionHelper pageInteractionHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        #endregion

        public BulkUploadProviderSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
            approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        [When(@"Provider add (.*) apprentice details using bulkupload and sends to employer for approval")]
        public void ProviderAddApprenticeDetailsUsingBulkUploadAndSend(int numberOfApprentices) => _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices);

        [When(@"Provider add (.*) apprentice details using bulkupload")]
        public void ProviderAddApprenticeDetailsUsingV2BulkUpload(int numberOfApprentices) => _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices);

        [When(@"Provider uses BulkUpload to add (.*) apprentice details into existing cohort and (.*) apprentice details into a non-existing cohort")]
        public void ProviderUsesBulkUpload(int numberOfApprentices, int numberOfApprenticesWithoutCohortRef) => _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices, numberOfApprenticesWithoutCohortRef);

        [Given(@"Correct Information is displayed on review apprentices details page")]
        [When(@"Correct Information is displayed on review apprentices details page")]
        [Then(@"Correct Information is displayed on review apprentices details page")]
        public void CorrectInformationIsDisplayedInReviewApprenticeDetailsPage() => new ProviderReviewApprenticeDetailsBulkUploadPage(_context).VerifyCorrectInformationIsDisplayed(GetBulkuploadData());

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
        public void UserSelectsToUploadAnAmendedFile() => new ProviderReviewApprenticeDetailsBulkUploadPage(_context).SelectToUploadAnAmendedFile();

        [Given(@"Provider uploads another file")]
        [When(@"Provider uploads another file")]
        public void ProviderUploadsAnotherFile() => new ProviderBulkUploadCsvFilePage(_context).CreateACsvFile(1, 0).UploadFile();

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
        public void UserSelectsToUploadAnAmendedFileThroughLink() => new ProviderReviewApprenticeDetailsBulkUploadPage(_context).SelectToUploadAnAmendedFileThroughLink();

        [Given(@"Provider selects No on confirmation for upload an amended file")]
        [When(@"Provider selects No on confirmation for upload an amended file")]
        public void ProviderSelectsNoOnConfirmationForUploadAmendedFile() => new ProviderUploadAmendedFilePage(_context).SelectNoAndContinue();

        [Given(@"Provider selects Yes on confirmation for upload an amended file")]
        [When(@"Provider selects Yes on confirmation for upload an amended file")]
        public void ProviderSelectsYesOnConfirmationForUploadAmendedFile() => new ProviderUploadAmendedFilePage(_context).SelectYesAndContinue();

        [Given(@"Provider selects to Cancel bulk upload")]
        [When(@"Provider selects to Cancel bulk upload")]
        public void ProviderSelectsToCancelBulkUpload() => new ProviderReviewApprenticeDetailsBulkUploadPage(_context).CancelUpload();

        [Given(@"Provider says No on Confirm cancel confirmation page")]
        [When(@"Provider says No on Confirm cancel confirmation page")]
        public void ProviderSelectsNoOnConfirmCancelConfirmationPage() => new ProviderFileDiscadPage(_context).SelectNoAndContinue();

        [Given(@"Provider says Yes on Confirm cancel confirmation page")]
        [When(@"Provider says Yes on Confirm cancel confirmation page")]
        public void ProviderSelectsYesOnConfirmCancelConfirmationPage() => new ProviderFileDiscadPage(_context).SelectYesAndContinue();

        [Given(@"Upload cancelled confirmation page is displayed")]
        [When(@"Upload cancelled confirmation page is displayed")]
        public void UploadCancelled() => new ProviderFileDiscadSuccessPage(_context);

        [Then(@"New apprentice records become available in Manage Apprentice section")]
        public void ThenNewApprenticeRecordsBecomeAvailableInManageApprenticeSection()
        {
            var apprenticeList = _objectContext.GetBulkuploadApprentices();
            string expectedStatus1 = "LIVE";
            string expectedStatus2 = "WAITING TO START";

            ProviderManageYourApprenticesPage providerManageYourApprenticesPage = _providerStepsHelper.GoToProviderHomePage(true).GoToProviderManageYourApprenticePage();

            foreach (var apprentice in apprenticeList)
            {
                var actualStatus = providerManageYourApprenticesPage.SearchForApprenntice(apprentice.ULN).GetStatus(apprentice.ULN);
                Assert.IsTrue((actualStatus.ToUpper() == expectedStatus1.ToUpper() || actualStatus.ToUpper() == expectedStatus2.ToUpper()), "Validate status on Manage Your Apprentices page");
            }

        }
        [Given(@"the provider has a cohort which is with employer")]
        public void GivenTheProviderHasACohortWhichIsWithEmployer()
        {
            var employerUser = _context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AccountsDbSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);
            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWhichIsWithEmployer(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);

            _objectContext.SetCohortReference(cohortReference);
        }

        [Given(@"the provider has a cohort as a result of change of party")]
        public void GivenTheProviderHasACohortAsAResultOfChangeOfParty()
        {
            var employerUser = _context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AccountsDbSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);

            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWithChangeOfParty(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);

            _objectContext.UpdateCohortReference(cohortReference);
        }

        [Given(@"the provider has a cohort which is with transfer-sender")]
        public void GivenTheProviderHasACohortWhichIsWithTransfer_Sender()
        {
            var cohortReference = _commitmentsSqlDataHelper.GetProviderCohortWithTransferSender(Convert.ToInt32(_providerConfig.Ukprn));

            _objectContext.UpdateCohortReference(cohortReference);
        }

        [When(@"the provider tries a bulk upload file to add apprentices in that cohort")]
        public void WhenTheProviderTriesABulkUploadFileToAddApprenticesInThatCohort() => _providerStepsHelper.AddApprenticeViaBulkUploadV2WithCohortReference(_objectContext.GetCohortReference());

        public List<FileUploadReviewEmployerDetails> GetBulkuploadData()
        {            
            var apprenticeList = _objectContext.GetBulkuploadApprentices();
            var groupedByEmployers = apprenticeList.GroupBy(x => x.AgreementId);
            var result = new List<FileUploadReviewEmployerDetails>();

            foreach (var employer in groupedByEmployers)
            {
                var employerDetail = new FileUploadReviewEmployerDetails();
                employerDetail.EmployerName = _context.Get<AccountsDbSqlHelper>().GetEmployerNameByAgreementId(employer.Key);
                employerDetail.AgreementId = employer.Key;

                employerDetail.CohortDetails = new List<FileUploadReviewCohortDetail>();

                var cohortGroups = employer.GroupBy(x => x.CohortRef);

                var cohortDetails = new List<FileUploadReviewCohortDetail>();

                foreach (var cohortGroup in cohortGroups)
                {
                    var cohortDetail = new FileUploadReviewCohortDetail();
                    cohortDetail.CohortRef = cohortGroup.Key;
                    cohortDetail.NumberOfApprentices = cohortGroup.Count();
                    cohortDetail.TotalCost = cohortGroup.Sum(x => int.Parse(x.TotalPrice));
                    cohortDetails.Add(cohortDetail);

                    if (!string.IsNullOrWhiteSpace(cohortGroup.Key))
                    {
                        var existingApprentices = _commitmentsSqlDataHelper.GetExistingApprentices(cohortGroup.Key);

                        var totalCost = GetTotalCostForExistingApprentices(existingApprentices);

                        var existingCohortDetails = new FileUploadReviewCohortDetail
                        {
                            CohortRef = cohortGroup.Key,
                            NumberOfApprentices = existingApprentices.Count(),
                            TotalCost = totalCost
                        };
                        cohortDetails.Add(existingCohortDetails);
                    }
                }

                employerDetail.CohortDetails.AddRange(cohortDetails.GroupBy(x => x.CohortRef).Select(
                      m =>
                      new FileUploadReviewCohortDetail
                      {
                          CohortRef = m.Key,
                          NumberOfApprentices = m.Sum(x => x.NumberOfApprentices),
                          TotalCost = m.Sum(x => x.TotalCost)
                      }).ToList());

                result.Add(employerDetail);

            }

            return result;
        }

        private static int GetTotalCostForExistingApprentices(List<decimal> getExistingApprentices)
        {
            decimal cost = 0;
            foreach (var item in getExistingApprentices)
            {
                cost += item;
            }
            return (int)cost;
        }
    }
}