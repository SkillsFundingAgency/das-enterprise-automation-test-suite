namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class ACommitmentLoginDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : ProjectSqlDbHelper(objectContext, dbConfig.ApprenticeCommitmentLoginDbConnectionString)
{
}