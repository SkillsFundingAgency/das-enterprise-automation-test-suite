using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class CommitmentsDataHelper
    {
        private readonly ApprovalsConfig _approvalsConfig;

        private readonly SqlDatabaseConnectionHelper _sqlDatabase;

        public CommitmentsDataHelper(ApprovalsConfig approvalsConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _approvalsConfig = approvalsConfig;
            _sqlDatabase = sqlDatabase;
        }

        public void SetHasHadDataLockSuccessTrue(String uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            _sqlDatabase.ExecuteSqlCommand(_approvalsConfig.AP_CommitmentsDbConnectionString, sqlQueryToSetDataLockSuccessStatus);
        }
    }
}
