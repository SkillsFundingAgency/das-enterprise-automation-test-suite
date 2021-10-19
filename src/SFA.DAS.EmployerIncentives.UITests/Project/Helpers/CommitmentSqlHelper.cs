using System;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class CommitmentSqlHelper : SqlDbHelper
    {
        string query;

        public CommitmentSqlHelper(DbConfig dbConfig) : base(dbConfig.CommitmentsDbConnectionString) { }

        public long GetAccountLegalEntityId(string hashedId)
        {
            query = $"SELECT acl.Id from [dbo].[Accounts] a inner join[dbo].[AccountLegalEntities] acl on a.Id = acl.accountId where a.hashedid = '{hashedId}'";

            return FetchLongQueryData(0);            
        }

        public void DeleteAccountLegalEntity(string hashedId)
        {
            query = $"DELETE FROM [dbo].[AccountLegalEntities] WHERE Id = (SELECT acl.Id from [dbo].[Accounts] a inner join[dbo].[AccountLegalEntities] acl on a.Id = acl.accountId where a.hashedid = '{hashedId}');" +
                    $"DELETE FROM [dbo].[Accounts] WHERE hashedid = '{hashedId}';";

            ExecuteSqlCommand(query);
        }

        private long FetchLongQueryData(int columnIndex) => Convert.ToInt64(SqlDatabaseConnectionHelper.ReadDataFromDataBase(query, connectionString)[0][columnIndex]);
    }
}
