using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class RandomCourseDataHelper
    {
        private readonly List<CourseDetails> _availableCourses;

        public RandomCourseDataHelper() => _availableCourses = new List<CourseDetails> { AbleSeafarerStandardCourseOption, SoftwareTesterStandardCourseOption };

        public RandomCourseDataHelper(CrsSqlhelper crsSqlhelper, string[] tags) => _availableCourses = tags.Contains("selectstandardwithmultipleoptions") ? crsSqlhelper.GetApprenticeCourseWithMultipleOptions() : crsSqlhelper.GetApprenticeCourseWithNoOptions();

        public CourseDetails RandomCourse() => SelectACourse(null);

        public CourseDetails RandomCourse(string selectedCourse) => SelectACourse(selectedCourse);

        private CourseDetails SelectACourse(string except)
        {
            var newlist = _availableCourses.Where(x => x.Course.larsCode != except).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }

        private CourseDetails AbleSeafarerStandardCourseOption => new CourseDetails 
        {
            Course = ("34", "Able seafarer (deck)", new DateTime(2015, 08, 27), 18, 9000) 
        };

        private CourseDetails SoftwareTesterStandardCourseOption => new CourseDetails
        {
            Course = ("91", "Software tester", new DateTime(2016, 04, 21), 24, 18000)
        };
    }
}