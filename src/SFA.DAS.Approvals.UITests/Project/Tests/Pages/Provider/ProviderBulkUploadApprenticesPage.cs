using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
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
        private By ChooseFileButton => By.Id("files-upload");
        private By UploadFileButton => By.Id("submit-upload-apprentices");
        private By TableCells => By.ClassName("govuk-table__row");

        public ProviderBulkUploadApprenticesPage(ScenarioContext context) : base(context) { }

        public ProviderApproveApprenticeDetailsPage UploadFileAndConfirmSuccessful(int numberOfApprentices, bool isNonLevy = false)
        {
            objectContext.SetNoOfApprentices(numberOfApprentices);

            string fileLocation = Path.GetFullPath(@"..\..\..\") + approvalsConfig.BulkUploadFileLocation;

            List<ApprenticeDetails> ApprenticeList = new List<ApprenticeDetails>();
            
            for (int i = 0; i < numberOfApprentices; i++) ApprenticeList.Add(SetApprenticeDetails((i + 1) * 17));

            new CreateCsvFileHelper().CreateCsvFile(ApprenticeList, fileLocation);

            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);           
            formCompletionHelper.ClickElement(UploadFileButton);

            for (int i = 0; i < numberOfApprentices; i++)
            {
                Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(apprenticeDataHelper.Ulns[i]),
                    $"Unable to locate ULN: {apprenticeDataHelper.Ulns[i]} on 'Approve apprentices details' page");
            }
            
            return new ProviderApproveApprenticeDetailsPage(context);
        }

        private ApprenticeDetails SetApprenticeDetails(int courseCode, bool isNonLevy = false)
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
            
            return new ApprenticeDetails(courseCode, dateOfBirth, startDate, endDate)
            {
                CohortRef = objectContext.GetCohortReference(),
                ULN = apprenticeDataHelper.Uln(),
                FamilyName = apprenticeDataHelper.ApprenticeLastname,
                GivenNames = apprenticeDataHelper.ApprenticeFirstname,
                TotalPrice = apprenticeDataHelper.TrainingCost,
                ProviderRef = apprenticeDataHelper.EmployerReference,
                EmailAddress = emailAddress,
                AgreementId = agreementId
            };
        }
    }
}
