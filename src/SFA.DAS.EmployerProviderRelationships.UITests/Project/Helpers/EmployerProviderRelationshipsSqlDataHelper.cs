using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers
{
    internal class EmployerProviderRelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
    {
        public void DeleteProviderRelation(string ukprn, string accountid) 
        {
            var sqlQuery = $"DECLARE @ukprn INT = {ukprn}, @accountid INT = {accountid};" + FileHelper.GetSql("DeleteProviderRelation");

            ReTryExecuteSqlCommand(sqlQuery);
        }
    }
}
