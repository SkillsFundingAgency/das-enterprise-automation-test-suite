using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper : SqlDbHelper
    {
        public LoginInvitationsSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.LoginDatabaseConnectionString) { }
        public string GetIdFromLoginDB(string email) => GetData($"select Id FROM [LoginService].[Invitations] where email = '{email}'");
    }
}
