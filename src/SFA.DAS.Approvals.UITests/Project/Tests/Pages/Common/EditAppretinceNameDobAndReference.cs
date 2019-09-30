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
        protected virtual By DateOfBirthDay => By.Id("DateOfBirth_Day");
        protected virtual By DateOfBirthMonth => By.Id("DateOfBirth_Month");
        protected virtual By DateOfBirthYear => By.Id("DateOfBirth_Year");
        protected virtual By StartDateMonth => By.Id("StartDate_Month");
        protected virtual By StartDateYear => By.Id("StartDate_Year");
        protected virtual By EndDateMonth => By.Id("EndDate_Month");
        protected virtual By EndDateYear => By.Id("EndDate_Year");

        protected abstract By Reference { get; }

        protected abstract By UpdateDetailsButton { get; }

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
            formCompletionHelper.ClickElement(UpdateDetailsButton, true);
        }
    }
}