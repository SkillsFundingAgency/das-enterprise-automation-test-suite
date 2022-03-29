using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
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
        private List<ApprenticeDetails> ApprenticeList;
        private List<ApprenticeDetailsV2> ApprenticeListV2;
        internal string fileLocation;

        protected override string PageTitle => "Upload a CSV file";
        private readonly BulkUploadDataHelper _bulkUploadDataHelper;
        private readonly BulkUploadV2ValidationDataHelper _bulkUploadV2ValidationDataHelper;

        public ProviderBulkUploadCsvFilePage(ScenarioContext context) : base(context)
        {
            SetFileLocation();
           
            ApprenticeList = new List<ApprenticeDetails>();
            ApprenticeListV2 = new List<ApprenticeDetailsV2>();
            _bulkUploadDataHelper = new BulkUploadDataHelper();
            _bulkUploadV2ValidationDataHelper = new BulkUploadV2ValidationDataHelper();
        }

        private void SetFileLocation()
        {
            var testTitle = context.ScenarioInfo.Title.Substring(0, 8);
            string fileName = "BulkUpload.csv";
            switch (testTitle)
            {
                case "AP_BU_01":
                    fileName = "BulkUpload_1.csv";
                    break;
                case "AP_BU_02":
                    fileName = "BulkUpload_2.csv";
                    break;
                case "AP_BU_03":
                    fileName = "BulkUpload_3.csv";
                    break;
                case "AP_BU_04":
                    fileName = "BulkUpload_4.csv";
                    break;
                case "AP_BU_05":
                    fileName = "BulkUpload_5.csv";
                    break;
                case "AP_BU_06":
                    fileName = "BulkUpload_6.csv";
                    break;
                case "AP_BU_07":
                    fileName = "BulkUpload_7.csv";
                    break;
                case "AP_BU_08":
                    fileName = "BulkUpload_8.csv";
                    break;
                case "AP_BU_09":
                    fileName = "BulkUpload_9.csv";
                    break;
            }

            fileLocation = Path.GetFullPath(@"..\..\..\") + fileName;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(int numberOfApprenticesPerCohort = 1, int numberOfApprenticesWithoutCohortRef = 0)
        {
           var listOfCohortReference = GetCohortReferences();
            foreach (var cohortRef in listOfCohortReference)
            {
                for (var counter = 1; counter <= numberOfApprenticesPerCohort; counter++)
                {
                    ApprenticeList.Add(SetApprenticeDetails(counter * 17, cohortRef));
                }
            }

            for (int i = 0; i < numberOfApprenticesWithoutCohortRef; i++)
            {
                ApprenticeList.Add(SetApprenticeDetails(i+1 * 17, ""));
            }

            objectContext.Replace("BulkuploadApprentices", ApprenticeList);
            _bulkUploadDataHelper.CreateBulkUploadFile(ApprenticeList, fileLocation);
            return this;
        }

        public ProviderBulkUploadCsvFilePage CreateACsvFile(List<ApprenticeDetailsV2> apprenticeDetails)
        {            
            foreach (var apprenticeDetail in apprenticeDetails)
            {
                ApprenticeListV2.Add(apprenticeDetail);
            }         

            objectContext.Replace("BulkuploadApprentices", ApprenticeListV2);
            _bulkUploadV2ValidationDataHelper.CreateBulkUploadFileToValidate(ApprenticeListV2, fileLocation);
            return this;
        }


        public ProviderBulkUploadCsvFilePage CreateACsvFileWithCohortReference(string cohortReference, int numberOfApprenticesPerCohort = 1)
        {          
            for (var counter = 1; counter <= numberOfApprenticesPerCohort; counter++)
            {
                ApprenticeList.Add(SetApprenticeDetails(counter * 17, cohortReference));
            }

            objectContext.Replace("BulkuploadApprentices", ApprenticeList);
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
            string agreementId;
            
            if (cohortRef == "" || cohortRef == null)
            {
                var employerUser = context.GetUser<LevyUser>();
                var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
                agreementId = context.Get<AgreementIdSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();
            }
            else 
            {
                agreementId = context.Get<AgreementIdSqlHelper>().GetAgreementIdByCohortRef(cohortRef).Trim();
            }
            

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