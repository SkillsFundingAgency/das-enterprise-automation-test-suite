
namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers
{
    public class UsersSqlDataHelper : SqlDbHelper
    {
        public UsersSqlDataHelper(DbConfig dbConfig) : base(dbConfig.UsersDbConnectionString) { }

        public void ReinstateAccountInDb(string email)
        {
            var query =     $@"UPDATE [User] 
                            SET IsSuspended = 0, LastSuspendedDate = null
                            WHERE Email = '{email}'";

            ExecuteSqlCommand(query);
        }

    }
}
