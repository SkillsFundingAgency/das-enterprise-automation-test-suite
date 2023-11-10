using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.UI.Framework.TestSupport.SqlHelpers;

public class UsersSqlDataHelper : SqlDbHelper
{
    public UsersSqlDataHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.UsersDbConnectionString) { }

    public void ReinstateAccountInDb(string email) => ExecuteSqlCommand($"UPDATE [User] SET IsSuspended = 0, LastSuspendedDate = null WHERE Email = '{email}'");

    public string GetUserId(string email) => GetDataAsString($"SELECT Id FROM dbo.[User] WHERE email = '{email}'");
}
