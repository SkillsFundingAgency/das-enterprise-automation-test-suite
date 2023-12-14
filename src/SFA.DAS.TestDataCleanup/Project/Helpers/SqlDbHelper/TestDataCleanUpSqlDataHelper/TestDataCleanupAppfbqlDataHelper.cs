namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAppfbqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.ApprenticeFeedbackDbConnectionString)
{
    public override string SqlFileName => "EasAppfbTestDataCleanUp";

    private readonly ObjectContext _objectContext = objectContext;

    internal int CleanUpAppfbTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAppfbTestData(List<string> accountIdToDelete) => CleanUpAppfbTestData(new GetSupportDataHelper(_objectContext, dbConfig).GetApprenticeIds(accountIdToDelete));
}
