using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeCourseDataHelper _coursedataHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ApprenticeCourseDataHelper _EditedcoursedataHelper;
        #endregion
        public EditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _coursedataHelper = context.Get<EditedApprenticeCourseDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _EditedcoursedataHelper = context.Get<ApprenticeCourseDataHelper>();
        }

        private By CourseOption => By.CssSelector("#TrainingCode");
        private By EditDateOfBirthDay => By.Id("BirthDay");
        private By EditDateOfBirthMonth => By.Id("BirthMonth");
        private By EditDateOfBirthYear => By.Id("BirthYear");
        private By EditTrainingCost => By.Id("Cost");
        private By EditEmployerReference => By.Id("Reference");
        private By EditSaveAndContinueButton => By.CssSelector(".govuk-button");
        private By DeleteButton => By.LinkText("Delete");
        
        public ConfirmApprenticeDeletionPage SelectDeleteApprentice()
        {
           formCompletionHelper.ClickElement(DeleteButton);
            return new ConfirmApprenticeDeletionPage(_context);
        }

        public ConfirmChangesPage EditCostCourseAndReference()
        {
            EditCostCourseAndReference(dataHelper.EmployerReference);
            return ConfirmChangesPage();
        }
        public ConfirmChangesPage EditApprenticeNameDobAndReference()
        {
            EditApprenticeNameDobAndReference(dataHelper.EmployerReference);
            return ConfirmChangesPage();
        }
        protected override void SelectCourse()
        {
            formCompletionHelper.SelectFromDropDownByValue(CourseOption, _coursedataHelper.EditedCourse);
        }
        private ConfirmChangesPage ConfirmChangesPage()
        {
            return new ConfirmChangesPage(_context);
        }
        public AfterEditApproveApprenticeDetailsPage ContinueToAddValidApprenticeDetails()
        {
            _formCompletionHelper.EnterText(EditDateOfBirthDay, _dataHelper.DateOfBirthDay);
            _formCompletionHelper.EnterText(EditDateOfBirthMonth, _dataHelper.DateOfBirthMonth);
            _formCompletionHelper.EnterText(EditDateOfBirthYear, _dataHelper.DateOfBirthYear);
            _formCompletionHelper.EnterText(EndDateMonth, _EditedcoursedataHelper.CourseEndDate.Month);
            _formCompletionHelper.EnterText(EndDateYear, _EditedcoursedataHelper.CourseEndDate.Year);
            _formCompletionHelper.EnterText(EditTrainingCost, _dataHelper.TrainingPrice);
            _formCompletionHelper.EnterText(EditEmployerReference, _dataHelper.EmployerReference);
            _formCompletionHelper.ClickElement(EditSaveAndContinueButton);
            return new AfterEditApproveApprenticeDetailsPage(_context);
        }       
    }
}