using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
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

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly BulkUploadDataHelper _bulkUploadDataHelper;
        #endregion

        public ProviderBulkUploadApprenticesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _bulkUploadDataHelper = new BulkUploadDataHelper();
        }

        public ProviderApproveApprenticeDetailsPage UploadFileAndConfirmSuccessful(int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(numberOfApprentices);

            string fileLocation = Path.GetFullPath(@"..\..\..\") + approvalsConfig.BulkUploadFileLocation;
            List<ApprenticeDetails> ApprenticeList = new List<ApprenticeDetails>();
            
            for (int i = 0; i < numberOfApprentices; i++)
            {
                ApprenticeList.Add(SetApprenticeDetails((i + 1) * 17));
            }
            
            _bulkUploadDataHelper.CreateBulkUploadFile(ApprenticeList, fileLocation);
            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);           
            formCompletionHelper.ClickElement(UploadFileButton);

            for (int i = 0; i < numberOfApprentices; i++)
            {
                Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(apprenticeDataHelper.Ulns[i]),
                    $"Unable to locate ULN: {apprenticeDataHelper.Ulns[i]} on 'Approve apprentices details' page");
            }
            
            return new ProviderApproveApprenticeDetailsPage(_context);
        }

        private ApprenticeDetails SetApprenticeDetails(int courseCode)
        {
            var employerUser = _context.GetUser<LevyUser>();
            var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
            DateTime dateOfBirth = Convert.ToDateTime($"{ apprenticeDataHelper.DateOfBirthYear}-{ apprenticeDataHelper.DateOfBirthMonth}-{apprenticeDataHelper.DateOfBirthDay}");
            string emailAddress = $"{ apprenticeDataHelper.ApprenticeFirstname}.{ apprenticeDataHelper.ApprenticeLastname}.{courseCode}@mailinator.com";
            string agreementId = _context.Get<AgreementIdSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();
            
            return new ApprenticeDetails(courseCode)
            {
                CohortRef = objectContext.GetCohortReference(),
                ULN = apprenticeDataHelper.Uln(),
                FamilyName = apprenticeDataHelper.ApprenticeLastname,
                GivenNames = apprenticeDataHelper.ApprenticeFirstname,
                DateOfBirth = dateOfBirth,
                StartDate = Convert.ToDateTime(apprenticeCourseDataHelper.CourseStartDate),
                EndDate = Convert.ToDateTime(apprenticeCourseDataHelper.CourseEndDate),
                TotalPrice = apprenticeDataHelper.TrainingPrice,
                ProviderRef = apprenticeDataHelper.EmployerReference,
                EmailAddress = emailAddress,
                AgreementId = agreementId
            };
        }
    }
}
