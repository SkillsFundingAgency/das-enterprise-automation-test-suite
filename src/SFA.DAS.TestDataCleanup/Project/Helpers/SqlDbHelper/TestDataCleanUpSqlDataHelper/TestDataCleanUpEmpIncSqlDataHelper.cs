namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpEmpIncSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EmpIncTestDataCleanUp";

    public override bool ExcludeEnvironments => EnvironmentConfig.IsDemoEnvironment;

    public TestDataCleanUpEmpIncSqlDataHelper(DbConfig dbConfig) : base(dbConfig.IncentivesDbConnectionString) { }

    public (List<string>, List<string>) CleanUpEmpIncTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetEmpIncAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpIncTestData(x));
    }

    internal int CleanUpEmpIncTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetEmpIncAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
    }
}
