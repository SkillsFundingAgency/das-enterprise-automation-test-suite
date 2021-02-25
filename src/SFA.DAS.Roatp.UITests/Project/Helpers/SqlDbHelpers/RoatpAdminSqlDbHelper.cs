using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpAdminSqlDbHelper : SqlDbHelper
    {
        public RoatpAdminSqlDbHelper(DbConfig dbConfig) : base(dbConfig.RoatpDatabaseConnectionString) { }

        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
