using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CrsSqlhelper : SqlDbHelper
    {
        public CrsSqlhelper(string crsDbConnectionString) : base(crsDbConnectionString) { }

        public List<CourseDetails> GetApprenticeCourseWithMultipleOptions() => GetApprenticeCourse("Options <> '[]' and Options like '%,%' and Options not like '%N/A%'");

        public List<CourseDetails> GetApprenticeCourseWithNoOptions() => GetApprenticeCourse("Options = '[]'");

        private List<CourseDetails> GetApprenticeCourse(string optionsPredicate)
        {
            var availableCoursesFromDb = new List<CourseDetails>();

            static string VersionEarliestStartDatePredicate()
            {
                var a = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();

                return $"VersionEarliestStartDate < CONVERT(datetime, '{a.Year}-{a.Month}-{a.Day}')";
            }

            var query = $"select top 5 LarsCode, Title, VersionEarliestStartDate, ProposedTypicalDuration, ProposedMaxFunding from [Standard] where {optionsPredicate} and VersionLatestStartDate is null and VersionLatestEndDate is null and {VersionEarliestStartDatePredicate()} order by NEWID();";

            var result = GetMultipleData(query);

            foreach (var item in result)
            {
                availableCoursesFromDb.Add(new CourseDetails {Course = (item[0], item[1], DateTime.Parse(item[2]), int.Parse(item[3]), int.Parse(item[4])) });
            }

            return availableCoursesFromDb;
        }
    }
}
