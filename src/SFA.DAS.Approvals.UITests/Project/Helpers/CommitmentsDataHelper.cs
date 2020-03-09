using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class CommitmentsDataHelper
    {
        private readonly string _connectionString;

        public CommitmentsDataHelper(ApprovalsConfig approvalsConfig) => _connectionString = approvalsConfig.CommitmentsDbConnectionString;

        public void SetHasHadDataLockSuccessTrue(String uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(_connectionString, sqlQueryToSetDataLockSuccessStatus);
        }

        public int GetApprenticeshipId(String uln)
        {
            String sqlQueryToGetApprenticeshipId = $"SELECT Id from [dbo].[Apprenticeship] WHERE ULN = '{uln}' AND PaymentStatus >= 1";
            List<object[]> responseData = SqlDatabaseConnectionHelper.ReadDataFromDataBase(sqlQueryToGetApprenticeshipId, _connectionString);

            if (responseData.Count == 0)
                throw new Exception("Unable to get apprenticeshipId:"
                + "\n ULN: " + uln
                + "\n SQL Query: " + sqlQueryToGetApprenticeshipId);
            else
                return Convert.ToInt32(responseData[0][0]);
        }
    }
}
