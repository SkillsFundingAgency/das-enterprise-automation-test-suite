namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpEasLtmcSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.TMDbConnectionString)
{
    public override string SqlFileName => "EasLtmTestDataCleanUp";

    public (List<string>, List<string>) CleanUpEasLtmTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetEasLtmAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEasLtmTestData(x));
    }

    internal int CleanUpEasLtmTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetEasLtmAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select id from dbo.EmployerAccount where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
    }
}
