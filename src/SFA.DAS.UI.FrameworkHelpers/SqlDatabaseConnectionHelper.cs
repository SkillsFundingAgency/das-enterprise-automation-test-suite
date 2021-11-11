using Dapper;
using Microsoft.Azure.Services.AppAuthentication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public static List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString) => ReadDataFromDataBase(queryToExecute, connectionString, null).data;

        public static (List<object[]> data, int noOfColumns) ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters) =>
            ReadMultipleDataFromDataBase(new List<string> { queryToExecute }, connectionString, parameters).FirstOrDefault();

        public static List<(List<object[]> data, int noOfColumns)> ReadMultipleDataFromDataBase(List<string> queryToExecute, string connectionString, Dictionary<string, string> parameters)
        {
            List<(List<object[]>, int)> multiresult = new List<(List<object[]>, int)>();
            
            

            try
            {
                using (SqlConnection dbConnection = GetSqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(string.Join(string.Empty, queryToExecute), dbConnection))
                    {
                        command.CommandType = CommandType.Text;

                        if (parameters != null)
                        {
                            foreach (KeyValuePair<string, string> param in parameters)
                            {
                                command.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }

                        dbConnection.Open();

                        SqlDataReader dataReader = command.ExecuteReader();

                        foreach (var item in queryToExecute)
                        {
                            List<object[]> result = new List<object[]>();
                            int noOfColumns = 0;
                            while (dataReader.Read())
                            {
                                noOfColumns = dataReader.FieldCount;
                                object[] items = new object[noOfColumns];
                                dataReader.GetValues(items);
                                result.Add(items);
                            }

                            multiresult.Add((result, noOfColumns));
                            dataReader.NextResult();
                        }
                        
                        return multiresult;
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