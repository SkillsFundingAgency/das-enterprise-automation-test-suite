using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class RandomCourseDataHelper(List<CourseDetails> availableCourses)
    {
        public readonly List<CourseDetails> AvailableCourses = availableCourses;

        public RandomCourseDataHelper() : this(DataHelpers.AvailableCourses.GetAvailableCourses()) { }

        public RandomCourseDataHelper(ObjectContext objectContext, DbConfig dbConfig, List<string> larsCode, string[] tags) : this(GetAvailableCourses(objectContext, dbConfig, larsCode, tags))
        {

        }

        public CourseDetails RandomCourse() => SelectACourseExcept(AvailableCourses, null);

        public CourseDetails RandomCourse(string selectedCourse) => SelectACourseExcept(AvailableCourses, selectedCourse);

        public CourseDetails SelectASpecificCourse(string courseToSelect) => SelectSpecificCourse(AvailableCourses, courseToSelect);

        private static CourseDetails SelectACourseExcept(List<CourseDetails> courses, string except) => Func(courses, except, (x, y) => x != y);

        private static CourseDetails SelectSpecificCourse(List<CourseDetails> courses, string larsCode) => Func(courses, larsCode, (x, y) => x == y);

        private static CourseDetails Func(List<CourseDetails> courses, string larsCode, Func<string, string, bool> func)
        {
            var newlist = courses.Where(x => func(x.Course.larsCode, larsCode)).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }

        public static List<CourseDetails> GetAvailableCourses(ObjectContext objectContext, DbConfig dbConfig, List<string> larsCode, string[] tags)
        {
            string query =
                tags.IsSelectStandardWithMultipleOptionsAndVersions() ?
                CrsSqlhelper.GetSqlQueryWithMultipleOptionsAndVersions(larsCode) :

                tags.IsSelectStandardWithMultipleOptions() ?
                CrsSqlhelper.GetSqlQueryWithMultipleOptions(larsCode) :

                CrsSqlhelper.GetSqlQueryWithNoOptions(larsCode);

            var multiqueryResult = new CrsSqlhelper(objectContext, dbConfig).GetApprenticeCourse([query]);

            return multiqueryResult[0];
        }
    }
}