using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class RandomCourseDataHelper
    {
        private readonly List<CourseDetails> _availableCourses;

        public RandomCourseDataHelper() => _availableCourses = AvailableCourses.GetAvailableCourses();

        public RandomCourseDataHelper(ObjectContext objectContext, DbConfig dbConfig, List<string> larsCode, string[] tags)
        {
            var crsSqlhelper = new CrsSqlhelper(objectContext, dbConfig);
            string query;

            if (tags.IsSelectStandardWithMultipleOptionsAndVersions())
            {
                query = CrsSqlhelper.GetSqlQueryWithMultipleOptionsAndVersions(larsCode);
            }
            else if (tags.IsSelectStandardWithMultipleOptions())
            {
                query = CrsSqlhelper.GetSqlQueryWithMultipleOptions(larsCode);
            }
            else
            {
                query = CrsSqlhelper.GetSqlQueryWithNoOptions(larsCode);
            }
            var multiqueryResult = crsSqlhelper.GetApprenticeCourse([query]);

            _availableCourses = multiqueryResult[0];
        }

        public CourseDetails RandomCourse() => SelectACourseExcept(_availableCourses, null);

        public CourseDetails RandomCourse(string selectedCourse) => SelectACourseExcept(_availableCourses, selectedCourse);

        public CourseDetails SelectASpecificCourse(string courseToSelect) => SelectSpecificCourse(_availableCourses, courseToSelect);

        private static CourseDetails SelectACourseExcept(List<CourseDetails> courses, string except) => Func(courses, except, (x, y) => x != y);

        private static CourseDetails SelectSpecificCourse(List<CourseDetails> courses, string larsCode) => Func(courses, larsCode, (x, y) => x == y);

        private static CourseDetails Func(List<CourseDetails> courses, string larsCode, Func<string, string, bool> func)
        {
            var newlist = courses.Where(x => func(x.Course.larsCode, larsCode)).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }
    }
}