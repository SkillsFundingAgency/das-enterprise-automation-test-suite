using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    internal class DataLockEventIdSqlHelper : SqlDbHelper
    {
        public DataLockEventIdSqlHelper(ObjectContext objectContext, string connectionString) : base(objectContext, connectionString)
        {
                
        }

        static readonly object _object = new();

        internal int GetMaxDataLockEventId()
        {
            lock (_object)
            {
                List<object[]> responseData = GetListOfData($"SELECT MAX(DataLockEventId) FROM [dbo].[DataLockStatus]");

                return responseData.Count == 0 ? 0 : Convert.ToInt32(responseData[0][0]);
            }
        }
    }
}