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

        private readonly List<CourseDetails> _portableFlexiJobAvailableCourses;

        public RandomCourseDataHelper(List<CourseDetails> availableCourses, List<CourseDetails> portableFlexiJobAvailableCourses)
        {
            _availableCourses = availableCourses;
            _portableFlexiJobAvailableCourses = portableFlexiJobAvailableCourses;
        }

        public RandomCourseDataHelper(CrsSqlhelper crsSqlhelper, RoatpV2SqlDataHelper roatpV2SqlDataHelper, string[] tags)
        {
            var multiqueryResult = crsSqlhelper.GetApprenticeCourse(new List<string>
            {
                tags.Contains("selectstandardwithmultipleoptions") ? crsSqlhelper.GetSqlQueryWithMultipleOptions() : crsSqlhelper.GetSqlQueryWithNoOptions(),

                crsSqlhelper.GetSqlQueryWithNoOptions(roatpV2SqlDataHelper.GetPortableFlexiJobLarsCode())
            });

            _availableCourses = multiqueryResult[0];

            _portableFlexiJobAvailableCourses = multiqueryResult[1];
        }

        public CourseDetails GetPortableFlexiJobCourseDetails() => RandomDataGenerator.GetRandomElementFromListOfElements(_portableFlexiJobAvailableCourses);

        public CourseDetails RandomCourse() => SelectACourse(null);

        public CourseDetails RandomCourse(string selectedCourse) => SelectACourse(selectedCourse);

        public CourseDetails SelectASpecificCourse(string CoourseToSelect) => SelectSpecificCourse(CoourseToSelect);

        private CourseDetails SelectACourse(string except)
        {
            var newlist = _availableCourses.Where(x => x.Course.larsCode != except).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }

        private CourseDetails SelectSpecificCourse(string larsCode)
        {
            var newlist = _availableCourses.Where(x => x.Course.larsCode == larsCode).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }
    }
}