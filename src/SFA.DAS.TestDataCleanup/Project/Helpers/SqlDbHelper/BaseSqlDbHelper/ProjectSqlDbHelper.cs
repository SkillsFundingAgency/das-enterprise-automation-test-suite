namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

public abstract class ProjectSqlDbHelper : FrameworkHelpers.SqlDbHelper
{
    public readonly string dbName;

    public virtual bool ExcludeEnvironments => false;

    protected ProjectSqlDbHelper(ObjectContext objectContext, string connectionString) : base(objectContext, connectionString) => dbName = GetDbName();

    public string GetTableCatalog() => GetDataAsString("select top 1 TABLE_CATALOG from INFORMATION_SCHEMA.TABLES");

    public string GetCaller() => GetType().Name;

    protected List<string> GetAccountids(string query) => GetMultipleData(query).ListOfArrayToList(0);

    protected List<string[]> GetMultipleAccountData(string sqlQuery)
    {
        var id = GetMultipleData(sqlQuery);

        if (id.IsNoDataFound()) id[0][0] = "0";

        return id;
    }

    private string GetDbName()
    {
        var list = connectionString.Split(";");

        var dbName = list.Any(x => x.StartsWith("Database")) ? list.SingleOrDefault(x => x.StartsWith("Database")) : list.SingleOrDefault(x => x.StartsWith("Initial Catalog"));

        return dbName.Split("=")[1];
    }
}
