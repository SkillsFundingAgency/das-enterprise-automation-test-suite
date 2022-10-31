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

        private CourseDetails SelectACourse(string except)
        {
            var newlist = _availableCourses.Where(x => x.Course.larsCode != except).ToList();

            return RandomDataGenerator.GetRandomElementFromListOfElements(newlist);
        }

        private CourseDetails SoftwareTester => new CourseDetails
        {
            Course = ("91", "Software tester", new DateTime(2016, 04, 21), 24, 18000)
        };

        private CourseDetails SoftwareDeveloper => new CourseDetails
        {
            Course = ("2", "Software developer", new DateTime(2021, 06, 01), 24, 18000)
        };

        private CourseDetails AbattoirWorker => new CourseDetails
        {
            Course = ("274", "Abattoir worker", new DateTime(2018, 05, 08), 16, 6000)
        };
        private CourseDetails SoftwareDevelopmentTechnician => new CourseDetails
        {
            Course = ("154", "Software development technician", new DateTime(2022, 05, 16), 18, 15000)
        };
    }
}