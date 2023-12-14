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

        public List<(string accountId, string hashedId, string orgName, string publicHashedId)> CollectAccountDetails(string email)
        {
            waitForResults = true;

            var id = GetMultipleData($"SELECT id, HashedId, [Name], PublicHashedId FROM [employer_account].[Account] WHERE id IN {GetAccountIdQuery(email)} ORDER BY CreatedDate");

            var list = new List<(string accountId, string hashedId, string orgName, string publicHashedId)>();

            for (int i = 0; i < id.Count; i++) list.Add((id[i][0], id[i][1], id[i][2], id[i][3]));

            return list;
        }

        private static string GetAccountIdQuery(string email) => $"(SELECT AccountId FROM [employer_account].[Membership] m JOIN [employer_account].[User] u ON u.Id = m.UserId AND u.Email = '{email}')";
    }
}
