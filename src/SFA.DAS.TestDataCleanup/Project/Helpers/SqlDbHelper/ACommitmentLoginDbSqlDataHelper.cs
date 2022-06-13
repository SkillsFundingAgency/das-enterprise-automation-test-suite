namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;

public class ACommitmentLoginDbSqlDataHelper : ProjectSqlDbHelper
{
    public ACommitmentLoginDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.ApprenticeCommitmentLoginDbConnectionString) { }
}