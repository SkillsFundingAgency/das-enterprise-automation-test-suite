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

        private By CourseOption(string courseid) => By.CssSelector($"#TrainingCode option[value='{courseid}']");

        public EditApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _coursedataHelper = context.Get<EditedApprenticeCourseDataHelper>();
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
            formCompletionHelper.ClickElement(CourseOption(_coursedataHelper.EditedCourse));
        }

        private ConfirmChangesPage ConfirmChangesPage()
        {
            return new ConfirmChangesPage(_context);
        }
    }
}