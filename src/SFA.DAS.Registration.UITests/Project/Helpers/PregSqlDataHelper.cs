using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class PregSqlDataHelper : SqlDbHelper
    {
        public PregSqlDataHelper(ProviderLeadRegistrationConfig config): base(config.RE_PregDbConnectionString) { }

        public string GetReference(string email) => GetData($"SELECT [Reference] FROM [dbo].[Invitations] where EmployerEmail = '{email}'");

        public void DeleteInvitation(string email) => ExecuteSqlCommand($"Delete FROM [dbo].[Invitations] where EmployerEmail = '{email}'");
    }
}
