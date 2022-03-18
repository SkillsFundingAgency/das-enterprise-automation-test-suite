using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddApprenticeDetailsPage : AddApprenticeDetailsBasePage
    {
        private By SaveAndContinueButton => By.CssSelector("#main-content .govuk-button");


        public AddApprenticeDetailsPage(ScenarioContext context) : base(context) { }

        private void AddCourse()
        {
            var course = apprenticeCourseDataHelper.Course;
            if (objectContext.IsSameApprentice()) course = apprenticeCourseDataHelper.OtherCourse;
            formCompletionHelper.SelectFromDropDownByValue(TrainingCourseContainer, course);
        }

        public ApproveApprenticeDetailsPage SubmitValidApprenticeDetails(bool isMF, int apprenticeNo = 0)
        {
            var courseStartDate = SetEIJourneyTestData(apprenticeNo);

            EnterApprenticeMandatoryValidDetails();

            EnterDob();

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

            if (IsSelectStandardWithMultipleOptions()) new SelectAStandardOptionpage(context).SelectAStandardOption();

            return new ApproveApprenticeDetailsPage(context);
        }

        public YouCantApproveThisApprenticeRequestUntilPage DraftDynamicHomePageSubmitValidApprenticeDetails()
        {
            EnterApprenticeMandatoryValidDetails();

            formCompletionHelper.ClickElement(SaveAndContinueButton);

            return new YouCantApproveThisApprenticeRequestUntilPage(context);
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

                objectContext.SetEIAgeCategoryAsOfAug2021(eiApprenticeDetail.AgeCategoryAsOfAug2021);
                objectContext.SetEIStartMonth(eiApprenticeDetail.StartMonth);
                objectContext.SetEIStartYear(eiApprenticeDetail.StartYear);

                apprenticeDataHelper.DateOfBirthDay = 1;
                apprenticeDataHelper.DateOfBirthMonth = 8;
                apprenticeDataHelper.DateOfBirthYear = (objectContext.GetEIAgeCategoryAsOfAug2021().Equals("Aged16to24")) ? 2005 : 1994;
                apprenticeDataHelper.ApprenticeFirstname = RandomDataGenerator.GenerateRandomFirstName();
                apprenticeDataHelper.ApprenticeLastname = RandomDataGenerator.GenerateRandomLastName();
                apprenticeDataHelper.TrainingPrice = "7500";

                return new DateTime(objectContext.GetEIStartYear(), objectContext.GetEIStartMonth(), 1);
            }

            if (objectContext.IsSameApprentice()) apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);

            return apprenticeCourseDataHelper.CourseStartDate;
        }
    }
}
