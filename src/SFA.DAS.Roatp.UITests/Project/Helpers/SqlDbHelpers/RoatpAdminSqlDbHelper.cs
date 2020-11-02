using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpAdminSqlDbHelper : SqlDbHelper
    {
        public RoatpAdminSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.RoatpDatabaseConnectionString) { }

        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
