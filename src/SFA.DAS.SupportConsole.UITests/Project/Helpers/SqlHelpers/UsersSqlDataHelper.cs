
namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers
{
    public class UsersSqlDataHelper : SqlDbHelper
    {
        public UsersSqlDataHelper(DbConfig dbConfig) : base(dbConfig.UsersDbConnectionString) { }

        public void ReinstateAccountInDb(string email) => ExecuteSqlCommand($"UPDATE [User] SET IsSuspended = 0, LastSuspendedDate = null WHERE Email = '{email}'");
    }
}
