using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Helpers.SqlDbHelpers
{
    public class EmployerAccountsSqlDbHelper : SqlDbHelper
    {        
        private readonly ObjectContext _objectContext;

        public EmployerAccountsSqlDbHelper(DbConfig dbConfig, ObjectContext objectContext) : base(dbConfig.AccountsDbConnectionString)
        {
            _objectContext = objectContext;
        }

        public void SetHashedAccountId()
        {
            var hashedAccountId = GetDataAsString($"SELECT TOP (1) a.HashedId" +
                $" FROM [employer_account].[Paye] paye" +
                $" INNER JOIN [employer_account].[AccountHistory] ah ON ah.PayeRef = paye.Ref" +
                $" INNER JOIN [employer_account].[Account] a ON a.Id = ah.AccountId" +
                $" WHERE paye.Ref IS NOT NULL AND a.[ApprenticeshipEmployerType] = 1 ORDER BY NEWID()");
            _objectContext.SetHashedAccountId(hashedAccountId);
        }

        public void SetAccountId()
        {
            var accountId = GetDataAsString($"SELECT TOP (1) Id" +
                $" FROM [employer_account].[Account] a" +
                $" WHERE a.HashedId = '{_objectContext.GetHashedAccountId()}' ORDER BY Id DESC");
            _objectContext.SetAccountId(accountId);
        }

        public void SetLegalEntityId()
        {
            var legalEntityId = GetDataAsString($"SELECT TOP (1) LegalEntityId" +
                $" FROM [employer_account].[AccountLegalEntity] ale" +
                $" INNER JOIN [employer_account].[Account] a on ale.AccountId = a.Id" + 
                $" WHERE a.HashedId = '{_objectContext.GetHashedAccountId()}'");
            _objectContext.SetLegalEntityId(legalEntityId);
        }

        public void SetPayeSchemeRef()
        {
            var payeScheme = GetDataAsString($"SELECT TOP 1 paye.Ref" +
                $" FROM [employer_account].[Paye] paye" +
                $" INNER JOIN [employer_account].[AccountHistory] ah ON ah.PayeRef = paye.Ref" +
                $" INNER JOIN [employer_account].[Account] a ON a.Id = ah.AccountId" +
                $" WHERE a.HashedId = '{_objectContext.GetHashedAccountId()}'");
            _objectContext.SetPayeSchemeRef(payeScheme);
        }

        public List<object[]> GetAgreementInfo()
        {
            var agreementId = GetListOfDataAsObject(
                $"	SELECT ale.PublicHashedId as AccountLegalEntityPublicHashedId, ea.Id as EmployerAgreementId" +
                $"  FROM [employer_account].[EmployerAgreement] ea" +
                $"  JOIN [employer_account].[AccountLegalEntity] ale" +
                $"  ON ale.Id = ea.AccountLegalEntityId" +
                $"  AND ale.Deleted IS NULL" +
                $"  JOIN [employer_account].[LegalEntity] le ON le.Id = ale.LegalEntityId" +
                $"  JOIN [employer_account].[EmployerAgreementTemplate] eat ON eat.Id = ea.TemplateId" +
                $"  JOIN [employer_account].[Account] a on a.Id = ale.AccountId" +
                $"  WHERE a.HashedId = '{_objectContext.GetHashedAccountId()}' AND ea.ExpiredDate IS NULL");

            return agreementId;
        }

        public string GetUserRef()
        {
            return GetDataAsString("SELECT TOP 1 UserRef" +
                " FROM [employer_account].[User] ORDER BY Id DESC");
        }

        public string GetUserEmail()
        {
            return GetDataAsString("SELECT TOP 1 Email" +
                " FROM [employer_account].[User] WHERE email NOT LIKE '%+%' ORDER BY Id DESC");
        }
    }
}
