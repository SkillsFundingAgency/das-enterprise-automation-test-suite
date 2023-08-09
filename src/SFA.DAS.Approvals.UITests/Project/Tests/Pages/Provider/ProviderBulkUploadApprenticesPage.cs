using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderBulkUploadApprenticesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Bulk upload apprentices";
        private static By ChooseFileButton => By.Id("files-upload");
        private static By UploadFileButton => By.Id("submit-upload-apprentices");
        private static By TableCells => By.ClassName("govuk-table__row");

        public ProviderBulkUploadApprenticesPage(ScenarioContext context) : base(context) { }

        public ProviderApproveApprenticeDetailsPage UploadFileAndConfirmSuccessful(int numberOfApprentices, bool isNonLevy = false)
        {
            objectContext.SetNoOfApprentices(numberOfApprentices);

            string fileLocation = Path.GetFullPath(@"..\..\..\") + approvalsConfig.BulkUploadFileLocation;

            List<BulkUploadApprenticeDetails> ApprenticeList = new List<BulkUploadApprenticeDetails>();
            
            for (int i = 0; i < numberOfApprentices; i++) ApprenticeList.Add(SetApprenticeDetails((i + 1) * 17));

            new CreateCsvFileHelper().CreateCsvFile(ApprenticeList, fileLocation);

            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);           
            formCompletionHelper.ClickElement(UploadFileButton);

            for (int i = 0; i < numberOfApprentices; i++)
            {
                string uln = ApprenticeList[i].ULN;

                Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(uln), $"Unable to locate ULN: {uln} on 'Approve apprentices details' page");
            }
            
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private BulkUploadApprenticeDetails SetApprenticeDetails(int courseCode, bool isNonLevy = false)
        {
            var employerUser = context.GetUser<LevyUser>();
            var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
            DateTime dateOfBirth = Convert.ToDateTime($"{ apprenticeDataHelper.DateOfBirthYear}-{ apprenticeDataHelper.DateOfBirthMonth}-{apprenticeDataHelper.DateOfBirthDay}");
            string emailAddress = $"{ apprenticeDataHelper.ApprenticeFirstname}.{ apprenticeDataHelper.ApprenticeLastname}.{courseCode}@mailinator.com";
            string agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();

            var startDate = apprenticeCourseDataHelper.CourseStartDate;
            var endDate = apprenticeCourseDataHelper.CourseEndDate;
            if (isNonLevy)
            {
                startDate = DateTime.UtcNow;
                endDate = DateTime.UtcNow.AddYears(1);
            }
            
            return new BulkUploadApprenticeDetails(courseCode, agreementId, dateOfBirth, startDate, endDate)
            {
                CohortRef = objectContext.GetCohortReference(),
                ULN = RandomDataGenerator.GenerateRandomUln(),
                FamilyName = apprenticeDataHelper.ApprenticeLastname,
                GivenNames = apprenticeDataHelper.ApprenticeFirstname,
                TotalPrice = apprenticeDataHelper.TrainingCost,
                ProviderRef = apprenticeDataHelper.EmployerReference,
                EmailAddress = emailAddress
            };
        }
    }
}
