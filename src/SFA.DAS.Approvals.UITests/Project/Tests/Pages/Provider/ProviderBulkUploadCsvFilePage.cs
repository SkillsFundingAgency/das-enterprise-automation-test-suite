using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
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
        private List<ApprenticeDetails> ApprenticeList;
        private string fileLocation;

        protected override string PageTitle => "Upload a CSV file";
        private readonly BulkUploadDataHelper _bulkUploadDataHelper;

        public ProviderBulkUploadCsvFilePage(ScenarioContext context) : base(context)
        {
            SetFileLocation();
           
            ApprenticeList = new List<ApprenticeDetails>();
            _bulkUploadDataHelper = new BulkUploadDataHelper();
        }

        private void SetFileLocation()
        {
            var testTitle = context.ScenarioInfo.Title;
            string fileName = "BulkUpload.csv";
            switch (testTitle)
            {
                case "AP_BU_01_Upload Details On Single Cohort":
                    fileName = "BulkUpload_1.csv";
                    break;
                case "AP_BU_02_Upload Details On Multiple Cohorts":
                    fileName = "BulkUpload_2.csv";
                    break;
                case "AP_BU_03_Upload Details On Multiple Cohorts With Multiple Employers":
                    fileName = "BulkUpload_3.csv";
                    break;
            }

            fileLocation = Path.GetFullPath(@"..\..\..\") + "\\Project\\DataFiles\\" + fileName;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(int numberOfApprenticesPerCohort = 1)
        {
           var listOfCohortReference = GetCohortReferences();
            foreach (var cohortRef in listOfCohortReference)
            {
                for (var counter = 1; counter <= numberOfApprenticesPerCohort; counter++)
                {
                    ApprenticeList.Add(SetApprenticeDetails(counter * 17, cohortRef));
                }
            }
            _bulkUploadDataHelper.CreateBulkUploadFile(ApprenticeList, fileLocation);
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
            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);
            formCompletionHelper.ClickElement(UploadFileButton);
            return this;
        }

        private ApprenticeDetails SetApprenticeDetails(int courseCode, string cohortRef)
        {
            var datahelper = new ApprenticeDataHelper(new ApprenticePPIDataHelper(new string[] { "" }), objectContext, context.Get<CommitmentsSqlDataHelper>());
            DateTime dateOfBirth = Convert.ToDateTime($"{ datahelper.DateOfBirthYear}-{ datahelper.DateOfBirthMonth}-{datahelper.DateOfBirthDay}");
            string emailAddress = $"{ datahelper.ApprenticeFirstname}.{ datahelper.ApprenticeLastname}.{courseCode}@mailinator.com";
            string agreementId = context.Get<AgreementIdSqlHelper>().GetAgreementIdByCohortRef(cohortRef).Trim();

            return new ApprenticeDetails(courseCode)
            {
                CohortRef = cohortRef,
                ULN = datahelper.Uln(),
                FamilyName = datahelper.ApprenticeLastname,
                GivenNames = datahelper.ApprenticeFirstname,
                DateOfBirth = dateOfBirth,
                StartDate = Convert.ToDateTime(apprenticeCourseDataHelper.CourseStartDate),
                EndDate = Convert.ToDateTime(apprenticeCourseDataHelper.CourseEndDate),
                TotalPrice = datahelper.TrainingPrice,
                ProviderRef = datahelper.EmployerReference,
                EmailAddress = emailAddress,
                AgreementId = agreementId
            };
        }
    }
}