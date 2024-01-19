namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;


public class TestDataCleanupComtSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.CommitmentsDbConnectionString)
{
    public override string SqlFileName => "EasComtTestDataCleanUp";

    internal List<string[]> GetApprenticeIds(List<string> accountidsTodelete)
    {
        return GetMultipleData($"select a.id from Apprenticeship a Join Commitment c on c.id = a.CommitmentId and c.EmployerAccountId in ({string.Join(",", accountidsTodelete)})");
    }

    public (List<string>, List<string>) CleanUpComtTestData(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return CleanUpTestData(() => GetComtAccountids(greaterThan, lessThan, easaccountidsnottodelete), (x) => CleanUpComtTestData(x));
    }

    internal int CleanUpComtTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetComtAccountids(int greaterThan, int lessThan, List<string> easaccountidsnottodelete)
    {
        return GetAccountids($"select id from dbo.Accounts where id > {greaterThan} and id < {lessThan} and id not in ({string.Join(",", easaccountidsnottodelete)}) order by id desc");
    }
}
