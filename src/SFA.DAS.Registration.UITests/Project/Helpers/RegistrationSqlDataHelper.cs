using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    class RegistrationSqlDataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly string _connectionString;

        public RegistrationSqlDataHelper(RegistrationConfig registrationConfig, SqlDatabaseConnectionHelper sqlDatabase)
        {
            _sqlDatabase = sqlDatabase;
            _connectionString = registrationConfig.RE_AccountsDbConnectionString;
        }

        public string GetAccountApprenticeshipEmployerType(string email)
        {
            var userId = GetDataFromDb($"SELECT Id from [employer_account].[User] where Email = '{email}'");
            var id = GetDataFromDb($"SELECT AccountId FROM[employer_account].[Membership] where UserId = {userId}");
            return GetDataFromDb($"SELECT ApprenticeshipEmployerType FROM [employer_account].[Account] where Id = {id}");
        }

        private string GetDataFromDb(string queryToExecute) =>  Convert.ToString(_sqlDatabase.ReadDataFromDataBase(queryToExecute, _connectionString)[0][0]);
    }
}
