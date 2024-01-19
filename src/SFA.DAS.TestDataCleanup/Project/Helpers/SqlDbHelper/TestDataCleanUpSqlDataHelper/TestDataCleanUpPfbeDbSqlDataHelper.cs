namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpPfbeDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.EmployerFeedbackDbConnectionString)
{
    public override string SqlFileName => "EasPfbeTestDataCleanUp";

    public (List<string>, List<string>) CleanUpPfbeTestData(int greaterThan, int lessThan, List<string> easaccountids)
    {
        return CleanUpTestData(() => GetPfbeAccountids(greaterThan, lessThan, easaccountids), (x) => CleanUpPfbeTestData(x));
    }

    internal int CleanUpPfbeTestData(List<string> accountIdToDelete) => CleanUpUsingAccountIds(accountIdToDelete);

    private List<string> GetPfbeAccountids(int greaterThan, int lessThan, List<string> easaccountids)
    {
        return GetAccountids($"select AccountId from dbo.EmployerEmailDetails where AccountId > {greaterThan} and AccountId < {lessThan} and AccountId not in ({string.Join(",", easaccountids)}) order by AccountId desc");
    }
}
