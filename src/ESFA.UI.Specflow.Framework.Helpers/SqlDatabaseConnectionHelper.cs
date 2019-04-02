using System.Data.SqlClient;

namespace ESFA.UI.Specflow.Framework.Helpers
{
    public class SqlDatabaseConncetionHelper
    {
        public static int ExecuteSqlCommand(string queryToExecute, string connectionString)
        {
            using (var databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                var command = new SqlCommand(queryToExecute, databaseConnection);
                return command.ExecuteNonQuery();
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