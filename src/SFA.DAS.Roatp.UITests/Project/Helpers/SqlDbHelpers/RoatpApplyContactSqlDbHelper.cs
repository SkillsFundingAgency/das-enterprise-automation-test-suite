using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpApplyContactSqlDbHelper : SqlDbHelper
    {
        public RoatpApplyContactSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.ApplyDatabaseConnectionString) { }

        public void DeleteContact(string email) => ExecuteSqlCommand($"DELETE FROM Contacts WHERE Email ='{email}'");
    }
}
