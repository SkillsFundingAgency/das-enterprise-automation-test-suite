using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpApplyContactSqlDbHelper : SqlDbHelper
    {
        public RoatpApplyContactSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.ApplyDatabaseConnectionString) { }

        public void DeleteContact(string email) => ExecuteSqlCommand($"DELETE FROM Contacts WHERE Email ='{email}'");

        public string GetSignInId(string email) => GetDataAsString($"select SigninId from dbo.Contacts where email = '{email}'");
    }
}
