using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal abstract class SqlDbHelper
    {
        protected readonly string connectionString;
        
        public SqlDbHelper(string connectionString) => this.connectionString = connectionString;
        
        protected string GetData(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);
    }
}
