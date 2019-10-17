using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public partial class DlockDataHelper
    {
        private static class DataLockEventId
        {
            static readonly object _object = new object();

            internal static int GetMaxDataLockEventId(SqlDatabaseConnectionHelper sqlDatabase, string connectionString)
            {
                String sqlQueryToGetMaxDataLockEventId = $"SELECT MAX(DataLockEventId) FROM [dbo].[DataLockStatus]";

                lock (_object)
                {
                    List<object[]> responseData = sqlDatabase.ReadDataFromDataBase(sqlQueryToGetMaxDataLockEventId, connectionString);
                    if (responseData.Count == 0)
                        return 0;
                    else
                        return Convert.ToInt32(responseData[0][0]);
                }
            }
        }
    }
}
