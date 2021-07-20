using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeCommitmentsEditApprenticePage : EditApprenticePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeCommitmentsEditApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public ConfirmChangesPage EditCourseAndDate()
        {
            EditCourse();

            AddValidStartDate();

            AddValidEndDate();

            Update();

            return new ConfirmChangesPage(_context);
        }

        protected override void SelectCourse() => formCompletionHelper.SelectFromDropDownByText(CourseOption, editedApprenticeCourseDataHelper.EditedCourse);

    }
}