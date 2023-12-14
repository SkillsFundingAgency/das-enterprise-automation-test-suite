using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderBulkUploadCsvFilePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private static By ChooseFileButton => By.Id("attachment");
        private static By UploadFileButton => By.Id("submit-upload-apprentices");

        protected readonly string CsvFileLocation = Path.GetFullPath(@"..\..\..\") + $"{context.ScenarioInfo.Title[..8]}_BulkUpload.csv";

        private readonly List<BulkUploadApprenticeDetails> _apprenticeList = [];

        protected override string PageTitle => "Upload a CSV file";

        private readonly CreateCsvFileHelper _bulkUploadDataHelper = new();

        public ProviderBulkUploadCsvFilePage CreateApprenticeshipsForAlreadyCreatedCohorts(int numberOfApprenticesPerCohort)
        {
            var listOfCohortReference = GetCohortReferences();

            foreach (var cohortRef in listOfCohortReference)
            {
                for (var i = 1; i <= numberOfApprenticesPerCohort; i++)
                {
                    _apprenticeList.Add(SetApprenticeDetailsForLegalEntity(i * 17, cohortRef, string.Empty, string.Empty));
                }
            }

            return this;
        }


        public ProviderBulkUploadCsvFilePage CreateApprenticeshipsForEmptyCohorts(int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            for (int i = 0; i < numberOfApprenticesWithoutCohortRef; i++)
            {
                _apprenticeList.Add(SetApprenticeDetailsForLegalEntity(i + 1 * 17, "", email, name));
            }

            return this;
        }

        public ProviderBulkUploadCsvFilePage WriteApprenticeshipRecordsToCsvFile()
        {
            objectContext.SetBulkuploadApprentices(_apprenticeList);
            CreateCsvFileHelper.CreateCsvFile(_apprenticeList, CsvFileLocation);
            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFileForLegalEntity(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            var listOfCohortReference = GetCohortReferences();

            var apprenticeList = new List<BulkUploadApprenticeDetails>();

            foreach (var cohortRef in listOfCohortReference)
            {
                for (var i = 1; i <= numberOfApprenticesPerCohort; i++)
                {
                    apprenticeList.Add(SetApprenticeDetailsForLegalEntity(i * 17, cohortRef, email, name));
                }
            }

            for (int i = 0; i < numberOfApprenticesWithoutCohortRef; i++)
            {
                apprenticeList.Add(SetApprenticeDetailsForLegalEntity(i + 1 * 17, "", email, name));
            }

            objectContext.SetBulkuploadApprentices(apprenticeList);

            CreateCsvFileHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef)
        {
            var listOfCohortReference = GetCohortReferences();

            var apprenticeList = new List<BulkUploadApprenticeDetails>();

            foreach (var cohortRef in listOfCohortReference)
            {
                for (var i = 1; i <= numberOfApprenticesPerCohort; i++)
                {
                    apprenticeList.Add(SetApprenticeDetails(i * 17, cohortRef));
                }
            }

            for (int i = 0; i < numberOfApprenticesWithoutCohortRef; i++)
            {
                apprenticeList.Add(SetApprenticeDetails(i + 1 * 17, ""));
            }

            objectContext.SetBulkuploadApprentices(apprenticeList);

            CreateCsvFileHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(List<BulkUploadApprenticeDetails> apprenticeDetails)
        {
            var apprenticeList = new List<BulkUploadApprenticeDetails>();

            foreach (var apprenticeDetail in apprenticeDetails) apprenticeList.Add(apprenticeDetail);

            objectContext.SetBulkuploadApprentices(apprenticeList);

            CreateCsvFileHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFileWithCohortReference(string cohortReference, int numberOfApprenticesPerCohort)
        {
            var apprenticeList = new List<BulkUploadApprenticeDetails>();

            for (var i = 1; i <= numberOfApprenticesPerCohort; i++)
                apprenticeList.Add(SetApprenticeDetails(i * 17, cohortReference));

            objectContext.SetBulkuploadApprentices(apprenticeList);

            CreateCsvFileHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        private List<string> GetCohortReferences()
        {
            List<string> cohortRefs = objectContext.GetCohortReferenceList();
            if (cohortRefs == null || cohortRefs.Count == 0)
            {
                cohortRefs = [];
                var cohortRef = objectContext.GetCohortReference();
                cohortRefs.Add(cohortRef);
            }

            return cohortRefs;
        }

        public ProviderBulkUploadCsvFilePage UploadFile()
        {
            formCompletionHelper.EnterText(ChooseFileButton, CsvFileLocation);
            formCompletionHelper.ClickElement(UploadFileButton);
            return this;
        }

        private BulkUploadApprenticeDetails SetApprenticeDetails(int courseCode, string cohortRef)
        {
            var datahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper([""]), objectContext, context.Get<CommitmentsSqlDataHelper>());

            string agreementId;

            var sqlHelper = context.Get<AccountsDbSqlHelper>();

            if (cohortRef == "" || cohortRef == null)
            {
                var employerUser = context.GetUser<EmployerWithMultipleAccountsUser>();
                var employerName = employerUser.OrganisationName[..3] + "%";
                agreementId = sqlHelper.GetAgreementId(employerUser.Username, employerName).Trim();
            }
            else
            {
                agreementId = sqlHelper.GetAgreementIdByCohortRef(cohortRef).Trim();
            }

            var isNonLevy = sqlHelper.GetIsLevyByAgreementId(agreementId) == "0";
            var startDate = apprenticeCourseDataHelper.CourseStartDate;
            var endDate = apprenticeCourseDataHelper.CourseEndDate;

            if (isNonLevy)
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.UtcNow.AddYears(1);
            }

            return new BulkUploadApprenticeDetails(courseCode, agreementId, datahelper.ApprenticeDob, startDate, endDate)
            {
                CohortRef = cohortRef,
                ULN = RandomDataGenerator.GenerateRandomUln(),
                FamilyName = datahelper.ApprenticeLastname,
                GivenNames = datahelper.ApprenticeFirstname,
                TotalPrice = datahelper.TrainingCost,
                ProviderRef = datahelper.EmployerReference,
                EmailAddress = datahelper.ApprenticeEmail,
            };
        }

        private BulkUploadApprenticeDetails SetApprenticeDetailsForLegalEntity(int courseCode, string cohortRef, string email, string name)
        {
            var datahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper([""]), objectContext, context.Get<CommitmentsSqlDataHelper>());

            string agreementId;
            var sqlHelper = context.Get<AccountsDbSqlHelper>();
            if (cohortRef == "" || cohortRef == null)
            {
                agreementId = sqlHelper.GetAgreementId(email, name).Trim();
            }
            else
            {
                agreementId = sqlHelper.GetAgreementIdByCohortRef(cohortRef).Trim();
            }


            var isNonLevy = sqlHelper.GetIsLevyByAgreementId(agreementId) == "0";
            var startDate = apprenticeCourseDataHelper.CourseStartDate;
            var endDate = apprenticeCourseDataHelper.CourseEndDate;

            if (isNonLevy)
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.UtcNow.AddYears(1);
            }

            return new BulkUploadApprenticeDetails(courseCode, agreementId, datahelper.ApprenticeDob, startDate, endDate)
            {
                CohortRef = cohortRef,
                ULN = RandomDataGenerator.GenerateRandomUln(),
                FamilyName = datahelper.ApprenticeLastname,
                GivenNames = datahelper.ApprenticeFirstname,
                TotalPrice = datahelper.TrainingCost,
                ProviderRef = datahelper.EmployerReference,
                EmailAddress = datahelper.ApprenticeEmail
            };
        }
    }
}