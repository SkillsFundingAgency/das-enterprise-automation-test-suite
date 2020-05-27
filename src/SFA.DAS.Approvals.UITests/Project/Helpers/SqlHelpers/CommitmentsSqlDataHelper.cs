using SFA.DAS.UI.FrameworkHelpers;
using System;
namespace SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers
{
    public class CommitmentsSqlDataHelper : SqlDbHelper
    {
        public CommitmentsSqlDataHelper(ApprovalsConfig approvalsConfig) : base(approvalsConfig.CommitmentsDbConnectionString) { }

        public void SetHasHadDataLockSuccessTrue(string uln)
        {
            if (uln.Equals(null))
            {
                throw new Exception("ULN is not set");
            }
            string sqlQueryToSetDataLockSuccessStatus = $"UPDATE Apprenticeship SET HasHadDataLockSuccess = 1 WHERE ULN = '{uln}'";

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(connectionString, sqlQueryToSetDataLockSuccessStatus);
        }

        public int GetApprenticeshipId(string uln) => Convert.ToInt32(GetDataAsObject($"SELECT Id from [dbo].[Apprenticeship] WHERE ULN = '{uln}' AND PaymentStatus >= 1"));
    }
}
