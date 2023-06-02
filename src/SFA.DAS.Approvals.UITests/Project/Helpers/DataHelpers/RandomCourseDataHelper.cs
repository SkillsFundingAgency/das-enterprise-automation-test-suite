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

        private readonly List<CourseDetails> _providerCourses;
        
        public RandomCourseDataHelper() 
        {
            _availableCourses = AvailableCourses.GetAvailableCourses();
            _providerCourses = AvailableCourses.GetAvailableCourses();
        }

        public RandomCourseDataHelper(CrsSqlhelper crsSqlhelper, RoatpV2SqlDataHelper roatpV2SqlDataHelper, string ukprn, string[] tags)
        {
            var multiqueryResult = crsSqlhelper.GetApprenticeCourse(new List<string>
            {
                tags.Contains("selectstandardwithmultipleoptions") ? crsSqlhelper.GetSqlQueryWithMultipleOptions() : crsSqlhelper.GetSqlQueryWithNoOptions(),
                crsSqlhelper.GetSqlQueryWithNoOptions(tags.Contains("limitingstandards") ? roatpV2SqlDataHelper.GetCourseProviderDeosNotOffer(ukprn) : roatpV2SqlDataHelper.GetPortableFlexiJobLarsCode(ukprn))
            });

            _availableCourses = multiqueryResult[0];

            _providerCourses = multiqueryResult[1];
        }

        public CourseDetails RandomProviderCourse() => SelectACourseExcept(_providerCourses, null);

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