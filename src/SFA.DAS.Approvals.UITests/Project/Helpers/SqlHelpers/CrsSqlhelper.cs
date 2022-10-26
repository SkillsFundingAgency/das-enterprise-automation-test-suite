using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CrsSqlhelper : SqlDbHelper
    {
        public CrsSqlhelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }

        public List<CourseDetails> GetApprenticeCourseWithMultipleOptions() => GetApprenticeCourse("Options NOT like '%core%' and Options like '%,%' and Options NOT like '%N/A%'");

        public List<CourseDetails> GetApprenticeCourseWithNoOptions() => GetApprenticeCourse("Options like '%core%'");

        public List<CourseDetails> GetApprenticeCourseWithNoOptions(List<string> larsCode) => larsCode.IsNoDataFound() ? GetApprenticeCourseWithNoOptions() : GetApprenticeCourse($" s.LarsCode in ({string.Join(',', larsCode)}) and Options like '%core%'");

        private List<CourseDetails> GetApprenticeCourse(string optionsPredicate)
        {
            var availableCoursesFromDb = new List<CourseDetails>();

            static string VersionEarliestStartDatePredicate()
            {
                var a = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();

                return $"VersionEarliestStartDate < CONVERT(datetime, '{a.Year}-{a.Month}-{a.Day}')";
            }

            var query = $"SELECT TOP 5 s.LarsCode, Title, VersionEarliestStartDate, ProposedTypicalDuration, ProposedMaxFunding from [Standard] s join LarsStandard ls on ls.LarsCode = s.LarsCode " +
                $"WHERE {optionsPredicate} and VersionLatestStartDate is null and VersionLatestEndDate is null and {VersionEarliestStartDatePredicate()} and ls.LastDateStarts is null ORDER BY NEWID();";

            var result = GetMultipleData(query);

            foreach (var item in result)
            {
                availableCoursesFromDb.Add(new CourseDetails { Course = (item[0], item[1], DateTime.Parse(item[2]), int.Parse(item[3]), int.Parse(item[4])) });
            }

            return availableCoursesFromDb;
        }
    }
}
