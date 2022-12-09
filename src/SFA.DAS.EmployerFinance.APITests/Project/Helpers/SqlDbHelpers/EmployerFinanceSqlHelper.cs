using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerFinanceSqlHelper : SqlDbHelper
    {
        private readonly ObjectContext _objectContext;

        public EmployerFinanceSqlHelper(DbConfig dbConfig, ScenarioContext context) : base(dbConfig.FinanceDbConnectionString)
        {
            _objectContext = context.Get<ObjectContext>();
        }

        public void SetAccountId()
        {
            var accountId = GetDataAsString($"SELECT top (1) AccountId FROM [employer_financial].[LevyDeclaration] order by Id desc");
            _objectContext.SetAccountId(accountId);
        }

        public void SetEmpRef()
        {
            var empRef = GetDataAsString($"Select top (1) EmpRef from [employer_financial].[AccountPaye] Where [AccountId] = {long.Parse(_objectContext.GetAccountId())}");
            _objectContext.SetEmpRef(empRef);
        }
    }
}