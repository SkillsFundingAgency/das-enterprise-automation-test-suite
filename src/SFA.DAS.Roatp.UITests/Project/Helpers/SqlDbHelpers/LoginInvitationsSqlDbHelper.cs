using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper : InvitationsSqlDbHelper
    {
        public LoginInvitationsSqlDbHelper(DbConfig dbConfig) : base(dbConfig.LoginDatabaseConnectionString) { }
    }
}
