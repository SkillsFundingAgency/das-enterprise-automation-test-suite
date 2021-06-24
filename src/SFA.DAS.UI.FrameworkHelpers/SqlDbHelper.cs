using Polly;
using System;
using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class SqlDbHelper
    {
        protected readonly string connectionString;

        protected SqlDbHelper(string connectionString) => this.connectionString = connectionString;

        protected List<string> GetData(string query, int noOfvalues, Dictionary<string, string> parameters = null) => GetData(query, connectionString, noOfvalues, parameters);

        protected List<string> GetData(string query, string connectionstring, int noOfvalues, Dictionary<string, string> parameters = null)
        {
            List<object[]> data = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionstring, parameters);

            var returnItems = new List<string>();

            for (int i = 0; i < noOfvalues; i++)
            {
                if (data.Count == 0) returnItems.Add(string.Empty);
                else returnItems.Add(data[0][i].ToString());
            }

            return returnItems;
        }

        protected List<string[]> GetMultipleData(string query, int noOfvalues)
        {
            List<object[]> data = ReadDataFromDataBase(query);

            var returnItems = new List<string[]>();

            if (data.Count == 0) returnItems.Add(new string[noOfvalues]);

            var length = data.Count;

            for (int i = 0; i < length; i++)
            {
                var items = new string[noOfvalues];

                for (int j = 0; j < noOfvalues; j++)
                {
                    var item = data[i][j].ToString();

                    items[j] = item;
                }

                returnItems.Add(items);
            }

            return returnItems;
        }

        protected string GetNullableData(string queryToExecute)
        {
            var data = GetData(queryToExecute, 1);

            if (data.Count == 0)
                return string.Empty;
            else
                return data[0];
        }

        protected string GetData(string queryToExecute) => Convert.ToString(GetDataAsObject(queryToExecute));

        protected object GetDataAsObject(string queryToExecute) => ReadDataFromDataBase(queryToExecute)[0][0];

        protected int ExecuteSqlCommand(string queryToExecute) => ExecuteSqlCommand(queryToExecute, connectionString);

        protected int ExecuteSqlCommand(string queryToExecute, string connectionString) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(queryToExecute, connectionString);

        protected object TryGetDataAsObject(string queryToExecute, string exception, string title) => RetryOnException(exception, title).Execute(() => GetDataAsObject(queryToExecute));

        private List<object[]> ReadDataFromDataBase(string queryToExecute) => SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString);

        private Policy RetryOnException(string exception, string title)
        {
            return Policy
                .Handle<Exception>((x) => x.Message.Contains(exception))
                 .WaitAndRetry(Logging.SetTimeOut(), (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, title);
                 });
        }
    }
}
