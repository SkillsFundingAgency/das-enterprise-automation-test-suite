using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpAdminSqlDbHelper : SqlDbHelper
    {
        public RoatpAdminSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : base(objectContext, dbConfig.RoatpDatabaseConnectionString) { }

        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
