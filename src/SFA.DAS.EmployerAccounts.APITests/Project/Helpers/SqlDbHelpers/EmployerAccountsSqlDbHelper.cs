using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerAccountsSqlDbHelper : SqlDbHelper
    {        
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public EmployerAccountsSqlDbHelper(DbConfig dbConfig, ScenarioContext context) : base(dbConfig.AccountsDbConnectionString)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public string GetAccountId()
        {
            var accountId =  GetDataAsString($"Select top (1) HashedId from [employer_account].[Account] Where [ApprenticeshipEmployerType] = 1  order by Id desc");            
            _objectContext.SetAccountId(accountId);
            return accountId;
        }

        public string GetInternalAccountId()
        {
            var internalAccountId = GetDataAsString($"Select top (1) Id  from [employer_account].[Account] Where [ApprenticeshipEmployerType] = 1  order by Id desc");
            _objectContext.SetInternalAccountId(internalAccountId);
            return internalAccountId;
        }

        public string GetpayeSchemeRef()
        {
            var payeScheme = GetDataAsString($"Select TOP 1 paye.Ref  from employer_account.Paye paye  INNER JOIN employer_account.AccountHistory ah ON ah.PayeRef = paye.Ref " +
                $"INNER JOIN employer_account.account a ON a.Id = ah.AccountId WHERE a.HashedId = '{_objectContext.GetAccountId()}'");

            return payeScheme;
        }

        public string GetUserEmail()
        {
            return GetDataAsString("Select top 1 Email from [employer_account].[User] order by Id desc");            
        }    
    }
}
