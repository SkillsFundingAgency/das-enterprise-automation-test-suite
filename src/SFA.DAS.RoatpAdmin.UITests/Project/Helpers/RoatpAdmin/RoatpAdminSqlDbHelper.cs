using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminSqlDbHelper : SqlDbHelper
    {
        public RoatpAdminSqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.RoatpDatabaseConnectionString) { }

        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
