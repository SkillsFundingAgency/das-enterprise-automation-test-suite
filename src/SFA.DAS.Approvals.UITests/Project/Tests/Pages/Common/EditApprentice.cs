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
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        protected By FirstNameField => By.Id("FirstName");
        protected By LastNameField => By.Id("LastName");
        protected By DateOfBirthDay => By.Id("DateOfBirth_Day");
        protected By DateOfBirthMonth => By.Id("DateOfBirth_Month");
        protected By DateOfBirthYear => By.Id("DateOfBirth_Year");
        protected By TrainingCourseContainer => By.Id("select2-container");
        protected By CourseOption(string courseid) => By.CssSelector($"#TrainingCode option[value='{courseid}']");
        protected By StartDateMonth => By.Id("StartDate_Month");
        protected By StartDateYear => By.Id("StartDate_Year");
        protected By EndDateMonth => By.Id("EndDate_Month");
        protected By EndDateYear => By.Id("EndDate_Year");
        protected By TrainingCost => By.Id("Cost");

        protected abstract By Reference { get; }

        protected abstract By UpdateDetailsButton { get; }

        public EditApprentice(ScenarioContext context) : base(context)
        {
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }

        public void EditCostAndCourse()
        {
            EditCost();
            EditCourse();
            _formCompletionHelper.ClickElement(UpdateDetailsButton);
        }

        public void EditApprenticeNameDobAndReference(string reference)
        {
            EditNameDobAndReference(reference);
            _formCompletionHelper.ClickElement(UpdateDetailsButton);
        }

        private void EditNameDobAndReference(string reference)
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.SetCurrentApprenticeEditedFirstname());
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.SetCurrentApprenticeEditedLastname());
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(Reference, reference);
        }

        private void EditCost()
        {
            _formCompletionHelper.EnterText(TrainingCost, "2" + _dataHelper.TrainingPrice);

        }

        private void EditCourse()
        {
            _formCompletionHelper.ClickElement(TrainingCourseContainer);
            _formCompletionHelper.ClickElement(CourseOption(_dataHelper.SetCurrentApprenticeEditedCourse()));
        }
    }
}