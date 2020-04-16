using System;

namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class SqlDbHelper
    {
        protected readonly string connectionString;

        public SqlDbHelper(string connectionString) => this.connectionString = connectionString;

        protected string GetData(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);
    }
}
