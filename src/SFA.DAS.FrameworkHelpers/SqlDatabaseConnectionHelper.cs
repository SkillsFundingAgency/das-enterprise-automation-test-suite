using Dapper;
using Dapper.Contrib.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SFA.DAS.FrameworkHelpers.WaitConfigurationHelper;

namespace SFA.DAS.FrameworkHelpers;

public static class WaitConfigurationHelper
{
    public class WaitHelper
    {
        private static WaitConfiguration Config => new();

        public static async Task WaitForIt(Func<bool> lookForIt, string textMessage)
        {
            var endTime = DateTime.Now.Add(Config.TimeToWait);

            int retryCount = 0;

            while (DateTime.Now <= endTime)
            {
                if (lookForIt()) return;

                TestContext.Progress.WriteLine($"Retry {retryCount++} - Waiting for the sql query to return valid data - '{textMessage}'");

                await Task.Delay(Config.TimeToPoll(retryCount));
            }
        }

        public class WaitConfiguration
        {
            public TimeSpan TimeToWait { get; set; } = TimeSpan.FromMinutes(5);
            public TimeSpan TimeToPoll(int x) => TimeSpan.FromSeconds(5 * x);
        }
    }
}


public static class SqlDatabaseConnectionHelper
{
    public static int ExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null)
    {
        try
        {
            using (SqlConnection databaseConnection = GetSqlConnection(connectionString))
            {
                databaseConnection.Open();

                using (SqlCommand command = new(queryToExecute, databaseConnection))
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
            throw new Exception($"Exception occurred while executing SQL query:{Environment.NewLine}{queryToExecute}{Environment.NewLine}Exception: " + exception);
        }
    }

    public static List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString, bool mustFindresult = false) => ReadDataFromDataBase(queryToExecute, connectionString, null, mustFindresult).data;

    public static (List<object[]> data, int noOfColumns) ReadDataFromDataBase(string queryToExecute, string connectionString, Dictionary<string, string> parameters, bool mustFindresult) =>
        ReadMultipleDataFromDataBase(new List<string> { queryToExecute }, connectionString, parameters, mustFindresult).FirstOrDefault();

    public static List<(List<object[]> data, int noOfColumns)> ReadMultipleDataFromDataBase(List<string> queryToExecute, string connectionString, Dictionary<string, string> parameters, bool waitForResults)
    {
        try
        {
            using (SqlConnection dbConnection = GetSqlConnection(connectionString))
            {
                using (SqlCommand command = new(string.Join(string.Empty, queryToExecute), dbConnection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, string> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    var result = RetriveData(queryToExecute, dbConnection, command);

                    if (waitForResults)
                    {
                        WaitHelper.WaitForIt(() =>
                        {
                            if (result.Any(x => x.data.Any(y => !string.IsNullOrEmpty(y?.ToString())))) return true;

                            result = RetriveData(queryToExecute, dbConnection, command);

                            return false;
                        }, queryToExecute.FirstOrDefault()).Wait();
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

    private static List<(List<object[]> data, int noOfColumns)> RetriveData(List<string> queryToExecute, SqlConnection dbConnection, SqlCommand command)
    {
        List<(List<object[]>, int)> multiresult = new();

        dbConnection.Open();

        SqlDataReader dataReader = command.ExecuteReader();

        foreach (var _ in queryToExecute)
        {
            List<object[]> result = new();
            int noOfColumns = dataReader.FieldCount;
            while (dataReader.Read())
            {
                object[] items = new object[noOfColumns];
                dataReader.GetValues(items);
                result.Add(items);
            }

            multiresult.Add((result, noOfColumns));
            dataReader.NextResult();
        }

        dbConnection.Close();

        return multiresult;
    }

    public static int ExecuteSqlCommand(string queryToExecute, string connectionString)
    {
        using var connection = GetSqlConnection(connectionString);
        return connection.Execute(queryToExecute);
    }

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

    private static SqlConnection GetSqlConnection(string connectionString)
    {
        WriteDebugMessage(connectionString);

        return new() { ConnectionString = connectionString, AccessToken = connectionString.Contains("User ID=") ? null : AzureTokenService.GetDatabaseAuthToken() };
    }

    private static void WriteDebugMessage(string connectionString)
    {
        var x = Regex.Replace(connectionString, @"Password=.*;Trusted_Connection", "Password=<*******>;Trusted_Connection");

        TestContext.Progress.WriteLine($"Connect to sql using '{x}'");
    }
}