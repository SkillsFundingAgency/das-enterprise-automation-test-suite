using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class AddAndEditApprenticeDetailsBasePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        private static By Uln => By.Name("Uln");
        private static By FirstNameField => By.Name("FirstName");
        private static By LastNameField => By.Name("LastName");
        private static By EmailField => By.Name("Email");
        private static By DateOfBirthDay => By.Name("BirthDay");
        private static By DateOfBirthMonth => By.Name("BirthMonth");
        private static By DateOfBirthYear => By.Name("BirthYear");
        private static By ActualStartDateDay => By.Id("ActualStartDay");
        public static By ActualStartDateMonth => By.Id("ActualStartMonth");
        public static By ActualStartDateYear => By.Id("ActualStartYear");
        protected virtual By EndDateDay => By.Name("EndDay");
        public static By StartDateMonth => By.Name("StartMonth");
        public static By StartDateYear => By.Name("StartYear");
        public static By EndDateMonth => By.Name("EndMonth");
        public static By EndDateYear => By.Name("EndYear");
        private static By EmploymentEndMonth => By.Id("EmploymentEndMonth");
        private static By EmploymentEndYear => By.Id("EmploymentEndYear");
        private static By TrainingPrice => By.Id("TrainingPrice");
        private static By EndPointAssessmentPrice => By.Id("EndPointAssessmentPrice");
        private static By TrainingCost => By.Name("Cost");
        private static By EmploymentPrice => By.Id("EmploymentPrice");
        private static By EmployerReference => By.Id("Reference");
        private static By StartDateErrorMessagelLink => By.XPath("//*[contains(@data-focuses, 'error-message-StartDate')]");
        private static By EndDateErrorMessagelLink => By.XPath("//*[contains(@data-focuses, 'error-message-EndDate')]");
        protected virtual By SaveButtonSelector => GetFormSubmitButton();
        protected virtual By UpdateDetailsButton => By.CssSelector("#submit-edit-app, #submit-edit-details, #continue-button");
        protected virtual By Reference => By.CssSelector("#EmployerRef, #Reference, #ProviderRef, #with-hint");
        private static By ReadOnyEmailField => By.CssSelector(".das-definition-list > dd#email,dd#Email");
        private static By ReadOnlyTrainingCost => By.CssSelector(".das-definition-list > dd#cost");
        private static By ReadOnlyTrainingCourse => By.CssSelector(".das-definition-list > dd#trainingName");

        public void VerifyCourseAndCostAreReadOnly()
        {
            MultipleVerifyPage(
            [
                () => VerifyPage(ReadOnlyTrainingCost),
                () => VerifyPage(ReadOnlyTrainingCourse)
            ]);
        }

        protected void EnterTrainingCostAndEmpReference(bool isFlexiPaymentPilotLearner = false)
        {
            if (!isFlexiPaymentPilotLearner) formCompletionHelper.EnterText(TrainingCost, apprenticeDataHelper.TrainingCost);
            else
            {
                formCompletionHelper.EnterText(TrainingPrice, apprenticeDataHelper.TrainingPrice);
                formCompletionHelper.EnterText(EndPointAssessmentPrice, apprenticeDataHelper.EndpointAssessmentPrice);
            }

            formCompletionHelper.EnterText(EmployerReference, apprenticeDataHelper.EmployerReference);

            if (tags.IsPortableFlexiJob())
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

            if (tags.IsPortableFlexiJob())
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

        protected void EnterApprenticeEmail() => EnterApprenticeEmail(apprenticeDataHelper.ApprenticeEmail);

        protected void EnterApprenticeEmail(string email) => formCompletionHelper.EnterText(EmailField, email);

        protected void EnterApprenticeMandatoryValidDetails()
        {
            EnterApprenticeName();

            if (tags.IsAsListedEmployer()) return;

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
            if (pageInteractionHelper.IsElementDisplayed(Uln))
                formCompletionHelper.EnterText(Uln, objectContext.GetUlnForOLTD());

            EnterApprenticeName();

            var courseStartDate = GetCourseStartDate();

            ClickStartMonth();

            EnterStartDate(courseStartDate);

            EnterEndDate(objectContext.HasEndDate() ? objectContext.GetEndDate() : apprenticeCourseDataHelper.CourseEndDate);

            EnterTrainingCostAndEmpReference();

            formCompletionHelper.ClickElement(SaveButtonSelector);

            ValidateOltdErrorMessage(StartDateErrorMessagelLink, displayStartDateError);
            ValidateOltdErrorMessage(EndDateErrorMessagelLink, displayEndDateError);
        }

        public void VerifyReadOnlyEmail() => VerifyElement(ReadOnyEmailField, GetApprenticeEmail());

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse();
            EditCost();
            EditApprenticeNameDobAndReference(reference);
        }

        protected DateTime GetCourseStartDate()
        {
            if (objectContext.HasStartDate()) apprenticeCourseDataHelper.CourseStartDate = objectContext.GetStartDate();

            if (objectContext.IsSameApprentice()) apprenticeCourseDataHelper.CourseStartDate = apprenticeCourseDataHelper.GenerateCourseStartDate(Helpers.DataHelpers.ApprenticeStatus.WaitingToStart);

            return apprenticeCourseDataHelper.CourseStartDate;
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
        protected void EditEmail()
        {
            AddValidEmail();
            Update();
        }
        protected void AddValidEmail() => formCompletionHelper.EnterText(EmailField, GetApprenticeEmail());
        private string GetApprenticeEmail() => apprenticeDataHelper.ApprenticeEmail;
        protected void Update() => formCompletionHelper.ClickElement(UpdateDetailsButton);
        public void EditApprenticeNameDobAndReference(string reference) => EditNameDobAndReference(reference).Update();
        private AddAndEditApprenticeDetailsBasePage EditNameDobAndReference(string reference)
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Reference, reference);
            return this;
        }

        private void EditCourse() => ClickEditCourseLink().EmployerSelectsAnotherCourse();

        private void EditCost() => formCompletionHelper.EnterText(TrainingCost, "2" + editedApprenticeDataHelper.TrainingCost);

        private By GetFormSubmitButton()
        {
            return pageInteractionHelper.GetUrl().Contains("eas")
                ? By.XPath("//button[text()='Save']")
                : By.XPath("//button[text()='Add']");
        }

    }
}