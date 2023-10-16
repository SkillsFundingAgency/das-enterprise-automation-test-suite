namespace SFA.DAS.TestDataCleanup.Project.Helpers;

public class GetSupportDataHelper
{
    private readonly DbConfig _dbConfig;

    private readonly ObjectContext _objectContext;

    public GetSupportDataHelper(ObjectContext objectContext, DbConfig dbConfig)
    {
        _dbConfig = dbConfig;
        _objectContext = objectContext;
    }

    internal List<string[]> GetApprenticeIds(List<string> accountidsTodelete) => new TestDataCleanupComtSqlDataHelper(_objectContext, _dbConfig).GetApprenticeIds(accountidsTodelete);
}
