using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprenticeDetailsBasePage : EditApprentinceNameDobAndReferenceBasePage
    {
        private By TrainingCost => By.CssSelector("#Cost, #cost");

        protected By TrainingCourseContainer => By.CssSelector("#trainingCourse");

        private By EmailField => By.CssSelector("#Email,#email");

        private By ReadOnyEmailField => By.CssSelector(".das-definition-list > dd#email,dd#Email");

        private By ReadOnlyTrainingCost => By.CssSelector(".das-definition-list > dd#cost");

        private By ReadOnlyTrainingCourse => By.CssSelector(".das-definition-list > dd#trainingName");
        protected virtual By AddButtonSelector => By.XPath("//button[text()='Add']");

        private static By EmploymentEndMonth => By.Id("EmploymentEndMonth");
        private static By EmploymentEndYear => By.Id("EmploymentEndYear");
        private static By EmploymentPrice => By.Id("EmploymentPrice");
        private static By EmployerReference => By.Id("Reference");
        private static By StartDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-StartDate']");
        private static By EndDateErrorMessagelLink => By.XPath("//*[@data-focuses='error-message-EndDate']");

        protected EditApprenticeDetailsBasePage(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public void VerifyCourseAndCostAreReadOnly()
        {
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(ReadOnlyTrainingCost),
                () => VerifyPage(ReadOnlyTrainingCourse)
            });
        }
        public void VerifyReadOnlyEmail() => VerifyElement(ReadOnyEmailField, GetApprenticeEmail());

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse();

            EditCost();
            
            EditApprenticeNameDobAndReference(reference);
        }

        public void VerifyOverlappingTrainingDetailsError(bool displayStartDateError, bool displayEndDateError)
        {
            var courseStartDate = GetCourseStartDate();

            ClickStartMonth();

            EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(AddButtonSelector);

            ValidateOltdErrorMessage(StartDateErrorMessagelLink, displayStartDateError);
            ValidateOltdErrorMessage(EndDateErrorMessagelLink, displayEndDateError);
        }

        protected DateTime GetCourseStartDate()
        {
            if (objectContext.HasStartDate()) apprenticeCourseDataHelper.CourseStartDate = objectContext.GetStartDate();

            if (objectContext.IsSameApprentice()) apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);

            return apprenticeCourseDataHelper.CourseStartDate;
        }
        protected void ClickStartMonth() => formCompletionHelper.ClickElement(StartDateMonth);

        protected void EnterStartDate(DateTime dateTime)
        {
            formCompletionHelper.EnterText(StartDateMonth, dateTime.Month);
            formCompletionHelper.EnterText(StartDateYear, dateTime.Year);
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
        protected void EnterTrainingCostAndEmpReference()
        {
            formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingCost);
            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);

            if (tags.Contains("portableflexijob"))
                formCompletionHelper.EnterText(EmploymentPrice, apprenticeDataHelper.TrainingCost.ToInt() - 50);
        }

        private void ValidateOltdErrorMessage(By locator, bool shouldBeDisplayed)
        {
            if (shouldBeDisplayed)
            {
                pageInteractionHelper.WaitForElementToBeDisplayed(locator);
                Assert.IsTrue(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message not displayed");

                string expectedMessage = "The date overlaps with existing dates for the same apprentice";
                string actualMessage = pageInteractionHelper.GetText(locator);
                StringAssert.StartsWith(expectedMessage, actualMessage, "Incorrect Date Overlaps Message displayed");
            }
            else
            {
                Assert.IsFalse(pageInteractionHelper.IsElementDisplayed(locator), "Date overlaps error message should not be displayed");
            }
        }

        protected abstract void EditCourse();

        protected void EditEmail()
        {
            AddValidEmail();
            Update();
        }

        protected void AddValidEmail() => formCompletionHelper.EnterText(EmailField, GetApprenticeEmail());

        private string GetApprenticeEmail() => apprenticeDataHelper.ApprenticeEmail;

        private void EditCost() => formCompletionHelper.EnterText(TrainingCost, "2" + editedApprenticeDataHelper.TrainingCost);
    }
}