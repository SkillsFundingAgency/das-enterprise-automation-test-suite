using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class PublicSectorReportingSqlDataHelper : SqlDbHelper
    {
        public PublicSectorReportingSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig?.PublicSectorReportingConnectionString) { }

        public void RemovePublicSectorReporting(string accountid) => ExecuteSqlCommand($"DELETE FROM Report WHERE EmployerId = '{accountid}'");
    }
}
