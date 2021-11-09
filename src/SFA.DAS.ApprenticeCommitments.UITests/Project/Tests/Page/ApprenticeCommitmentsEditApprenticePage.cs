using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ApprenticeCommitmentsEditApprenticePage : EditApprenticePage
    {

        public ApprenticeCommitmentsEditApprenticePage(ScenarioContext context) : base(context) { }

        protected override void SelectCourse() => formCompletionHelper.SelectFromDropDownByText(CourseOption, editedApprenticeCourseDataHelper.EditedCourse);
    }
}