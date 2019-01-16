using Dapper;
using System;
using System.Data.SqlClient;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class SqlDatabaseConncetionHelper
    {
        public static int ExecuteSqlCommand(String connectionString, String queryToExecute,object dynamicParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(queryToExecute, dynamicParameters);
                return affectedRows;
            }
        }

        public static SqlDataReader ReadDataFromDataBase(String queryToExecute, String connectionString)
        {
            SqlDataReader dataReader = null;
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            SqlCommand command = new SqlCommand(queryToExecute, databaseConnection);
            dataReader = command.ExecuteReader();
            databaseConnection.Close();
            return dataReader;
        }
    }
}