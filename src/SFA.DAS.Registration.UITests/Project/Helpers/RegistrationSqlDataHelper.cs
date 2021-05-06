using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class RegistrationSqlDataHelper : SqlDbHelper
    {
        public RegistrationSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

        public string GetAccountApprenticeshipEmployerType(string email)
        {
            var userId = GetData($"SELECT Id from [employer_account].[User] where Email = '{email}'");
            var id = GetData($"SELECT AccountId FROM[employer_account].[Membership] where UserId = {userId}");
            return GetData($"SELECT ApprenticeshipEmployerType FROM [employer_account].[Account] where Id = {id}");
        }

        public void UpdateLegalEntityName(string email)
        {
            var id = GetData($"SELECT Id from [employer_account].[User] where Email = '{email}'");
            var accountId = GetData($"SELECT AccountId FROM [employer_account].[Membership] where UserId = {id}");
            ExecuteSqlCommand($"UPDATE [employer_account].[AccountLegalEntity] set Name = 'Changed Org Name' where AccountId = {accountId}");
        }

        public (string accountId, string hashedAccountId) GetAccountIds(string email)
        {
            var id = GetData($"select id,HashedId from employer_account.Account where id = " +
                $"(SELECT AccountId FROM[employer_account].[Membership] where UserId = " +
                $"(SELECT Id from [employer_account].[User] where Email = '{email}'))", 2);

            return (id[0], id[1]);
        }
    }
}
