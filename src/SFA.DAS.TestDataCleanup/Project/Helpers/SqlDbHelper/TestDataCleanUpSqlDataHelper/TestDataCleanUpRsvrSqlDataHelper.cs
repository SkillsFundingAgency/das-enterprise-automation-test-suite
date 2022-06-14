namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpRsvrSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EasRsrvTestDataCleanUp";

    public TestDataCleanUpRsvrSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ReservationsDbConnectionString) { }

    public (List<string>, List<string>) CleanUpRsvrTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetRsvrAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpRsvrTestData(x));
    }

    internal int CleanUpRsvrTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetRsvrAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select id from dbo.Account where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
    }
}
