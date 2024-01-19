namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAComtSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.ApprenticeCommitmentDbConnectionString)
{
    public override string SqlFileName => "EasAComtTestDataCleanUp";

    private readonly ObjectContext _objectContext = objectContext;

    internal int CleanUpAComtTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAComtTestData(List<string> accountIdToDelete) => CleanUpAComtTestData(new GetSupportDataHelper(_objectContext, dbConfig).GetApprenticeIds(accountIdToDelete));
}
