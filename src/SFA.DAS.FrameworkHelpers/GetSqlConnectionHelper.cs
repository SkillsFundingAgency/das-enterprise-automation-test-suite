using Microsoft.Data.SqlClient;

namespace SFA.DAS.FrameworkHelpers;

public static class GetSqlConnectionHelper
{
    internal static SqlConnection GetSqlConnection(string connectionString)
    {
        var tenantidkey = "TENANTID=";

        var tenantidwithKey = connectionString.Split(';').ToList().Single(x=> x.StartsWith(tenantidkey, StringComparison.OrdinalIgnoreCase));

        connectionString = connectionString.Replace(tenantidwithKey, string.Empty);

        var tenantid = tenantidwithKey.Replace(tenantidkey, string.Empty);

        return new() { ConnectionString = connectionString, AccessToken = connectionString.Contains("User ID=") ? null : AzureTokenService.GetDatabaseAuthToken(tenantid) };
    }
}