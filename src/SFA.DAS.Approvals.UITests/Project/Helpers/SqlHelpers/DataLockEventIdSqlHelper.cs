using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    internal static class DataLockEventIdSqlHelper
    {
        static readonly object _object = new object();

        internal static int GetMaxDataLockEventId(string connectionString)
        {
            lock (_object)
            {
                List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase($"SELECT MAX(DataLockEventId) FROM [dbo].[DataLockStatus]", connectionString);

                return responseData.Count == 0 ? 0 : Convert.ToInt32(responseData[0][0]);
            }
        }
    }
}