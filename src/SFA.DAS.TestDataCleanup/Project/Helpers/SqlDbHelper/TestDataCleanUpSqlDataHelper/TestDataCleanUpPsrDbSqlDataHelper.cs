namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpPsrDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    private readonly DbConfig _dbConfig;

    public override string SqlFileName => "EasPsrTestDataCleanUp";

    private readonly ObjectContext _objectContext;

    public TestDataCleanUpPsrDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.PublicSectorReportingConnectionString)
    {
        _dbConfig = dbConfig;
        _objectContext = objectContext;
    }

    internal int CleanUpPsrTestData(List<string> accountIdToDelete)
    {
        var easaccounthashedids = new TestDataCleanUpEasAccDbSqlDataHelper(_objectContext, _dbConfig).GetAccountHashedIds(accountIdToDelete);

        if (easaccounthashedids.IsNoDataFound()) return 0;

        return CleanUpTestData(easaccounthashedids.ListOfArrayToList(0), (x) => $"Insert into #accounthashedids values ('{x}')", "create table #accounthashedids (id nvarchar(255))");
    }
}
