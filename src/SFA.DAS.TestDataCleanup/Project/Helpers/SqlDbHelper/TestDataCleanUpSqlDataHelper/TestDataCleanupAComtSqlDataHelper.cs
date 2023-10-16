using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanupAComtSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    private readonly DbConfig _dbConfig;

    public override string SqlFileName => "EasAComtTestDataCleanUp";

    private readonly ObjectContext _objectContext;

    public TestDataCleanupAComtSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApprenticeCommitmentDbConnectionString)
    {
        _dbConfig = dbConfig;
        _objectContext = objectContext;
    }

    internal int CleanUpAComtTestData(List<string[]> apprenticeIds) => CleanUpUsingCommtApprenticeshipIds(apprenticeIds);

    internal int CleanUpAComtTestData(List<string> accountIdToDelete) => CleanUpAComtTestData(new GetSupportDataHelper(_objectContext, _dbConfig).GetApprenticeIds(accountIdToDelete));
}
