namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpPregDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.PregDbConnectionString)
{
    public override string SqlFileName => "EasPregTestDataCleanUp";

    internal int CleanUpPregDbTestData(List<string> emailsToDelete) => CleanUpUsingEmail(emailsToDelete);
}
