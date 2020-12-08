using Polly;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class SqlDbHelper
    {
        protected readonly string connectionString;

        protected SqlDbHelper(string connectionString) => this.connectionString = connectionString;

        protected string GetNullableData(string queryToExecute)
        {
            List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString);

            if (responseData.Count == 0)
                return string.Empty;
            else
                return Convert.ToString(responseData[0][0]);
        }

        protected string GetData(string queryToExecute) => Convert.ToString(GetDataAsObject(queryToExecute));

        protected object GetDataAsObject(string queryToExecute) => SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0];

        protected int ExecuteSqlCommand(string queryToExecute) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(queryToExecute, connectionString);

        protected object TryGetDataAsObject(string queryToExecute, int maxRetries, string exception, ScenarioInfo scenarioInfo)
        {
            return RetryOnException(maxRetries, exception, scenarioInfo)
                .Execute(() => SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);
        } 

        private Policy RetryOnException(int maxRetries, string exception, ScenarioInfo scenarioInfo)
        {
            TimeSpan[] TimeOut = SetTimeOut();

            return Policy
                .Handle<Exception>((x) => x.Message.Contains(exception))
                 .WaitAndRetry(TimeOut, (exception, timeSpan, retryCount, context) =>
                 {
                     Logging.Report(retryCount, exception, scenarioInfo.Title);
                 });
        }

        private TimeSpan[] SetTimeOut() => new TimeSpan[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(3) };
    }
}
