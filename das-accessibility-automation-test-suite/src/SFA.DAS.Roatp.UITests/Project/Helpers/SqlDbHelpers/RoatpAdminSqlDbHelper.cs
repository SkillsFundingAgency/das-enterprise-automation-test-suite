using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpAdminSqlDbHelper(ObjectContext objectContext, DbConfig dbConfig) : SqlDbHelper(objectContext, dbConfig.RoatpDatabaseConnectionString)
    {
        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
