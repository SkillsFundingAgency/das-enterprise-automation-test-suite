using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class RegistrationSqlDataHelper
    {
        private readonly string _accountDbConnectionString;

        public RegistrationSqlDataHelper(RegistrationConfig registrationConfig) => _accountDbConnectionString = registrationConfig.RE_AccountsDbConnectionString;

        public string GetAccountApprenticeshipEmployerType(string email)
        {
            var userId = GetDataFromAccountsDb($"SELECT Id from [employer_account].[User] where Email = '{email}'");
            var id = GetDataFromAccountsDb($"SELECT AccountId FROM[employer_account].[Membership] where UserId = {userId}");
            return GetDataFromAccountsDb($"SELECT ApprenticeshipEmployerType FROM [employer_account].[Account] where Id = {id}");
        }

        public void UpdateLegalEntityName(string email)
        {
            var id = GetDataFromAccountsDb($"SELECT Id from [employer_account].[User] where Email = '{email}'");
            var accountId = GetDataFromAccountsDb($"SELECT AccountId FROM [employer_account].[Membership] where UserId = {id}");
            SqlDatabaseConnectionHelper.ExecuteSqlCommand(_accountDbConnectionString, $"UPDATE [employer_account].[AccountLegalEntity] set Name = 'Changed Org Name' where AccountId = {accountId}");
        }

        private string GetDataFromAccountsDb(string queryToExecute) => Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, _accountDbConnectionString)[0][0]);
    }
}
