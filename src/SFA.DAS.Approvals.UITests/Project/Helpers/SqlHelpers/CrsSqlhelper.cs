using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CrsSqlhelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CRSDbConnectionString)
    {
        private static string MultipleOptionPredicate => "Options NOT like '%core%' and Options like '%,%' and Options NOT like '%N/A%'";

        private static string NoOptionPredicate => "Options like '%core%'";

        public static string GetSqlQueryWithMultipleOptions(List<string> larsCode) => larsCode.IsNoDataFound() ? GetSqlQuery(MultipleOptionPredicate) : GetSqlQuery($" s.LarsCode in ({string.Join(',', larsCode)}) and {MultipleOptionPredicate}");

        public static string GetSqlQueryWithNoOptions(List<string> larsCode) => larsCode.IsNoDataFound() ? GetSqlQuery(NoOptionPredicate) : GetSqlQuery($" s.LarsCode in ({string.Join(',', larsCode)}) and {NoOptionPredicate}");

        public List<List<CourseDetails>> GetApprenticeCourse(List<string> sqlQuery)
        {
            var multiResultFromDb = new List<List<CourseDetails>>();

            var multiresult = GetListOfMultipleData(sqlQuery).ToList();

            foreach (var result in multiresult)
            {
                var availableCoursesFromDb = new List<CourseDetails>();

                foreach (var item in result)
                {
                    availableCoursesFromDb.Add(new CourseDetails { Course = (item[0], item[1], DateTime.Parse(item[2]), int.Parse(item[3]), int.Parse(item[4])) });
                }
                multiResultFromDb.Add(availableCoursesFromDb);
            }

            return multiResultFromDb;
        }

        private static string GetSqlQuery(string optionsPredicate)
        {
            static string VersionEarliestStartDatePredicate()
            {
                var a = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();

                return $"VersionEarliestStartDate < CONVERT(datetime, '{a.Year}-{a.Month}-{a.Day}')";
            }

            var query =  $"SELECT TOP 5 s.LarsCode, Title, VersionEarliestStartDate, ProposedTypicalDuration, ProposedMaxFunding from [Standard] s join LarsStandard ls on ls.LarsCode = s.LarsCode " +
                $"WHERE {optionsPredicate} and VersionLatestStartDate is null and VersionLatestEndDate is null and {VersionEarliestStartDatePredicate()} and ls.LastDateStarts is null ORDER BY NEWID();";

            return query;
        }
    }
}
