using System;
using System.Linq;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class EditedApprenticeCourseDataHelper : RandomCourseHelper
    {
        private readonly ApprenticeCourseDataHelper _apprenticeCourseDataHelper;

        public EditedApprenticeCourseDataHelper(RandomDataGenerator randomDataGenerator, ApprenticeCourseDataHelper apprenticeCourseDataHelper) : base(randomDataGenerator)
        {
            _apprenticeCourseDataHelper = apprenticeCourseDataHelper;
            EditedCourse = AvailableCourses().Where(x => x != _apprenticeCourseDataHelper.Course).FirstOrDefault();
        }

        public string EditedCourse { get; private set; }
    }
}
