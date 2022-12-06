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

        public RandomCourseDataHelper() => _availableCourses = new List<CourseDetails> { SoftwareTester, SoftwareDeveloper, AbattoirWorker, SoftwareDevelopmentTechnician };

        private readonly List<CourseDetails> _portableFlexiJobAvailableCourses;

        public RandomCourseDataHelper((List<CourseDetails>, List<CourseDetails>) courses)
        {
            _availableCourses = courses.Item1;
            _portableFlexiJobAvailableCourses = courses.Item2;
        }

        public RandomCourseDataHelper() : this((AvailableCourses.GetAvailableCourses(), AvailableCourses.GetAvailableCourses())) { }

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

        internal (List<CourseDetails>, List<CourseDetails>) GetRandomCourses() => (_availableCourses, _portableFlexiJobAvailableCourses);

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