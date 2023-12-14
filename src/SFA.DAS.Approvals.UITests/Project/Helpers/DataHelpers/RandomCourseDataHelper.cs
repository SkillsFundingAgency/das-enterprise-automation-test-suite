using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public class RandomCourseDataHelper
    {
        private readonly List<CourseDetails> _availableCourses;
        
        public RandomCourseDataHelper() => _availableCourses = AvailableCourses.GetAvailableCourses();

        public RandomCourseDataHelper(ObjectContext objectContext, DbConfig dbConfig, List<string> larsCode, bool isMultipleOptionStandard)
        {
            var crsSqlhelper = new CrsSqlhelper(objectContext, dbConfig);

            var multiqueryResult = crsSqlhelper.GetApprenticeCourse(new List<string>
            {
                isMultipleOptionStandard ? CrsSqlhelper.GetSqlQueryWithMultipleOptions(larsCode) : CrsSqlhelper.GetSqlQueryWithNoOptions(larsCode)
            });

            _availableCourses = multiqueryResult[0];
        }


        public CourseDetails RandomCourse() => SelectACourseExcept(_availableCourses, null);

        public CourseDetails RandomCourse(string selectedCourse) => SelectACourseExcept(_availableCourses, selectedCourse);

        public CourseDetails SelectASpecificCourse(string courseToSelect) => SelectSpecificCourse(_availableCourses, courseToSelect);

        private static CourseDetails SelectACourseExcept(List<CourseDetails> courses, string except) => Func(courses, except, (x, y) => x != y);

        private static CourseDetails SelectSpecificCourse(List<CourseDetails> courses, string larsCode) => Func(courses, larsCode, (x, y) => x == y);

        private static CourseDetails Func(List<CourseDetails> courses, string larsCode, Func<string ,string, bool> func)
        {
            var newlist = courses.Where(x => func(x.Course.larsCode, larsCode)).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }
    }
}