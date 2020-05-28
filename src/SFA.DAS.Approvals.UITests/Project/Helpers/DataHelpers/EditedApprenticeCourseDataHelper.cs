using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class EditedApprenticeCourseDataHelper
    {
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;

        public EditedApprenticeCourseDataHelper(RandomCourseDataHelper randomCourseHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)
        {
            _apprenticeCourseDataHelper = apprenticeCourseDataHelper;
            EditedCourse = randomCourseHelper.AvailableCourses.Where(x => x != _apprenticeCourseDataHelper.Course).FirstOrDefault();
        }

        public string EditedCourse { get; private set; }
    }
}
