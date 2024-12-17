namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

public class RelationshipsSqlDataHelper(ObjectContext objectContext, DbConfig config) : SqlDbHelper(objectContext, config.PermissionsDbConnectionString)
{
    public void DeleteProviderRelation(string ukprn, string accountid, string empemail)
    {
        var sqlQuery = $"DECLARE @ukprn INT = {ukprn}, @accountid INT = {accountid}, @empemail NVARCHAR(255) = '{empemail}';" + FileHelper.GetSql("DeleteProviderRelation");

        ReTryExecuteSqlCommand(sqlQuery);
    }

    public void DeleteProviderRequest(List<string> requestId)
    {
        var requestIdquery = string.Join(',', requestId.ToHashSet().Select(x => $"'{x}'"));

        ReTryExecuteSqlCommand($"delete from notifications where RequestId in ({requestIdquery}); delete from PermissionRequests where RequestId in ({requestIdquery}); delete from Requests where id in ({requestIdquery});");
    }

    public (string requestId, string requestStatus) GetRequestId(string query)
    {
        var data = GetData(query);

        return (data[0], data[1]);
    }
}
