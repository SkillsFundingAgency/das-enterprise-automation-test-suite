using System;
using System.Collections.Generic;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CrsSqlhelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.CRSDbConnectionString)
    {
        private static readonly DateTime RecognisePriorLearningBecomesRequiredOn = new(2022, 08, 01, 0, 0, 0, DateTimeKind.Utc);

        private static string MultipleOptionPredicate => "Options NOT like '%core%' and Options like '%,%' and Options NOT like '%N/A%'";

        private static string NoOptionPredicate => "Options like '%core%'";

        private static string MultipleVersionsCTE => "WITH StandardsWithMultipleVersions as (SELECT LEFT(StandardUId, CHARINDEX('_', StandardUId) - 1) AS StandardBase FROM Standard GROUP BY LEFT(StandardUId, CHARINDEX('_', StandardUId) - 1)  HAVING COUNT(DISTINCT Version) > 1)  ";
        
        private static string MultipleVersionsPredicate => " AND [IfateReferenceNumber] in ( Select StandardBase from StandardsWithMultipleVersions) " +
            $"AND VersionEarliestStartDate > DATEADD(month, 2, CONVERT(datetime, '{RecognisePriorLearningBecomesRequiredOn.Year}-{RecognisePriorLearningBecomesRequiredOn.Month}-{RecognisePriorLearningBecomesRequiredOn.Day}'))  ";

        public static string GetSqlQueryWithMultipleOptions(List<string> larsCode) => larsCode.IsNoDataFound() ? GetSqlQuery(MultipleOptionPredicate) : GetSqlQuery($" s.LarsCode in ({string.Join(',', larsCode)}) and {MultipleOptionPredicate}");
        
        public static string GetSqlQueryWithMultipleOptionsAndVersions(List<string> larsCode) => larsCode.IsNoDataFound() ? GetSqlQuery(MultipleOptionPredicate) : GetSqlQuery($" s.LarsCode in ({string.Join(',', larsCode)}) and {MultipleOptionPredicate}", true);

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

        private static string GetSqlQuery(string optionsPredicate, bool withMultipleVersions = false)
        {
            static string VersionEarliestStartDatePredicate()
            {
                var a = AcademicYearDatesHelper.GetCurrentAcademicYearStartDate();

                return $"VersionEarliestStartDate < CONVERT(datetime, '{a.Year}-{a.Month}-{a.Day}')";
            }

            var multipleVersionsCTE = withMultipleVersions ? MultipleVersionsCTE : string.Empty;
            var multipleVersionsPredicate = withMultipleVersions ? MultipleVersionsPredicate : string.Empty;

            var query = $"{multipleVersionsCTE}" +
                 $"SELECT TOP 5 s.LarsCode, Title, VersionEarliestStartDate, ProposedTypicalDuration, ProposedMaxFunding " +
                 $"FROM [Standard] s " +
                 $"JOIN LarsStandard ls ON ls.LarsCode = s.LarsCode " +
                 $"WHERE {optionsPredicate} AND VersionLatestStartDate IS NULL AND VersionLatestEndDate IS NULL " +
                 $"AND {VersionEarliestStartDatePredicate()} AND ls.LastDateStarts IS NULL " +
                 $"{multipleVersionsPredicate}" +
                 $"ORDER BY NEWID();";

            return query;
        }
    }
}
