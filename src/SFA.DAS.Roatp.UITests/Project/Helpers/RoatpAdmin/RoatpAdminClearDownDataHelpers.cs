using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminClearDownDataHelpers
    {
        private readonly ObjectContext _objectContext;
        private readonly string _roatpDatabaseConnectionString;

        public RoatpAdminClearDownDataHelpers(ObjectContext objectContext, RoatpConfig roatpConfig)
        {
            _objectContext = objectContext;
            _roatpDatabaseConnectionString = roatpConfig.RoatpDatabaseConnectionString;
        }

        public void DeleteTrainingProvider() => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_roatpDatabaseConnectionString, $"DELETE FROM Organisations WHERE UKPRN ='{_objectContext.GetUkprn()}'");

    }
}
