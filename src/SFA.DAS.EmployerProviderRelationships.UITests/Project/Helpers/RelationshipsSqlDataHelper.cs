namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

public class RelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
{
    public void DeleteProviderRelation(string ukprn, string accountid, string empemail)
    {
        var sqlQuery = $"DECLARE @ukprn INT = {ukprn}, @accountid INT = {accountid}, @empemail NVARCHAR(255) = '{empemail}';" + FileHelper.GetSql("DeleteProviderRelation");

        ReTryExecuteSqlCommand(sqlQuery);
    }

    public void DeleteProviderRequest(string requestId) => ReTryExecuteSqlCommand($"delete from Requests where id = '{requestId}'");
    
    public (string requestId, string requestStatus) GetRequestId(string ukprn, string empemail)
    {
        var data = GetData($"select id, [Status] from Requests where ukprn = {ukprn} and EmployerContactEmail = '{empemail}'");

        return (data[0], data[1]);
    }
}
