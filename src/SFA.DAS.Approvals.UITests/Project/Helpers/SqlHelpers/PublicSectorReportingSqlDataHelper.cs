using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class PublicSectorReportingSqlDataHelper : SqlDbHelper
    {
        public PublicSectorReportingSqlDataHelper(DbConfig dbConfig) : base(dbConfig?.PublicSectorReportingConnectionString) { }

        public void RemovePublicSectorReporting(string accountid) => ExecuteSqlCommand($"DELETE FROM Report WHERE EmployerId = '{accountid}'");
    }
}
