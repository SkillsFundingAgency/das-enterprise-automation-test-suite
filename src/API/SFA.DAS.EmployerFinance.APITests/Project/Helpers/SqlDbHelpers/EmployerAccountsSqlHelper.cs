using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerAccountsSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.AccountsDbConnectionString)
    {
        public string SetHashedAccountId(string accountId)
        {
            var id = GetDataAsString($"SELECT HashedId FROM [employer_account].[Account] WHERE id = '{accountId}' ");

            objectContext.SetHashedAccountId(id);

            return id;
        }
    }
}