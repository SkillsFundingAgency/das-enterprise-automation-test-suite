using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{

    public class EmployerFinanceSqlHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.FinanceDbConnectionString)
    {
        public string SetAccountId()
        {
            var accountId = GetDataAsString($"SELECT top (1) AccountId FROM [employer_financial].[LevyDeclaration] order by Id desc");

            objectContext.SetAccountId(accountId);

            return accountId;
        }

        public void SetEmpRef()
        {
            var empRef = GetDataAsString($"Select top (1) EmpRef from [employer_financial].[AccountPaye] Where [AccountId] = {long.Parse(objectContext.GetAccountId())}");

            objectContext.SetEmpRef(empRef);
        }
    }
}