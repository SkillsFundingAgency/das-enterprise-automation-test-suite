using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CrsSqlhelper : SqlDbHelper
    {
        public CrsSqlhelper(DbConfig dbConfig) : base(dbConfig.CRSDbConnectionString) { }

        public (int larsCode, string title, DateTime versionEarliestStartDate, int proposedTypicalDuration, int proposedMaxFunding) GetApprenticeCourseWithMultipleOptions() => GetApprenticeCourse("Options <> '[]' and Options like '%,%' and Options not like '%N/A%'");

        public (int larsCode, string title, DateTime versionEarliestStartDate, int proposedTypicalDuration, int proposedMaxFunding) GetApprenticeCourseWithNoOptions() => GetApprenticeCourse("Options = '[]'");

        private (int larsCode, string title, DateTime versionEarliestStartDate, int proposedTypicalDuration, int proposedMaxFunding) GetApprenticeCourse(string optionsPredicate)
        {
            var query = $"select top 1 LarsCode, Title, VersionEarliestStartDate, ProposedTypicalDuration, ProposedMaxFunding from [Standard] where {optionsPredicate} and VersionLatestStartDate is null and VersionLatestEndDate is null and VersionEarliestStartDate < GETDATE() order by NEWID();";

            var apprenticeData = GetData(query);

            return (int.Parse(apprenticeData[0]), apprenticeData[1], DateTime.Parse(apprenticeData[2]), int.Parse(apprenticeData[3]), int.Parse(apprenticeData[4]));
        }
    }
}
