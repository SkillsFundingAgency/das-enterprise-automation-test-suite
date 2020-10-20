using System;
using System.Collections.Generic;

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
    }
}
