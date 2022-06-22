namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAppfbqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    private readonly DbConfig _dbConfig;

    public override string SqlFileName => "EasAppfbTestDataCleanUp";

    public TestDataCleanupAppfbqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeFeedbackDbConnectionString) => _dbConfig = dbConfig;

    internal int CleanUpAppfbTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAppfbTestData(List<string> accountIdToDelete) => CleanUpAppfbTestData(new GetSupportDataHelper(_dbConfig).GetApprenticeIds(accountIdToDelete));
}
