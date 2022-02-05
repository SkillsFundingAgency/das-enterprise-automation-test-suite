using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationSqlDataHelper : SqlDbHelper
    {
        public RegistrationSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        public string GetAccountApprenticeshipEmployerType(string email) => GetDataAsString($"SELECT ApprenticeshipEmployerType FROM [employer_account].[Account] WHERE Id IN {GetAccountIdQuery(email)} ORDER BY CreatedDate");

        public void UpdateLegalEntityName(string email) => ExecuteSqlCommand($"UPDATE [employer_account].[AccountLegalEntity] SET [Name] = 'Changed Org Name' WHERE AccountId IN {GetAccountIdQuery(email)}");

        public string GetAccountLegalEntityPublicHashedId(string accountid, string orgname) => GetDataAsString($"select PublicHashedId from [employer_account].[AccountLegalEntity] where AccountId = {accountid} and [Name] = '{orgname}'");

        public string GetAccountId(string email) => GetDataAsString(GetAccountIdQuery(email));

        public (string accountId, string hashedId, string orgName, string publicHashedId) CollectAccountDetails(string email)
        {
            static string Join(List<string> list) => string.Join(",", list);

            var ids = CollectAccountDetailsAsList(email);

            List<string> accountId = new List<string>();
            List<string> hashedId = new List<string>();
            List<string> orgName = new List<string>();
            List<string> publicHashedId = new List<string>();

            foreach ((string accountId, string hashedId, string orgName, string publicHashedId) id in ids)
            {
                accountId.Add(id.accountId);
                hashedId.Add(id.hashedId);
                orgName.Add(id.orgName);
                publicHashedId.Add(id.publicHashedId);
            }

            return (Join(accountId), Join(hashedId), Join(orgName), Join(publicHashedId));
        }

        public List<(string accountId, string hashedId, string orgName, string publicHashedId)> CollectAccountDetailsAsList(string email)
        {
            var id = GetMultipleData($"SELECT id, HashedId, [Name], PublicHashedId FROM [employer_account].[Account] WHERE id IN {GetAccountIdQuery(email)} ORDER BY CreatedDate");

            var list = new List<(string accountId, string hashedId, string orgName, string publicHashedId)>();

            for (int i = 0; i < id.Count; i++) list.Add((id[i][0], id[i][1], id[i][2], id[i][3]));

            return list;
        }

        private string GetAccountIdQuery(string email) => $"(SELECT AccountId FROM [employer_account].[Membership] m JOIN [employer_account].[User] u ON u.Id = m.UserId AND u.Email = '{email}')";
    }
}
