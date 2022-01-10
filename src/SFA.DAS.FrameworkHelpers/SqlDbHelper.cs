using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.FrameworkHelpers
{
    public abstract class SqlDbHelper : SqlDbRetryHelper
    {
        protected readonly string connectionString;

        protected SqlDbHelper(string connectionString) => this.connectionString = connectionString;

        protected bool IsNoDataFound(List<string[]> x) => IsNoDataFound(x.ListOfArrayToList(0));

        protected bool IsNoDataFound(List<string> x) => (x.Count == 1 && string.IsNullOrEmpty(x[0]));

        protected List<string> GetData(string query) => GetData(query, connectionString);

        protected List<string> GetData(string query, string connectionstring) => GetData(query, connectionstring, null);

        protected List<string> GetData(string query, Dictionary<string, string> parameters) => GetData(query, connectionString, parameters);

        protected List<string> GetData(string query, string connectionstring, Dictionary<string, string> parameters)
        {
            (List<object[]> data, int noOfColumns) data = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionstring, parameters);

            var returnItems = new List<string>();

            for (int i = 0; i < data.noOfColumns; i++)
            {
                if (data.data.Count == 0) returnItems.Add(string.Empty);
                else returnItems.Add(data.data[0][i].ToString());
            }

            return returnItems;
        }

        protected List<List<string[]>> GetListOfMultipleData(List<string> query, string connectionstring)
        {
            List<(List<object[]> data, int noOfColumns)> multidatas = TryReadMultipleDataFromDataBase(query, connectionstring);

            var multireturnItems = new List<List<string[]>>();

            foreach (var (data, noOfColumns) in multidatas)
            {
                var returnItems = new List<string[]>();

                var datalist = data;

                var noOfRows = datalist.Count;

                if (noOfRows == 0) returnItems.Add(new string[noOfColumns]);

                for (int i = 0; i < noOfRows; i++)
                {
                    var items = new string[datalist[i].Length];

                    for (int j = 0; j < items.Length; j++)
                    {
                        var item = datalist[i][j].ToString();

                        items[j] = item;
                    }
                    returnItems.Add(items);
                }
                multireturnItems.Add(returnItems);
            }
            return multireturnItems;
        }

        protected List<List<string[]>> GetListOfMultipleData(List<string> query) => GetListOfMultipleData(query, connectionString);

        protected List<string[]> GetMultipleData(string query, string connectionstring) => GetListOfMultipleData(new List<string> { query }, connectionstring).FirstOrDefault();

        protected List<string[]> GetMultipleData(string query) => GetMultipleData(query, connectionString);

        protected string GetNullableData(string queryToExecute)
        {
            var data = GetData(queryToExecute);

            if (data.Count == 0)
                return string.Empty;
            else
                return data[0];
        }

        protected string GetDataAsString(string queryToExecute) => Convert.ToString(GetDataAsObject(queryToExecute));

        protected object GetDataAsObject(string queryToExecute) => ReadDataFromDataBase(queryToExecute, connectionString)[0][0];

        protected int ExecuteSqlCommand(string queryToExecute) => ExecuteSqlCommand(queryToExecute, connectionString);

        protected int ExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null) 
            => SqlDatabaseConnectionHelper.ExecuteSqlCommand(queryToExecute, connectionString, parameters);

        protected int TryExecuteSqlCommand(string queryToExecute, string connectionString, Dictionary<string, string> parameters = null)
            => RetryOnException(() => ExecuteSqlCommand(queryToExecute, connectionString, parameters));

        protected object TryGetDataAsObject(string queryToExecute, string title)
            => RetryOnIndexOutOfRangeException(() => GetDataAsObject(queryToExecute), title);

        private List<(List<object[]> data, int noOfColumns)> TryReadMultipleDataFromDataBase(List<string> queryToExecute, string connectionString)
            => RetryOnException(() => ReadMultipleDataFromDataBase(queryToExecute, connectionString));

        private List<object[]> ReadDataFromDataBase(string queryToExecute, string connectionString) => SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString);

        private List<(List<object[]> data, int noOfColumns)> ReadMultipleDataFromDataBase(List<string> queryToExecute, string connectionString) => SqlDatabaseConnectionHelper.ReadMultipleDataFromDataBase(queryToExecute, connectionString, null);
    }
}
