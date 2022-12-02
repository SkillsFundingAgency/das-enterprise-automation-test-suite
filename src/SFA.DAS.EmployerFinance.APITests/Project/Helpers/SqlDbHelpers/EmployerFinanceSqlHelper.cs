using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerFinanceSqlHelper : SqlDbHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;

        public EmployerFinanceSqlHelper(DbConfig dbConfig, ScenarioContext context) : base(dbConfig.FinanceDbConnectionString)
        {
            _context = context;
            _dbConfig = dbConfig;
            _objectContext = context.Get<ObjectContext>();
        }

        public void SetAccountId()
        {
            var accountId = GetDataAsString($"SELECT top (1) AccountId FROM [employer_financial].[LevyDeclaration] order by Id desc");
            _objectContext.SetAccountId(accountId);
        }

        public void SetHashedAccountId()
        {            
            var queryToExecute = "Select top (1) HashedId from [employer_account].[Account] Where [ApprenticeshipEmployerType] = 1 order by Id desc";
            var hashedAccountId =  SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, _dbConfig.AccountsDbConnectionString);
            _objectContext.SetHashedAccountId(hashedAccountId[0][0].ToString());
        }

        public void SetEmpRef()
        {
            var empRef = GetDataAsString($"Select top (1) EmpRef from [employer_financial].[AccountPaye] Where [AccountId] = {long.Parse(_objectContext.GetAccountId())}");
            _objectContext.SetEmpRef(empRef);
        }
    }
}