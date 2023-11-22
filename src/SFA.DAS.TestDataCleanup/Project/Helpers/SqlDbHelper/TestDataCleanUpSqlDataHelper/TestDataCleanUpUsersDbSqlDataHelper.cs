namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpUsersDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EasUsersTestDataCleanUp";

    public TestDataCleanUpUsersDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.UsersDbConnectionString) { }

    internal int CleanUpUsersDbTestData(List<string> emailsToDelete) => CleanUpUsingEmail(emailsToDelete);
}
