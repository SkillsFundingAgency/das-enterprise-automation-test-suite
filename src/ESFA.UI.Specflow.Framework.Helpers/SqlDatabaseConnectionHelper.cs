using Dapper;
using System.Data.SqlClient;

namespace ESFA.UI.Specflow.Framework.Helpers
{
    public class SqlDatabaseConncetionHelper
    {
        public static int ExecuteSqlCommand(string connectionString, string queryToExecute, object dynamicParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(queryToExecute, dynamicParameters);
                return affectedRows;
            }
        }

        public static SqlDataReader ReadDataFromDataBase(string queryToExecute, string connectionString)
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