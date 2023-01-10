using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerAccountsSqlHelper : SqlDbHelper
    {
        private readonly ObjectContext _objectContext;

        public EmployerAccountsSqlHelper(DbConfig dbConfig, ObjectContext objectContext) : base(dbConfig.AccountsDbConnectionString)
        {

        }

        public string SetHashedAccountId(string accountId)
        {
            var id = GetDataAsString($"SELECT HashedId FROM [employer_account].[Account] WHERE id = '{accountId}' ");
            _objectContext.SetHashedAccountId(id);
            return id;
        }


    }

    public class EmployerFinanceSqlHelper : SqlDbHelper
    {
        private readonly ObjectContext _objectContext;

        public EmployerFinanceSqlHelper(DbConfig dbConfig, ObjectContext objectContext) : base(dbConfig.FinanceDbConnectionString)
        {
            _objectContext = objectContext;
        }

        public string SetAccountId()
        {
            var accountId = GetDataAsString($"SELECT top (1) AccountId FROM [employer_financial].[LevyDeclaration] order by Id desc");
            _objectContext.SetAccountId(accountId);
            return accountId;
        }

        public void SetEmpRef()
        {
            var empRef = GetDataAsString($"Select top (1) EmpRef from [employer_financial].[AccountPaye] Where [AccountId] = {long.Parse(_objectContext.GetAccountId())}");
            _objectContext.SetEmpRef(empRef);
        }
    }
}