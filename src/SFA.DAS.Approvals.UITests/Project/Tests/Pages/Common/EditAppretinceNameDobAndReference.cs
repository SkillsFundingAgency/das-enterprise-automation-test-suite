using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditAppretinceNameDobAndReference : ApprovalsBasePage
    {
        #region Helpers and Context
        #endregion

        protected virtual By FirstNameField => By.CssSelector("#FirstName, #firstName");
        protected virtual By LastNameField => By.CssSelector("#LastName, #lastName");
        protected virtual By DateOfBirthDay => By.CssSelector("#BirthDay, #DateOfBirth_Day, #dob-day");
        protected virtual By DateOfBirthMonth => By.CssSelector("#BirthMonth, #DateOfBirth_Month, #dob-month");
        protected virtual By DateOfBirthYear => By.CssSelector("#BirthYear, #DateOfBirth_Year, #dob-year");
        protected virtual By StartDateMonth => By.CssSelector("#StartMonth, #StartDate-Month, #startDate-month");
        protected virtual By StartDateYear => By.CssSelector("#StartYear, #StartDate-Year, #startDate-year");
        protected virtual By EndDateMonth => By.CssSelector("#EndMonth, #EndDate_Month, #endDate-month");
        protected virtual By EndDateYear => By.CssSelector("#EndYear, #EndDate_Year, #endDate-year");
        protected virtual By Reference => By.CssSelector("#EmployerRef, #Reference, #ProviderRef, #with-hint");
        protected virtual By UpdateDetailsButton => By.CssSelector("#submit-edit-app, #submit-edit-details, #continue-button");

        protected EditAppretinceNameDobAndReference(ScenarioContext context, bool verifypage = true) : base(context, verifypage) { }

        public void EditApprenticeNameDobAndReference(string reference)
        {
            EditNameDobAndReference(reference)
            .Update();
        }

        private EditAppretinceNameDobAndReference EditNameDobAndReference(string reference)
        {
            formCompletionHelper.EnterText(FirstNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, editedApprenticeDataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, editedApprenticeDataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, editedApprenticeDataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, editedApprenticeDataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Reference, reference);
            return this;
        }

        private void Update() => formCompletionHelper.ClickElement(UpdateDetailsButton);
    }
}