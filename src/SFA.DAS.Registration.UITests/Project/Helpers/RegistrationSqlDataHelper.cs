using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.AccountsDbConnectionString)
    {
        public string GetAccountApprenticeshipEmployerType(string email) => GetDataAsString($"SELECT ApprenticeshipEmployerType FROM [employer_account].[Account] WHERE Id IN {GetAccountIdQuery(email)} ORDER BY CreatedDate");

        public void UpdateLegalEntityName(string email) => ExecuteSqlCommand($"UPDATE [employer_account].[AccountLegalEntity] SET [Name] = 'Changed Org Name' WHERE AccountId IN {GetAccountIdQuery(email)}");

        public string GetAccountLegalEntityPublicHashedId(string accountid, string orgname) => GetDataAsString($"select PublicHashedId from [employer_account].[AccountLegalEntity] where AccountId = {accountid} and [Name] = '{orgname}'");

        public string GetAccountLegalEntityId(string accountid, string orgname) => GetDataAsString($"select Id from [employer_account].[AccountLegalEntity] where AccountId = {accountid} and [Name] = '{orgname}'");

        public List<(string accountId, string hashedId, string orgName, string publicHashedId, string alename, string aleid, string aleAccountid, string aleAgreementid)> CollectAccountDetails(string email)
        {
            waitForResults = true;

            var id = GetMultipleData(GetAccountInitialQuery(email));

            var list = new List<(string accountId, string hashedId, string orgName, string publicHashedId, string alename, string aleid, string aleAccountid, string aleAgreementid)>();

            for (int i = 0; i < id.Count; i++) list.Add((id[i][0], id[i][1], id[i][2], id[i][3], id[i][4], id[i][5], id[i][6], id[i][7]));

            return list;
        }

        private static string GetAccountIdQuery(string email) => $"(SELECT AccountId FROM [employer_account].[Membership] m JOIN [employer_account].[User] u ON u.Id = m.UserId AND u.Email = '{email}')";

        private static string GetAccountInitialQuery(string email)
        {
            return $@"select a.id, a.HashedId, a.[Name], a.PublicHashedId, ale.[name], ale.id as aleid, ale.AccountId, ale.PublicHashedId as agreementid from employer_account.[User] u
                    join employer_account.Membership m on u.id = m.UserId join employer_account.Account a on a.id = m.AccountId join employer_account.AccountLegalEntity ale on ale.AccountId = a.Id
                    where u.Email = '{email}' order by a.CreatedDate";
        }
    }
}
