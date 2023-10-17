using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    internal class PregSqlDataHelper : SqlDbHelper
    {
        public PregSqlDataHelper(ObjectContext objectContext, DbConfig config) : base(objectContext, config.PregDbConnectionString) { }

        public string GetReference(string email) => GetDataAsString($"SELECT [Reference] FROM [dbo].[Invitations] where EmployerEmail = '{email}'");

        public void DeleteInvitation(string email) => ExecuteSqlCommand($"DELETE FROM [dbo].[InvitationEvents] where InvitationId = (select id FROM [dbo].[Invitations] where EmployerEmail = '{email}'); DELETE FROM [dbo].[Invitations] where EmployerEmail = '{email}'");
    }
}
