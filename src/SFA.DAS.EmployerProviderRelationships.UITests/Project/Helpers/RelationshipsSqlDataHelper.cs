using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class RelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
    {
        public void DeleteProviderRelation(string ukprn, string accountid, string empemail)
        {
            var sqlQuery = $"DECLARE @ukprn INT = {ukprn}, @accountid INT = {accountid}, @empemail NVARCHAR(255) = '{empemail}';" + FileHelper.GetSql("DeleteProviderRelation");

            ReTryExecuteSqlCommand(sqlQuery);
        }

        public string GetRequestId(string ukprn, string empemail) => GetDataAsString($"select id from Requests where ukprn = {ukprn} and EmployerContactEmail = '{empemail}'");
    }
}
