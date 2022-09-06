namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAComtSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    private readonly DbConfig _dbConfig;

    public override string SqlFileName => "EasAComtTestDataCleanUp";

    public TestDataCleanupAComtSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentDbConnectionString) => _dbConfig = dbConfig;

    internal int CleanUpAComtTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAComtTestData(List<string> accountIdToDelete) => CleanUpAComtTestData(new GetSupportDataHelper(_dbConfig).GetApprenticeIds(accountIdToDelete));
}
