namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAppfbqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    private readonly DbConfig _dbConfig;

    public override string SqlFileName => "EasAppfbTestDataCleanUp";

    private readonly ObjectContext _objectContext;

    public TestDataCleanupAppfbqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApprenticeFeedbackDbConnectionString)
    {
        _dbConfig = dbConfig;
        _objectContext = objectContext;
    }

    internal int CleanUpAppfbTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAppfbTestData(List<string> accountIdToDelete) => CleanUpAppfbTestData(new GetSupportDataHelper(_objectContext, _dbConfig).GetApprenticeIds(accountIdToDelete));
}
