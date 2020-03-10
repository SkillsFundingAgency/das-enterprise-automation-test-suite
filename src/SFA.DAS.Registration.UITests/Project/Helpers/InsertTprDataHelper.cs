using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal static class InsertTprDataHelper
    {
        static readonly object _object = new object();

        internal static string InsertTprData(string connectionString, string aornValue, string payescheme, string orgType)
        {
            lock (_object)
            {
                int tprUniqueId = ReadDataFromDataBase(connectionString, "SELECT MAX([TPRUniqueId]) FROM [Tpr].[Organisation]") + 1;

                var organisationName = $"AutomationTestFor{orgType}Aorn{tprUniqueId}";

                ExecuteSqlCommand(connectionString, "INSERT INTO[Tpr].[Organisation] ([TPRUniqueId],[OrganisationName],[AORN],[DistrictNumber],[Reference],[AODistrict],[AOTaxType],[AOCheckChar],[AOReference],[RecordCreatedDate]) " +
                $"VALUES ({tprUniqueId}, '{organisationName}', '{aornValue}', '1', '1', 1, '1', '1', '1', '2020-01-01 00:00:00.0000000')");

                var orgSK = ReadDataFromDataBase(connectionString, $"SELECT [OrgSK] FROM [Tpr].[Organisation] where [TPRUniqueId] = {tprUniqueId}");

                ExecuteSqlCommand(connectionString, "INSERT INTO [Tpr].[OrganisationAddress] ([OrgSK],[TPRUniqueID],[OrganisationFullAddress],[AddressLine1],[AddressLine2],[AddressLine3],[PostCode],[RecordCreatedDate]) " +
                $"VALUES ({orgSK}, {tprUniqueId}, 'AutomationTestAddress{tprUniqueId}', '{tprUniqueId}', 'Test Street', 'Coventry', 'CV1 2WT', '2020-01-01 00:00:00.0000000')");

                ExecuteSqlCommand(connectionString, "INSERT INTO [Tpr].[OrganisationPAYEScheme] ([OrgSK],[TPRUniqueID],[PAYEScheme],[SchemeStartDate],[RecordCreatedDate]) " +
                $"VALUES ({orgSK}, {tprUniqueId}, '{payescheme}', '2020-01-01', '2020-01-01 00:00:00.0000000')");

                return organisationName;
            }
        }

        private static int ReadDataFromDataBase(string connectionString, string queryToExecute) => Convert.ToInt32(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);

        private static void ExecuteSqlCommand(string connectionString, string queryToExecute) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(connectionString, queryToExecute);
    }
}
