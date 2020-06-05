using SFA.DAS.UI.FrameworkHelpers;
namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class PublicSectorReportingSqlDataHelper : SqlDbHelper
    {
        public PublicSectorReportingSqlDataHelper(ApprovalsConfig approvalsConfig) : base(approvalsConfig.PublicSectorReportingConnectionString) { }

        public void RemovePublicSectorReporting(string accountid) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(connectionString, $"DELETE FROM Report WHERE EmployerId = '{accountid}'");
    }
}
