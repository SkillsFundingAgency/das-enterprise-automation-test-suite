using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class EditApprenticePage : EditApprentice
    {
        protected override string PageTitle => "Edit apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly EditedApprenticeCourseDataHelper _coursedataHelper;
        #endregion

        private By CourseOption => By.CssSelector("#TrainingCode");

        private By DeleteButton => By.LinkText("Delete");

        public EditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _coursedataHelper = context.Get<EditedApprenticeCourseDataHelper>();
        }

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
    }
}