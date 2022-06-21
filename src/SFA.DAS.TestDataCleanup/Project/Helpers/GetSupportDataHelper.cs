namespace SFA.DAS.TestDataCleanup.Project.Helpers;

public class GetSupportDataHelper
{
    private readonly DbConfig _dbConfig;

    public GetSupportDataHelper(DbConfig dbConfig) => _dbConfig = dbConfig;

    internal List<string[]> GetApprenticeIds(List<string> accountidsTodelete) => new TestDataCleanupComtSqlDataHelper(_dbConfig).GetApprenticeIds(accountidsTodelete);
}
