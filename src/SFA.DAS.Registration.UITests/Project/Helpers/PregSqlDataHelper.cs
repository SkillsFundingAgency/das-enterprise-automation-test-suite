using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class PregSqlDataHelper : SqlDbHelper
    {
        private string _email;

        public PregSqlDataHelper(ProviderLeadRegistrationConfig config): base(config.RE_PregDbConnectionString) { }

        public string GetReference(string email)
        {
            _email = email;
            return GetData($"SELECT [Reference] FROM [dbo].[Invitations] where EmployerEmail = '{email}'");
        }

        public void DeleteInvitation(string email) => SqlDatabaseConnectionHelper.ExecuteSqlCommand(connectionString, $"Delete FROM [dbo].[Invitations] where EmployerEmail = '{email}'");
    }
}
