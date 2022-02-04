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

            var id = GetMultipleData($"SELECT id, HashedId, [Name], PublicHashedId FROM [employer_account].[Account] WHERE id IN {GetAccountIdQuery(email)} ORDER BY CreatedDate");

            var list = new List<string>();
            List<string> accountId = list;
            List<string> hashedId = list;
            List<string> orgName = list;
            List<string> publicHashedId = list;

            for (int i = 0; i < id.Count; i++)
            {
                accountId.Add(id[i][0]);
                hashedId.Add(id[i][1]);
                orgName.Add(id[i][2]);
                publicHashedId.Add(id[i][3]);
            }

            return (Join(accountId), Join(hashedId), Join(orgName), Join(publicHashedId));
        }

        private string GetAccountIdQuery(string email) => $"(SELECT AccountId FROM [employer_account].[Membership] m JOIN [employer_account].[User] u ON u.Id = m.UserId AND u.Email = '{email}')";
    }
}
