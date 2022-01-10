using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class PregSqlDataHelper : SqlDbHelper
    {
        public PregSqlDataHelper(DbConfig config): base(config.PregDbConnectionString) { }

        public string GetReference(string email) => GetDataAsString($"SELECT [Reference] FROM [dbo].[Invitations] where EmployerEmail = '{email}'");

        public void DeleteInvitation(string email) => ExecuteSqlCommand($"Delete FROM [dbo].[Invitations] where EmployerEmail = '{email}'");
    }
}
