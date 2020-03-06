using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class RegistrationSqlDataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly string _accountDbConnectionString;
        private readonly string _tPRDbConnectionString;
        private readonly ObjectContext _objectContext;

        public RegistrationSqlDataHelper(RegistrationConfig registrationConfig, SqlDatabaseConnectionHelper sqlDatabase, ObjectContext objectContext)
        {
            _sqlDatabase = sqlDatabase;
            _accountDbConnectionString = registrationConfig.RE_AccountsDbConnectionString;
            _tPRDbConnectionString = registrationConfig.RE_TPRDbConnectionString;
            _objectContext = objectContext;
        }

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
            _sqlDatabase.ExecuteSqlCommand(_accountDbConnectionString, $"UPDATE [employer_account].[AccountLegalEntity] set Name = 'Changed Org Name' where AccountId = {accountId}");
        }

        public string GetAORNNumber(string org)
        {
            var tprUniqueId = GetMaxValueOfTPRUniqueId() + 1;
            var aORNValue = "A" + Get12DigitDateTimeValue();
            var organisationName = $"AutomationTestFor{org}Aorn{tprUniqueId}";
            _objectContext.UpdateOrganisationName(organisationName);
            TestContext.Progress.WriteLine($"AORN Number: {aORNValue}");

            EnterTPRData(tprUniqueId, organisationName, aORNValue);

            if (org.Equals("MultiOrg"))
            {
                tprUniqueId = GetMaxValueOfTPRUniqueId() + 1;
                organisationName = $"AutomationTestFor{org}Aorn{tprUniqueId}";
                EnterTPRData(tprUniqueId, organisationName, aORNValue);
            }

            return aORNValue;
        }

        private void EnterTPRData(int tprUniqueId, string organisationName, string aORNValue)
        {
            _sqlDatabase.ExecuteSqlCommand(_tPRDbConnectionString, "INSERT INTO[Tpr].[Organisation] " +
            "([TPRUniqueId],[OrganisationName],[AORN],[DistrictNumber],[Reference],[AODistrict],[AOTaxType],[AOCheckChar],[AOReference],[RecordCreatedDate]) " +
             $"VALUES ({tprUniqueId}, '{organisationName}', '{aORNValue}', '1', '1', 1, '1', '1', '1', '2020-01-01 00:00:00.0000000')");

            var orgSK = GetDataFromTprDb($"SELECT [OrgSK] FROM [Tpr].[Organisation] where [TPRUniqueId] = {tprUniqueId}");

            _sqlDatabase.ExecuteSqlCommand(_tPRDbConnectionString, "INSERT INTO [Tpr].[OrganisationAddress] " +
           "([OrgSK],[TPRUniqueID],[OrganisationFullAddress],[AddressLine1],[AddressLine2],[AddressLine3],[PostCode],[RecordCreatedDate]) " +
            $"VALUES ({orgSK}, {tprUniqueId}, 'AutomationTestAddress{tprUniqueId}', '{tprUniqueId}', 'Test Street', 'Coventry', 'CV1 2WT', '2020-01-01 00:00:00.0000000')");

            _sqlDatabase.ExecuteSqlCommand(_tPRDbConnectionString, "INSERT INTO [Tpr].[OrganisationPAYEScheme] ([OrgSK],[TPRUniqueID],[PAYEScheme],[SchemeStartDate],[RecordCreatedDate]) " +
            $"VALUES ({orgSK}, {tprUniqueId}, '{_objectContext.GetGatewayPaye()}', '2020-01-01', '2020-01-01 00:00:00.0000000')");
        }

        private string GetDataFromAccountsDb(string queryToExecute) => Convert.ToString(_sqlDatabase.ReadDataFromDataBase(queryToExecute, _accountDbConnectionString)[0][0]);

        private int GetDataFromTprDb(string queryToExecute) => Convert.ToInt32(_sqlDatabase.ReadDataFromDataBase(queryToExecute, _tPRDbConnectionString)[0][0]);

        private string Get12DigitDateTimeValue() => DateTime.Now.ToString("ddMMyyHHmmss");

        private int GetMaxValueOfTPRUniqueId() => GetDataFromTprDb("SELECT MAX([TPRUniqueId]) FROM [Tpr].[Organisation]");
    }
}
