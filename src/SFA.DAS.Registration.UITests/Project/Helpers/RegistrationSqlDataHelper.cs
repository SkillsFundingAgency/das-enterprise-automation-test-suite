using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class RegistrationSqlDataHelper : SqlDbHelper
    {
        public RegistrationSqlDataHelper(RegistrationConfig registrationConfig) : base(registrationConfig.RE_AccountsDbConnectionString) { }

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
            SqlDatabaseConnectionHelper.ExecuteSqlCommand(connectionString, $"UPDATE [employer_account].[AccountLegalEntity] set Name = 'Changed Org Name' where AccountId = {accountId}");
        }
    }
}
