namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpUsersDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.UsersDbConnectionString)
{
    public override string SqlFileName => "EasUsersTestDataCleanUp";

    internal int CleanUpUsersDbTestData(List<string> emailsToDelete) => CleanUpUsingEmail(emailsToDelete);
}
