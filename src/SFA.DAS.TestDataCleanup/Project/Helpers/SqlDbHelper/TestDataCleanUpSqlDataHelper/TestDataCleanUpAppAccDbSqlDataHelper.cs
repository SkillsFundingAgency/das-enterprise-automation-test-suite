namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpAppAccDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper(objectContext, dbConfig.ApprenticeCommitmentAccountsDbConnectionString)
{
    public override string SqlFileName => "EasAppAccTestDataCleanUp";

    internal int CleanUpAppAccDbTestData(List<string> emailsToDelete) => CleanUpUsingEmail(emailsToDelete);
}