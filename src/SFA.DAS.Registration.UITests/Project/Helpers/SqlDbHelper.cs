using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal abstract class SqlDbHelper
    {
        protected readonly string _connectionString;
        
        public SqlDbHelper(string connectionString) => _connectionString = connectionString;
        
        protected string GetData(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, _connectionString)[0][0]);
    }
}
