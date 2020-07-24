using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class ApprenticeCourseDataHelper : ApprenticeCourseStartDateDataHelper
    {
        public ApprenticeCourseDataHelper(RandomDataGenerator randomDataGenerator, RandomCourseDataHelper randomCourseHelper, ApprenticeStatus apprenticeStatus) : base(randomDataGenerator, apprenticeStatus) => Course = randomCourseHelper.RandomCourse();

        public string Course { get; private set; }

        public int CourseDurationInMonths => 15;

        public DateTime CourseEndDate => CourseStartDate.AddMonths(CourseDurationInMonths);
    }
}
