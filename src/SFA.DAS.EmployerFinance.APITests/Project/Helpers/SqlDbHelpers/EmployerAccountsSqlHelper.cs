using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerAccountsSqlHelper : SqlDbHelper
    {
        private readonly ObjectContext _objectContext;

        public EmployerAccountsSqlHelper(DbConfig dbConfig, ObjectContext objectContext) : base(dbConfig.AccountsDbConnectionString)
        {
            _objectContext = objectContext;
        }

        public string SetHashedAccountId(string accountId)
        {
            var id = GetDataAsString($"SELECT HashedId FROM [employer_account].[Account] WHERE id = '{accountId}' ");
            _objectContext.SetHashedAccountId(id);
            return id;
        }
    }
}