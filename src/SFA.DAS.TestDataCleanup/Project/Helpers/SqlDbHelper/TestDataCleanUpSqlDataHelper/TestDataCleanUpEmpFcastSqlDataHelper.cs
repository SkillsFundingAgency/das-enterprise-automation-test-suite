namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpEmpFcastSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EasFcastTestDataCleanUp";

    public TestDataCleanUpEmpFcastSqlDataHelper(DbConfig dbConfig) : base(dbConfig.FcastDbConnectionString) { }

    public (List<string>, List<string>) CleanUpEmpFcastTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetEmpFcastAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpEmpFcastTestData(x));
    }

    internal int CleanUpEmpFcastTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetEmpFcastAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select distinct EmployerAccountId from dbo.Commitment where EmployerAccountId > {greaterThan} and EmployerAccountId < {lessThan} and EmployerAccountId not in ({string.Join(",", easaccountidsnottodelete)}) order by EmployerAccountId desc");
    }
}
