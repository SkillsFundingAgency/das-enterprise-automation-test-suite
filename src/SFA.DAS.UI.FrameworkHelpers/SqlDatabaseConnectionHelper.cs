using Dapper;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class SqlDatabaseConnectionHelper
    {
        private const string AzureResource = "https://database.windows.net/";

        public static int ExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null)
        {
            try
            {
                using (SqlConnection databaseConnection = GetSqlConnection(connectionString))
                {
                    databaseConnection.Open();

                    using (SqlCommand command = new SqlCommand(queryToExecute, databaseConnection))
                    {
                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, string> param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Exception occurred while executing SQL query"
                    + "\n Exception: " + exception);
            }
        }

        public static List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null)
        {
            try
            {
                using (SqlConnection databaseConnection = GetSqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(queryToExecute, databaseConnection))
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, string> param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        databaseConnection.Open();
                        SqlDataReader dataReader = command.ExecuteReader();
                        List<object[]> result = new List<object[]>();
                        while (dataReader.Read())
                        {
                            object[] items = new object[100];
                            dataReader.GetValues(items);
                            result.Add(items);
                        }

                        return result;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Exception occurred while executing SQL query"
                    + "\n Exception: " + exception);
            }
        }

        public static int ExecuteSqlCommand(string queryToExecute, string connectionString)
        {
            using var connection = GetSqlConnection(connectionString);
            return connection.Execute(queryToExecute);
        }

        private static SqlConnection GetSqlConnection(string connectionString) => new SqlConnection { ConnectionString = connectionString, AccessToken = connectionString.Contains("User ID=") ? null : new AzureServiceTokenProvider().GetAccessTokenAsync(AzureResource).Result };
    }
}