using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add apprentice details";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By EmailField => By.Id("Email");
        private By DateOfBirthDay => By.Id("BirthDay");
        private By DateOfBirthMonth => By.Id("BirthMonth");
        private By DateOfBirthYear => By.Id("BirthYear");
        private By TrainingCourseContainer => By.Id("CourseCode");
        private By StartDateMonth => By.Id("StartMonth");
        private By StartDateYear => By.Id("StartYear");
        private By EndDateMonth => By.Id("EndMonth");
        private By EndDateYear => By.Id("EndYear");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("Reference");
        private By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");

        public AddApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        private void AddCourse()
        {
            var course = apprenticeCourseDataHelper.Course;

            if (objectContext.IsSameApprentice()) course = apprenticeCourseDataHelper.OtherCourse;
            
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, course);
        }

        public ReviewYourCohortPage SubmitValidApprenticeDetails(bool isMF, int apprenticeNo = 0)
        {
            var courseStartDate = SetEIJourneyTestData(apprenticeNo);

            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);

            AddCourse();

            formCompletionHelper.ClickElement(StartDateMonth);
            if (isMF == false)
            {
                formCompletionHelper.EnterText(StartDateMonth, courseStartDate.Month);
                formCompletionHelper.EnterText(StartDateYear, courseStartDate.Year);
            }

            formCompletionHelper.EnterText(EndDateMonth, apprenticeCourseDataHelper.CourseEndDate.Month);
            formCompletionHelper.EnterText(EndDateYear, apprenticeCourseDataHelper.CourseEndDate.Year);
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingPrice);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            if (IsSelectStandardWithMultipleOptions())  new SelectAStandardOptionpage(_context).SelectAStandard();

            return new ReviewYourCohortPage(_context);
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.ClickElement(SaveAndContinueButton);
            return new YouCantApproveThisApprenticeRequestUntilPage(_context);
        }

        public AddApprenticeDetailsPage ConfirmOnlyStandardCoursesAreSelectable()
        {
            var options = formCompletionHelper.GetAllDropDownOptions(TrainingCourseContainer);

            Assert.True(options.All(x => !x.Contains("(Framework)")));
            
            return this;
        }

        private DateTime SetEIJourneyTestData(int apprenticeNo)
        {
            if (objectContext.IsEIJourney())
            {
                var eiApprenticeDetailList = objectContext.GetEIApprenticeDetailList();

                var eiApprenticeDetail = eiApprenticeDetailList[apprenticeNo];

                objectContext.SetEIAgeCategoryAsOfAug2020(eiApprenticeDetail.AgeCategoryAsOfAug2020);
                objectContext.SetEIStartMonth(eiApprenticeDetail.StartMonth);
                objectContext.SetEIStartYear(eiApprenticeDetail.StartYear);

                apprenticeDataHelper.DateOfBirthDay = 1;
                apprenticeDataHelper.DateOfBirthMonth = 8;
                apprenticeDataHelper.DateOfBirthYear = (objectContext.GetEIAgeCategoryAsOfAug2020().Equals("Aged16to24")) ? 2004 : 1995;
                apprenticeDataHelper.ApprenticeFirstname = RandomDataGenerator.GenerateRandomFirstName();
                apprenticeDataHelper.ApprenticeLastname = RandomDataGenerator.GenerateRandomLastName();
                apprenticeDataHelper.TrainingPrice = "7500";

                return new DateTime(objectContext.GetEIStartYear(), objectContext.GetEIStartMonth(), 1);
            }

            if (objectContext.IsSameApprentice())
            {
                apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);
            }

            return apprenticeCourseDataHelper.CourseStartDate;
        }

        private void EnterApprenticeMandatoryValidDetails()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);

            if (_context.ScenarioInfo.Tags.Contains("aslistedemployer")) return;

            formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);
        }
    }
}
