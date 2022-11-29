using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class AddAndEditApprenticeDetailsBasePage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private static By FirstNameField => By.Id("FirstName");
        private static By LastNameField => By.Id("LastName");
        private static By EmailField => By.Id("Email");
        private static By DateOfBirthDay => By.Id("BirthDay");
        private static By DateOfBirthMonth => By.Id("BirthMonth");
        private static By DateOfBirthYear => By.Id("BirthYear");
        private static By ActualStartDateDay => By.Id("ActualStartDay");
        public static By ActualStartDateMonth => By.Id("ActualStartMonth");
        public static By ActualStartDateYear => By.Id("ActualStartYear");
        public static By StartDateMonth => By.Id("StartMonth");
        public static By StartDateYear => By.Id("StartYear");
        private static By EndDateMonth => By.Id("EndMonth");
        private static By EndDateYear => By.Id("EndYear");
        private static By EmploymentEndMonth => By.Id("EmploymentEndMonth");
        private static By EmploymentEndYear => By.Id("EmploymentEndYear");
        private static By TrainingCost => By.Id("Cost");
        private static By EmploymentPrice => By.Id("EmploymentPrice");
        private static By EmployerReference => By.Id("Reference");
        private static By StartDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-StartDate']");
        private static By EndDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-EndDate']");
        protected virtual By AddButtonSelector => By.XPath("//button[text()='Add']");

        public AddAndEditApprenticeDetailsBasePage(ScenarioContext context) : base(context)
        {
        }

        protected void EnterTrainingCostAndEmpReference()
        {
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);

            if (tags.Contains("portableflexijob"))
                formCompletionHelper.EnterText(EmploymentPrice, apprenticeDataHelper.TrainingCost.ToInt() - 50);
        }

        protected void ClickStartMonth() => formCompletionHelper.ClickElement(StartDateMonth);

        protected void ClickActualStartDateDay() => formCompletionHelper.ClickElement(ActualStartDateDay);

        protected void EnterStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(StartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(StartDateYear, dateTime.Year);
        }

        protected void EnterActualStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(ActualStartDateDay, dateTime.Day);
            formCompletionHelper.EnterText(ActualStartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(ActualStartDateYear, dateTime.Year);
        }

        protected void EnterEndDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(EndDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(EndDateYear, dateTime.Year);

            if (tags.Contains("portableflexijob"))
            {
                formCompletionHelper.EnterText(EndDateYear, dateTime.Year + 2);
                formCompletionHelper.EnterText(EmploymentEndMonth, dateTime.Month);
                formCompletionHelper.EnterText(EmploymentEndYear, dateTime.Year + 1);
            }
        }

        protected void EnterApprenticeName()
        {
            formCompletionHelper.EnterText(FirstNameField, apprenticeDataHelper.ApprenticeFirstname);
            formCompletionHelper.EnterText(LastNameField, apprenticeDataHelper.ApprenticeLastname);
        }

        protected void EnterApprenticeEmail() => formCompletionHelper.EnterText(EmailField, apprenticeDataHelper.ApprenticeEmail);

        protected void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.Contains("aslistedemployer")) return;

            EnterApprenticeEmail();
        }

        protected void EnterDob()
        {
            formCompletionHelper.EnterText(DateOfBirthDay, apprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, apprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, apprenticeDataHelper.DateOfBirthYear);
        }

        public void VerifyOverlappingTrainingDetailsError(bool displayStartDateError, bool displayEndDateError)
        {
            var courseStartDate = SetEIJourneyTestData(0);

            ClickStartMonth();

            EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(AddButtonSelector);

            ValidateOltdErrorMessage(StartDateErrorMessagelLink, displayStartDateError);
            ValidateOltdErrorMessage(EndDateErrorMessagelLink, displayEndDateError);
        }

        protected DateTime SetEIJourneyTestData(int apprenticeNo)
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
                apprenticeDataHelper.TrainingCost = "7500";

                return new DateTime(objectContext.GetEIStartYear(), objectContext.GetEIStartMonth(), 1);
            }

            if (objectContext.HasStartDate()) apprenticeCourseDataHelper.CourseStartDate = objectContext.GetStartDate();

            if (objectContext.IsSameApprentice()) apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);

            return apprenticeCourseDataHelper.CourseStartDate;
        }

        private void ValidateOltdErrorMessage(By locator, bool shouldBeDisplayed)
        {
            if (shouldBeDisplayed)
            {
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message not dsiplayed");
                
                string expectedMessage = "The date overlaps with existing dates for the same apprentice";
                string actualMessage = pageInteractionHelper.GetText(locator);
                StringAssert.StartsWith(expectedMessage, actualMessage, "Incorrect Date Overlaps Message displayed");
            }
            else
            {
                Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message should not be dsiplayed");
            }
        }
    }
}