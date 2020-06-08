using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public static class SqlDatabaseConnectionHelper
    {
        public static int ExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(connectionString))
                {
                    databaseConnection.Open();
                    using (SqlCommand command = new SqlCommand(queryToExecute, databaseConnection))
                    {
                        foreach (KeyValuePair<string, string> param in parameters)
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

        public static List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null)
        {
            try
            {
                using (SqlConnection databaseConnection = new SqlConnection(connectionString))
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
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Execute(queryToExecute);
            }
        }
    }
}