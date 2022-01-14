using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper
{
    public class EasComtDbSqlDataHelper : ProjectSqlDbHelper
    {
        public EasComtDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.CommitmentsDbConnectionString) { }

        internal List<string[]> GetApprenticeIds(List<string> accountIdToDelete)
        {
            return GetMultipleData($"select a.id from Apprenticeship a Join Commitment c on c.id = a.CommitmentId and c.EmployerAccountId in ({string.Join(",", accountIdToDelete)})");
        }
    }
}
