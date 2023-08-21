using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BulkUploadProviderErrorMsgSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderBulkUploadStepsHelper _providerBulkUploadStepsHelper;

        private readonly BulkCsvUploadValidateErrorMsghelper bulkCsvUploadValidateErrorMsghelper;
        #endregion

        public BulkUploadProviderErrorMsgSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _providerBulkUploadStepsHelper = new ProviderBulkUploadStepsHelper(context);
            bulkCsvUploadValidateErrorMsghelper = new BulkCsvUploadValidateErrorMsghelper(context);
        }

        [Then(@"Non Editable Cohorts error message is displayed")]
        public void ThenNonEditableCohortsErrorMessageIsDisplayed()
        {
            bulkCsvUploadValidateErrorMsghelper.VerifyErrorMessage("You cannot add apprentices to this cohort, as it is with the employer. You need to add this learner to a different or new cohort.This cohort is not empty. You need to add this learner to a different or new cohort.");
        }

        [Then(@"Transfer Sender Cohorts error message is displayed")]
        public void ThenTransferSenderCohortsErrorMessageIsDisplayed()
        {
            bulkCsvUploadValidateErrorMsghelper.VerifyErrorMessage("You cannot add apprentices to this cohort, as it is with the transfer sending employer. You need to add this learner to a different or new cohort.\r\nThis cohort is not empty. You need to add this learner to a different or new cohort.");
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            bulkCsvUploadValidateErrorMsghelper.VerifyErrorMessage("You cannot add apprentices to this cohort. You need to add this learner to a different or new cohort.This cohort is not empty. You need to add this learner to a different or new cohort.");
        }

        [When(@"Provider add an apprentice uses details from below to create bulkupload")]
        public void WhenProviderAddAnApprenticeUsesDetailsFromBelowToCreateBulkupload(Table table) => ValidateApprenticeRecord(table);

        public void ValidateApprenticeRecord(Table table)
        {
            var apprenticeRecords = table.CreateSet<MapApprenticeDetails>();

            var apprenticeCourseDataHelper = _context.Get<ApprenticeCourseDataHelper>();

            var cohortRef = _objectContext.GetCohortReference();

            var courseCode = 17;

            var datahelper = _context.Get<ApprenticeDataHelper>();

            string agreementId = _context.Get<AccountsDbSqlHelper>().GetAgreementIdByCohortRef(cohortRef).Trim();

            int i = 0;

            foreach (var item in apprenticeRecords)
            {
                i++;
                var ApprenticeList = new List<BulkUploadApprenticeDetails>();

                var result = new BulkUploadApprenticeDetails(courseCode, agreementId, datahelper.ApprenticeDob, apprenticeCourseDataHelper.CourseStartDate, apprenticeCourseDataHelper.CourseEndDate)
                {
                    CohortRef = cohortRef,
                    ULN = RandomDataGenerator.GenerateRandomUln(),
                    FamilyName = datahelper.ApprenticeLastname,
                    GivenNames = datahelper.ApprenticeFirstname,
                    TotalPrice = datahelper.TrainingCost,
                    ProviderRef = datahelper.EmployerReference,
                    EmailAddress = datahelper.ApprenticeEmail
                };

                static bool IsNotValid(string x) => x != "valid";

                if (IsNotValid(item.CohortRef)) result.CohortRef = item.CohortRef;
                if (IsNotValid(item.AgreementId)) result.AgreementId = item.AgreementId;
                if (IsNotValid(item.ULN)) result.ULN = item.ULN;
                if (IsNotValid(item.FamilyName)) result.FamilyName = item.FamilyName;
                if (IsNotValid(item.GivenNames)) result.GivenNames = item.GivenNames;
                if (IsNotValid(item.DateOfBirth)) result.DateOfBirth = item.DateOfBirth;
                if (IsNotValid(item.EmailAddress)) result.EmailAddress = item.EmailAddress;
                if (IsNotValid(item.StdCode)) result.StdCode = item.StdCode;
                if (IsNotValid(item.StartDate)) result.StartDate = item.StartDate;
                if (IsNotValid(item.EndDate)) result.EndDate = item.EndDate;
                if (IsNotValid(item.TotalPrice)) result.TotalPrice = item.TotalPrice;
                if (IsNotValid(item.ProviderRef)) result.ProviderRef = item.ProviderRef;

                ApprenticeList.Add(result);

                //upload
                if (i == 1) // first time start from provider home page 
                    _providerBulkUploadStepsHelper.UsingFileUpload().CreateACsvFile(ApprenticeList).UploadFile();
                else // next time onwards upload directly from the error page              
                    new ProviderFileUploadValidationErrorsPage(_context).CreateACsvFile(ApprenticeList).UploadFile();

                new BulkCsvUploadValidateErrorMsghelper(_context).VerifyErrorMessage(item.ErrorMessage, item.Category);
            }
        }
    }
}