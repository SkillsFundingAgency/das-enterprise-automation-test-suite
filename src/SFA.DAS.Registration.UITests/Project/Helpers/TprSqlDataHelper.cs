using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class TprSqlDataHelper
    {
        private readonly SqlDatabaseConnectionHelper _sqlDatabase;
        private readonly string _tPRDbConnectionString;
        private readonly ObjectContext _objectContext;
        private readonly string _aORNValue;
        private readonly string _payescheme;

        static readonly object _object = new object();

        public TprSqlDataHelper(TprConfig tprConfig, SqlDatabaseConnectionHelper sqlDatabase, ObjectContext objectContext)
        {
            _sqlDatabase = sqlDatabase;
            _tPRDbConnectionString = tprConfig.RE_TPRDbConnectionString;
            _objectContext = objectContext;
            _payescheme = objectContext.GetGatewayPaye();
            _aORNValue = $"A{DateTime.Now.ToString("ddMMyyHHmmss")}";
            _objectContext.SetAornNumber(_aORNValue);
        }

        public void CreateSingleOrgAornData() => EnterTPRData("SingleOrg");

        public void CreateMultiOrgAORNData()
        {
            EnterTPRData("MultiOrg");
            EnterTPRData("MultiOrg");
        }

        private void EnterTPRData(string orgType)
        {
            lock (_object)
            {
                int tprUniqueId = ReadDataFromDataBase("SELECT MAX([TPRUniqueId]) FROM [Tpr].[Organisation]") + 1;

                var organisationName = $"AutomationTestFor{orgType}Aorn{tprUniqueId}";

                _objectContext.UpdateOrganisationName(organisationName);

                ExecuteSqlCommand("INSERT INTO[Tpr].[Organisation] ([TPRUniqueId],[OrganisationName],[AORN],[DistrictNumber],[Reference],[AODistrict],[AOTaxType],[AOCheckChar],[AOReference],[RecordCreatedDate]) " +
                $"VALUES ({tprUniqueId}, '{organisationName}', '{_aORNValue}', '1', '1', 1, '1', '1', '1', '2020-01-01 00:00:00.0000000')");

                var orgSK = ReadDataFromDataBase($"SELECT [OrgSK] FROM [Tpr].[Organisation] where [TPRUniqueId] = {tprUniqueId}");

                ExecuteSqlCommand("INSERT INTO [Tpr].[OrganisationAddress] ([OrgSK],[TPRUniqueID],[OrganisationFullAddress],[AddressLine1],[AddressLine2],[AddressLine3],[PostCode],[RecordCreatedDate]) " +
                $"VALUES ({orgSK}, {tprUniqueId}, 'AutomationTestAddress{tprUniqueId}', '{tprUniqueId}', 'Test Street', 'Coventry', 'CV1 2WT', '2020-01-01 00:00:00.0000000')");

                ExecuteSqlCommand("INSERT INTO [Tpr].[OrganisationPAYEScheme] ([OrgSK],[TPRUniqueID],[PAYEScheme],[SchemeStartDate],[RecordCreatedDate]) " +
                $"VALUES ({orgSK}, {tprUniqueId}, '{_payescheme}', '2020-01-01', '2020-01-01 00:00:00.0000000')");
            }
        }

        private int ReadDataFromDataBase(string queryToExecute) => Convert.ToInt32(_sqlDatabase.ReadDataFromDataBase(queryToExecute, _tPRDbConnectionString)[0][0]);

        private void ExecuteSqlCommand(string queryToExecute) => _sqlDatabase.ExecuteSqlCommand(_tPRDbConnectionString, queryToExecute);
    }
}
