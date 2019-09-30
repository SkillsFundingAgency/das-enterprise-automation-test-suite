using System;
using System.Linq;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class EditedApprenticeCourseDataHelper
    {
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;

        public EditedApprenticeCourseDataHelper(RandomCourseHelper randomCourseHelper, ApprenticeCourseDataHelper apprenticeCourseDataHelper)
        {
            _apprenticeCourseDataHelper = apprenticeCourseDataHelper;
            EditedCourse = randomCourseHelper.AvailableCourses.Where(x => x != _apprenticeCourseDataHelper.Course).FirstOrDefault();
        }

        public string EditedCourse { get; private set; }
    }
}
