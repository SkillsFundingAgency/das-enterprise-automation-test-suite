using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditAppretinceNameDobAndReference : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly EditedApprenticeDataHelper dataHelper;
        #endregion

        protected virtual By FirstNameField => By.Id("FirstName");
        protected virtual By LastNameField => By.Id("LastName");
        protected virtual By DateOfBirthDay => By.CssSelector("#BirthDay, #DateOfBirth_Day");
        protected virtual By DateOfBirthMonth => By.CssSelector("#BirthMonth, #DateOfBirth_Month");
        protected virtual By DateOfBirthYear => By.CssSelector("#BirthYear, #DateOfBirth_Year");
        protected virtual By StartDateMonth => By.CssSelector("#StartMonth, #StartDate_Month");
        protected virtual By StartDateYear => By.CssSelector("#StartYear, #StartDate_Year");
        protected virtual By EndDateMonth => By.CssSelector("#EndMonth, #EndDate_Month");
        protected virtual By EndDateYear => By.CssSelector("#EndYear, #EndDate_Year");
        protected virtual By Reference => By.CssSelector("#EmployerRef, #Reference, #ProviderRef");
        protected virtual By UpdateDetailsButton => By.CssSelector("#submit-edit-app, #submit-edit-details");

        public EditAppretinceNameDobAndReference(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }

        public void EditApprenticeNameDobAndReference(string reference)
        {
            EditNameDobAndReference(reference)
            .Update();
        }

        private EditAppretinceNameDobAndReference EditNameDobAndReference(string reference)
        {
            formCompletionHelper.EnterText(FirstNameField, dataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, dataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, dataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, dataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, dataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Reference, reference);
            return this;
        }

        private void Update()
        {
            formCompletionHelper.ClickElement(UpdateDetailsButton);
        }
    }
}