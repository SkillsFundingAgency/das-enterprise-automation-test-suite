using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SFA.DAS.FrameworkHelpers;

public static class DapperSqlHelper
{
    public static async Task<int> Insert<T>(T entity, string connectionString) where T : class
    {
        await using var dbConnection = GetSqlConnection(connectionString);
        return await dbConnection.InsertAsync(entity);
    }

    public static async Task<T> Get<T>(object id, string connectionString) where T : class
    {
        await using var dbConnection = GetSqlConnection(connectionString);
        return await dbConnection.GetAsync<T>(id);
    }

    private static SqlConnection GetSqlConnection(string connectionString) => GetSqlConnectionHelper.GetSqlConnection(connectionString);
}
