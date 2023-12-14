namespace SFA.DAS.TestDataCleanup.Project.Helpers;

public class GetSupportDataHelper(ObjectContext objectContext, DbConfig dbConfig)
{
    internal List<string[]> GetApprenticeIds(List<string> accountidsTodelete) => new TestDataCleanupComtSqlDataHelper(objectContext, dbConfig).GetApprenticeIds(accountidsTodelete);
}
