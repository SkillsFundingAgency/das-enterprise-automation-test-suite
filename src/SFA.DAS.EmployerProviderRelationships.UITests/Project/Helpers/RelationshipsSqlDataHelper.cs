using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    public class RelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
    {
        public void DeleteProviderRelation(string ukprn, string accountid, string empemail)
        {
            var sqlQuery = $"DECLARE @ukprn INT = {ukprn}, @accountid INT = {accountid}, @empemail VARCHAR(32) = '{empemail}';" + FileHelper.GetSql("DeleteProviderRelation");

            ReTryExecuteSqlCommand(sqlQuery);
        }
    }
}
