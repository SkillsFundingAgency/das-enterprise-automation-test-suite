using Microsoft.Data.SqlClient;

namespace SFA.DAS.FrameworkHelpers;

public static class GetSqlConnectionHelper
{
    internal static SqlConnection GetSqlConnection(string connectionString)
    {
        var tenantidkey = "TENANTID=";

        string accessToken;

        if (connectionString.Contains("User ID="))
        {
            accessToken = null;
        }
        else
        {
            if (connectionString.Contains(tenantidkey))
            {
                var tenantidwithKey = connectionString.Split(';').ToList().Single(x => x.StartsWith(tenantidkey, StringComparison.OrdinalIgnoreCase));

                connectionString = connectionString.Replace(tenantidwithKey, string.Empty);

                var tenantid = tenantidwithKey.Replace(tenantidkey, string.Empty);

                accessToken = AzureTokenService.GetDatabaseAuthToken(tenantid);
            }
            else
            {
                accessToken = AzureTokenService.GetDatabaseAuthToken();
            }
        }

        return new() { ConnectionString = connectionString, AccessToken = accessToken };
    }
}