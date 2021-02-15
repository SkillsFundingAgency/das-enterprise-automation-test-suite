namespace SFA.DAS.UI.FrameworkHelpers
{
    public abstract class InvitationsSqlDbHelper : SqlDbHelper
    {
        public InvitationsSqlDbHelper(string connectionString) : base(connectionString) { }

        public string GetId(string email) => GetNullableData($"select Id FROM [LoginService].[Invitations] where email = '{email}'");

        public void DeleteUser(string email) => ExecuteSqlCommand($"DELETE FROM [IdentityServer].[aspnetusers] where email = '{email}'");
    }
}
