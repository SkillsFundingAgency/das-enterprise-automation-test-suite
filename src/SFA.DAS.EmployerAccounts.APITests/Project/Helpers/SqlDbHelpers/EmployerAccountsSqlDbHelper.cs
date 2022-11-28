using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;
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

        public void SetHashedAccountId()
        {
            var accountId =  GetDataAsString($"Select top (1) HashedId from [employer_account].[Account] Where [ApprenticeshipEmployerType] = 1  order by Id desc");            
            _objectContext.SetHashedAccountId(accountId);
        }

        public void SetAccountId()
        {
            var internalAccountId = GetDataAsString($"Select top (1) Id  from [employer_account].[Account] Where [ApprenticeshipEmployerType] = 1  order by Id desc");
            _objectContext.SetAccountId(internalAccountId);
        }

        public void SetLegalEntityId()
        {
            var legalEntityId = GetDataAsString($"SELECT  top (1) LegalEntityId FROM [employer_account].[AccountLegalEntity]  Where AccountId = {_objectContext.GetAccountId()}");
            _objectContext.SetLegalEntityId(legalEntityId);
        }

        public void SetPayeSchemeRef()
        {
            var payeScheme = GetDataAsString($"Select TOP 1 paye.Ref  from employer_account.Paye paye  INNER JOIN employer_account.AccountHistory ah ON ah.PayeRef = paye.Ref " +
                $"INNER JOIN employer_account.account a ON a.Id = ah.AccountId WHERE a.HashedId = '{_objectContext.GetHashedAccountId()}'");
            _objectContext.SetPayeSchemeRef(payeScheme);
        }

        public List<object[]> GetAgreementId()
        {
            var agreementId = GetListOfDataAsObject(
                $"	SELECT ale.PublicHashedId as AccountLegalEntityPublicHashedId , ea.Id" +
                $"  FROM [employer_account].[EmployerAgreement] ea" +
                $"  JOIN[employer_account].[AccountLegalEntity] ale " +
                $"  ON ale.Id = ea.AccountLegalEntityId " +
                $"  AND ale.Deleted IS NULL " +
                $"  JOIN[employer_account].[LegalEntity] le  ON le.Id = ale.LegalEntityId" +
                $"  JOIN[employer_account].[EmployerAgreementTemplate] eat  ON eat.Id = ea.TemplateId " +
                $"  JOIN[employer_account].Account acc  on  acc.Id = ale.AccountId" +
                $"  WHERE acc.Id = {_objectContext.GetAccountId()} AND ea.ExpiredDate is Null ");

            return agreementId;
        }

        public string GetUserRef()
        {
            return GetDataAsString("Select top 1 UserRef from [employer_account].[User] order by Id desc");
        }

        public string GetUserEmail()
        {
            return GetDataAsString("Select top 1 Email from [employer_account].[User] order by Id desc");
        }    
    }
}
