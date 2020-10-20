using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class LoginInvitationsSqlDbHelper : SqlDbHelper
    {
        public LoginInvitationsSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.LoginDatabaseConnectionString) { }

        public string GetId(string email) => GetNullableData($"select Id FROM [LoginService].[Invitations] where email = '{email}'");

        public void DeleteUser(string email) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where email = '{email}'");
    }
}
