using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public class SqlDatabaseConnectionHelper
    {
        public int ExecuteSqlCommand(string connectionString, string queryToExecute, object dynamicParameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var affectedRows = connection.Execute(queryToExecute, dynamicParameters);
                return affectedRows;
            }
        }

        public int ExecuteSqlCommand(String connectionString, String queryToExecute, Dictionary<String, String> parameters)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(connectionString))
                {
                    databaseConnection.Open();
                    using (SqlCommand command = new SqlCommand(queryToExecute, databaseConnection))
                    {
                        foreach (KeyValuePair<String, String> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
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

        public List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(connectionString))
                {
                    databaseConnection.Open();
                    using (SqlCommand command = new SqlCommand(queryToExecute, databaseConnection))
                    {
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
    }
}