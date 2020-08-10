using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
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
        private By TableCells => By.Id("cohort-details");

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

        public ProviderReviewYourCohortPage UploadFileAndConfirmSuccessful(int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(numberOfApprentices);

            string fileLocation = Path.GetFullPath(@"..\..\..\") + approvalsConfig.BulkUploadFileLocation;
            List<ApprenticeDetails> ApprenticeList = new List<ApprenticeDetails>();
            for (int i = 0; i < numberOfApprentices; i++)
            {
                if (i % 2 == 0)
                    ApprenticeList.Add(SetApprenticeDetails(CourseType.Standard));
                else
                    ApprenticeList.Add(SetApprenticeDetails(CourseType.Framework));
            }
            
            _bulkUploadDataHelper.CreateBulkUploadFile(ApprenticeList, fileLocation);
            formCompletionHelper.EnterText(ChooseFileButton, fileLocation);           
            formCompletionHelper.ClickElement(UploadFileButton);

            for (int i = 0; i < numberOfApprentices; i++)
            {
                Assert.IsTrue(pageInteractionHelper.GetTextFromElementsGroup(TableCells).Contains(apprenticeDataHelper.Ulns[i]),
                    $"Unable to locate ULN: {apprenticeDataHelper.Ulns[i]} on 'Review your cohort' page");
            }
            
            return new ProviderReviewYourCohortPage(_context);
        }

        private ApprenticeDetails SetApprenticeDetails(CourseType courseType)
        {
            DateTime dateOfBirth = Convert.ToDateTime($"{ apprenticeDataHelper.DateOfBirthYear}-{ apprenticeDataHelper.DateOfBirthMonth}-{apprenticeDataHelper.DateOfBirthDay}");

            return new ApprenticeDetails(courseType)
            {
                CohortRef = objectContext.GetCohortReference(),
                ULN = apprenticeDataHelper.Uln(),
                FamilyName = apprenticeDataHelper.ApprenticeLastname,
                GivenNames = apprenticeDataHelper.ApprenticeFirstname,
                DateOfBirth = dateOfBirth,
                StartDate = apprenticeCourseDataHelper.CourseStartDate,
                EndDate = apprenticeCourseDataHelper.CourseEndDate,
                TotalPrice = apprenticeDataHelper.TrainingPrice,
                ProviderRef = apprenticeDataHelper.EmployerReference
            };
        }

    }
}
