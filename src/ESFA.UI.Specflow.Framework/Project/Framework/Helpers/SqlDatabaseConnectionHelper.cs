using OpenQA.Selenium;
using System;
using System.Data.SqlClient;

namespace ESFA.UI.Specflow.Framework.Project.Framework.Helpers
{
    public class SqlDatabaseConncetionHelper
    {
        protected IWebDriver webDriver;

        public SqlDatabaseConncetionHelper(IWebDriver _webDriver)
        {
            webDriver = _webDriver;
        }

        public static int ExecuteSqlCommand(String queryToExecute, String connectionString)
        {
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            SqlCommand command = new SqlCommand(queryToExecute, databaseConnection);
            int result = command.ExecuteNonQuery();
            databaseConnection.Close();
            return result;
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