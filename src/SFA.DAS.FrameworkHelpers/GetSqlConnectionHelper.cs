using System.Data.SqlClient;

namespace SFA.DAS.FrameworkHelpers;

public static class GetSqlConnectionHelper
{
    internal static SqlConnection GetSqlConnection(string connectionString)
    {
        return new() { ConnectionString = connectionString, AccessToken = connectionString.Contains("User ID=") ? null : AzureTokenService.GetDatabaseAuthToken() };
    }
}