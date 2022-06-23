using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal static class InsertTprDataHelper
    {
        private static readonly object _object = new();

        internal static string InsertTprData(string connectionString, string aornValue, string payescheme, string orgType)
        {
            var datetime = DateTime.Now;

            var queryToExecute = $"DECLARE @tprUniqueId bigint, @vartprid varchar(256), @organisationName varchar(256), @orgSK bigint; " +
                $"SELECT @tprUniqueId = (MAX([TPRUniqueId]) +1) FROM [Tpr].[Organisation];" +
                $"SET @vartprid = @tprUniqueId;" +
                $"SET @organisationName = 'AutomationTestFor{orgType}Aorn' + @vartprid;" +
                "INSERT INTO [Tpr].[Organisation] ([TPRUniqueId],[OrganisationName],[AORN],[DistrictNumber],[Reference],[AODistrict],[AOTaxType],[AOCheckChar],[AOReference],[RecordCreatedDate]) " +
                $"VALUES (@tprUniqueId, @organisationName, '{aornValue}', '1', '1', 1, '1', '1', '1', GETDATE());" +
                "SELECT @orgSK = [OrgSK] FROM [Tpr].[Organisation] where [TPRUniqueId] = @tprUniqueId;" +
                "INSERT INTO [Tpr].[OrganisationAddress] ([OrgSK],[TPRUniqueID],[OrganisationFullAddress],[AddressLine1],[AddressLine2],[AddressLine3],[PostCode],[RecordCreatedDate]) " +
                "VALUES (@orgSK, @tprUniqueId, @organisationName + 'Address', @tprUniqueId, 'Test Street', 'Coventry', 'CV1 2WT', GETDATE());" +
                "INSERT INTO [Tpr].[OrganisationPAYEScheme] ([OrgSK],[TPRUniqueID],[PAYEScheme],[SchemeStartDate],[RecordCreatedDate]) " +
                $"VALUES (@orgSK, @tprUniqueId, '{payescheme}', '{datetime.Year}-{datetime.Month}-{datetime.Day}', GETDATE()); " +
                $"SELECT @organisationName";



            lock (_object)
            {
                return Convert.ToString(SqlDatabaseConnectionHelper.ReadDataFromDataBase(queryToExecute, connectionString)[0][0]);
            }
        }
    }
}
