using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class EditApprentice : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        protected By FirstNameField => By.Id("FirstName");
        protected By LastNameField => By.Id("LastName");
        protected By DateOfBirthDay => By.Id("DateOfBirth_Day");
        protected By DateOfBirthMonth => By.Id("DateOfBirth_Month");
        protected By DateOfBirthYear => By.Id("DateOfBirth_Year");        
        protected By StartDateMonth => By.Id("StartDate_Month");
        protected By StartDateYear => By.Id("StartDate_Year");
        protected By EndDateMonth => By.Id("EndDate_Month");
        protected By EndDateYear => By.Id("EndDate_Year");
        protected By TrainingCost => By.Id("Cost");

        protected abstract By TrainingCourseContainer { get; }

        protected abstract By Reference { get; }

        protected abstract By UpdateDetailsButton { get; }

        public EditApprentice(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }

        protected abstract void SelectCourse();

        public void EditCostCourseAndReference(string reference)
        {
            EditCourse()
            .EditCost()
            .EditApprenticeNameDobAndReference(reference);
        }

        public void EditApprenticeNameDobAndReference(string reference)
        {
            EditNameDobAndReference(reference)
            .Update();
        }

        private EditApprentice EditNameDobAndReference(string reference)
        {
            formCompletionHelper.EnterText(FirstNameField, _dataHelper.SetCurrentApprenticeEditedFirstname());
            formCompletionHelper.EnterText(LastNameField, _dataHelper.SetCurrentApprenticeEditedLastname());
            formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            formCompletionHelper.EnterText(Reference, reference);
            return this;
        }

        private EditApprentice EditCost()
        {
            formCompletionHelper.EnterText(TrainingCost, "2" + _dataHelper.TrainingPrice);
            return this;
        }

        private EditApprentice EditCourse()
        {
            formCompletionHelper.ClickElement(TrainingCourseContainer);
            SelectCourse();
            formCompletionHelper.ClickElement(StartDateMonth);
            return this;
        }

        private void Update()
        {
            formCompletionHelper.ClickElement(UpdateDetailsButton, true);
        }
    }
}