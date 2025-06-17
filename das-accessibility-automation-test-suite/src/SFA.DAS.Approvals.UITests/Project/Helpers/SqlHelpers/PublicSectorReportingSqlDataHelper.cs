using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class PublicSectorReportingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig?.PublicSectorReportingConnectionString)
    {
        public void RemovePublicSectorReporting(string accountid) => ExecuteSqlCommand($"DELETE FROM Report WHERE EmployerId = '{accountid}'");
    }
}
