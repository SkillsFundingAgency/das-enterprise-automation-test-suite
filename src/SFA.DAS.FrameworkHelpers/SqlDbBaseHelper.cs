using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using static SFA.DAS.FrameworkHelpers.WaitConfigurationHelper;

namespace SFA.DAS.FrameworkHelpers;

public class SqlDbBaseHelper(ObjectContext objectContext, string connectionString)
{
    protected bool waitForResults = false;

    protected readonly string connectionString = connectionString;

    protected readonly ObjectContext objectContext = objectContext;

    #region ExecuteSqlCommand

    public int ExecuteSqlCommand(string queryToExecute) => ExecuteSqlCommand(queryToExecute, connectionString);

    public int ExecuteSqlCommand(string queryToExecute, string connectionString) => ExecuteSqlCommand(queryToExecute, connectionString, null);

    public int ExecuteSqlCommand(string queryToExecute, Dictionary<string, string> parameters) => ExecuteSqlCommand(queryToExecute, connectionString, parameters);

    public int ExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters) 
    {
        SetDebugInformation($"ExecuteSqlCommand:{Environment.NewLine}{queryToExecute}");

        try
        {
            using SqlConnection databaseConnection = GetSqlConnection(connectionString);
            databaseConnection.Open();

            using SqlCommand command = new(queryToExecute, databaseConnection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, string> param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            return command.ExecuteNonQuery();
        }
        catch (Exception exception)
        {
            throw new Exception($"Exception occurred while executing SQL query:{Environment.NewLine}{queryToExecute}{Environment.NewLine}Exception: " + exception);
        }
    }

    #endregion

    protected List<object[]> GetListOfData(string queryToExecute) => GetListOfData(queryToExecute, connectionString, null).data;

    protected (List<object[]> data, int noOfColumns) GetListOfData(string queryToExecute, string connectionString, Dictionary<string, string> parameters) =>
        GetMultipleListOfData([queryToExecute], connectionString, parameters).FirstOrDefault();

    protected List<(List<object[]> data, int noOfColumns)> GetMultipleListOfData(List<string> queryToExecute) =>
        GetMultipleListOfData(queryToExecute, connectionString, null);

    private List<(List<object[]> data, int noOfColumns)> GetMultipleListOfData(List<string> queryToExecute, string connectionString, Dictionary<string, string> parameters)
    {
        SetDebugInformation($"ReadDataFromDataBase:{Environment.NewLine}{string.Join(Environment.NewLine, queryToExecute)}");

        try
        {
            using SqlConnection dbConnection = GetSqlConnection(connectionString);
            using SqlCommand command = new(string.Join(string.Empty, queryToExecute), dbConnection);
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
                }, $"{queryToExecute.FirstOrDefault()}{Environment.NewLine}{WriteDebugMessage(connectionString)}").Wait();
            }

            return result;
        }
        catch (Exception exception)
        {
            throw new Exception("Exception occurred while executing SQL query"
                + "\n Exception: " + exception);
        }
    }

    private static List<(List<object[]> data, int noOfColumns)> RetriveData(List<string> queryToExecute, SqlConnection dbConnection, SqlCommand command)
    {
        List<(List<object[]>, int)> multiresult = [];

        dbConnection.Open();

        SqlDataReader dataReader = command.ExecuteReader();

        foreach (var _ in queryToExecute)
        {
            List<object[]> result = [];
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

    private static SqlConnection GetSqlConnection(string connectionString) => GetSqlConnectionHelper.GetSqlConnection(connectionString);

    private static string WriteDebugMessage(string connectionString) => Regex.Replace(connectionString, @"Password=.*;Trusted_Connection", "Password=<*******>;Trusted_Connection");

    private void SetDebugInformation(string x) => objectContext.SetDebugInformation(x);
}
