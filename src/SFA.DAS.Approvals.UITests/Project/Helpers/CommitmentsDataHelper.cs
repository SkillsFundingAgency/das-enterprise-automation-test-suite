using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class CommitmentsDataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;

        private readonly string _connectionString;

        public CommitmentsDataHelper(ApprovalsConfig approvalsConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
            _connectionString = approvalsConfig.AP_CommitmentsDbConnectionString;
        }

        public void SetHasHadDataLockSuccessTrue(String uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            _sqlDatabase.ExecuteSqlCommand(_connectionString, sqlQueryToSetDataLockSuccessStatus);
        }

        public int GetApprenticeshipId(String uln)
        {
            String sqlQueryToGetApprenticeshipId = $"SELECT Id from [dbo].[Apprenticeship] WHERE ULN = '{uln}' AND PaymentStatus >= 1";
            List<object[]> responseData = _sqlDatabase.ReadDataFromDataBase(sqlQueryToGetApprenticeshipId, _connectionString);

            if (responseData.Count == 0)
                throw new Exception("Unable to get apprenticeshipId:"
                + "\n ULN: " + uln
                + "\n SQL Query: " + sqlQueryToGetApprenticeshipId);
            else
                return Convert.ToInt32(responseData[0][0]);
        }
    }
}
