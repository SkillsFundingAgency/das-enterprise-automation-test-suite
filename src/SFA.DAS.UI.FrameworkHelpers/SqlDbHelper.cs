using Polly;
using System;
using System.Collections.Generic;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class SqlDbHelper
    {
        protected readonly string connectionString;

        protected SqlDbHelper(string connectionString) => this.connectionString = connectionString;

        protected List<string> GetData(string query, int noOfvalues) => GetData(query, connectionString, noOfvalues);

        protected List<string> GetData(string query, string connectionstring, int noOfvalues)
        {
            List<object[]> data = SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionstring);

            var returnItems = new List<string>();

            for (int i = 0; i < noOfvalues; i++)
            {
                if (data.Count == 0) returnItems.Add(string.Empty);
                else returnItems.Add(data[0][i].ToString());
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

        protected object GetDataAsObject(string queryToExecute) => SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0];

        protected int ExecuteSqlCommand(string queryToExecute) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(queryToExecute, connectionString);

        protected object TryGetDataAsObject(string queryToExecute, string exception, string title) => RetryOnException(exception, title).Execute(() => GetDataAsObject(queryToExecute));

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
