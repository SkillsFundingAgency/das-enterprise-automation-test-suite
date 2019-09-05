using Dapper;
using System.Data.SqlClient;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class SqlDatabaseConncetionHelper
    {
        public int ExecuteSqlCommand(string connectionString, string queryToExecute, object dynamicParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(queryToExecute, dynamicParameters);
                return affectedRows;
            }
        }

        public SqlDataReader ReadDataFromDataBase(string queryToExecute, string connectionString)
        {
            using (var databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                var command = new SqlCommand(queryToExecute, databaseConnection);
                return command.ExecuteReader();
            }
        }
    }
}