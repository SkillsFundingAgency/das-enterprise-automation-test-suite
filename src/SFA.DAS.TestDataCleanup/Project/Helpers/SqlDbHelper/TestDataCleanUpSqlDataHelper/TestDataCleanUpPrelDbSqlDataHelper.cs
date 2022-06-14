namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpPrelDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EasPrelTestDataCleanUp";

    public TestDataCleanUpPrelDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.PermissionsDbConnectionString) { }

    public (List<string>, List<string>) CleanUpPrelTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetPrelAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpPrelTestData(x));
    }

    internal int CleanUpPrelTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetPrelAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select Id from dbo.Accounts where Id > {greaterThan} and id < {lessThan} and Id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
    }
}
