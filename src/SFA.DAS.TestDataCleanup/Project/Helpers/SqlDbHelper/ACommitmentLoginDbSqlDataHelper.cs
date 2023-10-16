namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class ACommitmentLoginDbSqlDataHelper : ProjectSqlDbHelper
{
    public ACommitmentLoginDbSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }
}