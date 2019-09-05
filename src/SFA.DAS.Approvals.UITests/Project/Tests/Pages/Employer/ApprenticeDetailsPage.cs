using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ApprenticeDetailsPage : BasePage
    {
        protected override string PageTitle => _dataHelper.ApprenticeFullName;

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ApprovalsDataHelper _dataHelper;
        private readonly TableRowHelper _tableRowHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By ViewChangesLink => By.LinkText("View changes");
        private By ReviewChangesLink => By.LinkText("Review changes");
        private By EditApprenticeStatusLink => By.LinkText("Edit status");
        private By EditStopDateLink => By.Id("editStopDateLink");
        private By EditApprenticeDetailsLink => By.LinkText("Edit");

        public ApprenticeDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }
        
        internal EditApprenticeDetailsPagePostApproval ClickEditApprenticeDetailsLink()
        {
            _formCompletionHelper.ClickElement(EditApprenticeDetailsLink);
            return new EditApprenticeDetailsPagePostApproval(_context);
        }
    }

    public class EditApprenticeDetailsPagePostApproval : BasePage
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly CocDataHelper _dataHelper;
        #endregion

        private By firstNameField => By.Id("FirstName");
        private By lastNameField => By.Id("LastName");
        private By dateOfBirthDay => By.Id("DateOfBirth_Day");
        private By dateOfBirthMonth => By.Id("DateOfBirth_Month");
        private By dateOfBirthYear => By.Id("DateOfBirth_Year");
        private By trainingCourseContainer => By.Id("select2-TrainingCode-container");
        private By standardCourseOption => By.CssSelector("#TrainingCode option[value='176']");
        private By frameworkCourseOption => By.CssSelector("#TrainingCode option[value='454-2-1']");
        private By startDateMonth => By.Id("StartDate_Month");
        private By startDateYear => By.Id("StartDate_Year");
        private By endDateMonth => By.Id("EndDate_Month");
        private By endDateYear => By.Id("EndDate_Year");
        private By trainingCost => By.Id("Cost");
        private By employerReference => By.Id("EmployerRef");
        private By updateDetailsButton => By.Id("submit-edit-app");


        public EditApprenticeDetailsPagePostApproval(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<CocDataHelper>();
            VerifyPage();
        }

        public ConfirmChangesPage EditTheApprenticePostApprovalAfterIlrMatchAndSubmit()
        {
            EditNameDobAndReference();
            _formCompletionHelper.ClickElement(updateDetailsButton);
            return new ConfirmChangesPage(_context);
        }

        private void EditNameDobAndReference()
        {
            _formCompletionHelper.EnterText(firstNameField, _dataHelper.SetCurrentApprenticeEditedFirstname());
            _formCompletionHelper.EnterText(lastNameField, _dataHelper.SetCurrentApprenticeEditedLastname());
            _formCompletionHelper.EnterText(dateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(dateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(dateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(employerReference, _dataHelper.EmployerReference);
        }
    }

    public class ConfirmChangesPage : BasePage
    {
        protected override string PageTitle => "Confirm changes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        private By AcceptChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.CssSelector(".button");

        public ConfirmChangesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        public ApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(AcceptChangesOptions, "changes-confirmed-true");
            _formCompletionHelper.ClickElement(FinishButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}