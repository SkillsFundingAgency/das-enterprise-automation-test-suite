using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderBulkUploadCsvFilePage : ApprovalsBasePage
    {
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");
        private By ChooseFileButton => By.Id("attachment");
        private By UploadFileButton => By.Id("submit-upload-apprentices");
        protected readonly string CsvFileLocation;
        private List<ApprenticeDetails> _apprenticeList;

        protected override string PageTitle => "Upload a CSV file";

        private readonly CreateCsvFileHelper _bulkUploadDataHelper;

        public ProviderBulkUploadCsvFilePage(ScenarioContext context) : base(context)
        {
            CsvFileLocation = Path.GetFullPath(@"..\..\..\") + $"{context.ScenarioInfo.Title.Substring(0, 8)}_BulkUpload.csv";

            _bulkUploadDataHelper = new CreateCsvFileHelper();
            _apprenticeList = new List<ApprenticeDetails>();
        }

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
            _bulkUploadDataHelper.CreateCsvFile(_apprenticeList, CsvFileLocation);
            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFileForLegalEntity(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef, string email, string name)
        {
            var listOfCohortReference = GetCohortReferences();

            var apprenticeList = new List<ApprenticeDetails>();

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

            _bulkUploadDataHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(int numberOfApprenticesPerCohort, int numberOfApprenticesWithoutCohortRef)
        {
           var listOfCohortReference = GetCohortReferences();

            var apprenticeList = new List<ApprenticeDetails>();

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

            _bulkUploadDataHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(List<ApprenticeDetails> apprenticeDetails)
        {
            var apprenticeList = new List<ApprenticeDetails>();

            foreach (var apprenticeDetail in apprenticeDetails) 
                apprenticeList.Add(apprenticeDetail);

            objectContext.SetBulkuploadApprentices(apprenticeList);

            _bulkUploadDataHelper.CreateCsvFile(apprenticeList, CsvFileLocation);

            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFileWithCohortReference(string cohortReference, int numberOfApprenticesPerCohort)
        {
            var apprenticeList = new List<ApprenticeDetails>();

            for (var i = 1; i <= numberOfApprenticesPerCohort; i++) 
                apprenticeList.Add(SetApprenticeDetails(i * 17, cohortReference));

            objectContext.SetBulkuploadApprentices(apprenticeList);

            _bulkUploadDataHelper.CreateCsvFile(apprenticeList, CsvFileLocation);
            
            return this;
        }

        private List<string> GetCohortReferences()
        {
            List<string> cohortRefs = objectContext.GetCohortReferenceList();
            if (cohortRefs == null || cohortRefs.Count == 0)
            {
                cohortRefs = new List<string>();
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

        private ApprenticeDetails SetApprenticeDetails(int courseCode, string cohortRef)
        {
            var datahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(new string[] { "" }), objectContext, context.Get<CommitmentsSqlDataHelper>());

            string agreementId;
            var sqlHelper = context.Get<AgreementIdSqlHelper>();

            if (cohortRef == "" || cohortRef == null)
            {
                var employerUser = context.GetUser<EmployerWithMultipleAccountsUser>();
                var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
                agreementId = sqlHelper.GetAgreementId(employerUser.Username, employerName).Trim();
            }
            else 
            {
                agreementId = sqlHelper.GetAgreementIdByCohortRef(cohortRef).Trim();
            }

            var isNonLevy =sqlHelper.GetIsLevyByAgreementId(agreementId) == "0" ? true : false;
            var startDate = apprenticeCourseDataHelper.CourseStartDate;
            var endDate = apprenticeCourseDataHelper.CourseEndDate;

            if (isNonLevy)
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.UtcNow.AddYears(1);
            }

            return new ApprenticeDetails(courseCode, datahelper.ApprenticeDob, startDate, endDate)
            {
                CohortRef = cohortRef,
                ULN = datahelper.Uln(),
                FamilyName = datahelper.ApprenticeLastname,
                GivenNames = datahelper.ApprenticeFirstname,
                TotalPrice = datahelper.TrainingCost,
                ProviderRef = datahelper.EmployerReference,
                EmailAddress = datahelper.ApprenticeEmail,
                AgreementId = agreementId
            };
        }

        private ApprenticeDetails SetApprenticeDetailsForLegalEntity(int courseCode, string cohortRef, string email, string name)
        {
            var datahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(new string[] { "" }), objectContext, context.Get<CommitmentsSqlDataHelper>());

            string agreementId;
            var sqlHelper = context.Get<AgreementIdSqlHelper>();
            if (cohortRef == "" || cohortRef == null)
            {
                agreementId = sqlHelper.GetAgreementId(email, name).Trim();
            }
            else
            {
                agreementId = sqlHelper.GetAgreementIdByCohortRef(cohortRef).Trim();
            }


            var isNonLevy = sqlHelper.GetIsLevyByAgreementId(agreementId) == "0" ? true : false;
            var startDate = apprenticeCourseDataHelper.CourseStartDate;
            var endDate = apprenticeCourseDataHelper.CourseEndDate;

            if (isNonLevy)
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.UtcNow.AddYears(1);
            }

            return new ApprenticeDetails(courseCode, datahelper.ApprenticeDob, startDate, endDate)
            {
                CohortRef = cohortRef,
                ULN = datahelper.Uln(),
                FamilyName = datahelper.ApprenticeLastname,
                GivenNames = datahelper.ApprenticeFirstname,
                TotalPrice = datahelper.TrainingCost,
                ProviderRef = datahelper.EmployerReference,
                EmailAddress = datahelper.ApprenticeEmail,
                AgreementId = agreementId
            };
        }
    }
}