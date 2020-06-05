using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminClearDownDataHelpers : SqlDbHelper
    {
        public RoatpAdminClearDownDataHelpers(RoatpConfig roatpConfig) : base(roatpConfig.RoatpDatabaseConnectionString) { }

        public void DeleteTrainingProvider(string ukprn) => ExecuteSqlCommand($"DELETE FROM Organisations WHERE UKPRN ='{ukprn}'");
    }
}
