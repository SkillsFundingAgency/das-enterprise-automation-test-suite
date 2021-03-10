using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;


namespace SFA.DAS.SupportConsole.UITests.Project.SqlHelpers
{
    public class CommitmentsSqlDataHelper : SqlDbHelper
    {
        public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

        public void UpdateApprenticeshipStatus(string uln, int status)
        {
            string stopDate, pauseDate, completionDate;

            if (uln.Equals(null))
                throw new Exception("ULN is not set");

            if (status < 1 || status > 4)
                throw new Exception("Invalid Status!");


            pauseDate = (status == 2) ? DateTime.Now.ToString("yyyy-MM-dd") : null;
            stopDate = (status == 3) ? DateTime.Now.ToString("yyyy-MM-dd") : null;            
            completionDate = (status == 4) ? DateTime.Now.ToString("yyyy-MM-dd") : null;

            string sqlQueryToSetDataLockSuccessStatus = $@"UPDATE Apprenticeship
                                                            SET PaymentStatus = {status.ToString()}, StopDate = '{stopDate}', PauseDate = '{pauseDate}', CompletionDate = '{completionDate}'
                                                            WHERE ULN = '{uln}'";

            ExecuteSqlCommand(sqlQueryToSetDataLockSuccessStatus);
        }
    }
}
