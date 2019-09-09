using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticeDetailsPagePostApproval : BasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly EditedApprenticeDataHelper _dataHelper;
        #endregion

        private By FirstNameField => By.Id("FirstName");
        private By LastNameField => By.Id("LastName");
        private By DateOfBirthDay => By.Id("DateOfBirth_Day");
        private By DateOfBirthMonth => By.Id("DateOfBirth_Month");
        private By DateOfBirthYear => By.Id("DateOfBirth_Year");
        private By TrainingCourseContainer => By.Id("select2-TrainingCode-container");
        private By CourseOption(string courseid) => By.CssSelector($"#TrainingCode option[value='{courseid}']");
        private By StartDateMonth => By.Id("StartDate_Month");
        private By StartDateYear => By.Id("StartDate_Year");
        private By EndDateMonth => By.Id("EndDate_Month");
        private By EndDateYear => By.Id("EndDate_Year");
        private By TrainingCost => By.Id("Cost");
        private By EmployerReference => By.Id("EmployerRef");
        private By UpdateDetailsButton => By.Id("submit-edit-app");


        public EditApprenticeDetailsPagePostApproval(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<EditedApprenticeDataHelper>();
            VerifyPage();
        }

        public ConfirmChangesPage EditCostAndCourse()
        {
            EditCost();
            EditCourse();
            _formCompletionHelper.ClickElement(UpdateDetailsButton);
            return new ConfirmChangesPage(_context);
        }

        public ConfirmChangesPage EditNameDobAndReferenceAfterIlrMatch()
        {
            EditNameDobAndReference();
            _formCompletionHelper.ClickElement(UpdateDetailsButton);
            return new ConfirmChangesPage(_context);
        }

        private void EditNameDobAndReference()
        {
            _formCompletionHelper.EnterText(FirstNameField, _dataHelper.SetCurrentApprenticeEditedFirstname());
            _formCompletionHelper.EnterText(LastNameField, _dataHelper.SetCurrentApprenticeEditedLastname());
            _formCompletionHelper.EnterText(DateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(DateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(DateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(EmployerReference, _dataHelper.EmployerReference);
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