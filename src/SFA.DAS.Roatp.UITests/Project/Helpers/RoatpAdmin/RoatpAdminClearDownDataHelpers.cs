using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpAdminClearDownDataHelpers
    {
        private readonly ObjectContext _objectContext;
        private readonly string _roatpDatabaseConnectionString;
        private readonly string _applyDatabaseConnectionString;

        public RoatpAdminClearDownDataHelpers(ObjectContext objectContext, RoatpConfig roatpConfig)
        {
            _objectContext = objectContext;
            _roatpDatabaseConnectionString = roatpConfig.RoatpDatabaseConnectionString;
            _applyDatabaseConnectionString = roatpConfig.ApplyDatabaseConnectionString;
        }

        public void DeleteTrainingProvider() => SqlDatabaseConnectionHelper.ExecuteSqlCommand(_roatpDatabaseConnectionString, $"DELETE FROM Organisations WHERE UKPRN ='{_objectContext.GetUkprn()}'");

        public void GateWayClearDownDataFromApply()
        {
            var GateWayResetQuery = $" DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE ukprn = '10047117';" +
            $" DELETE FROM dbo.gatewayanswer WHERE ApplicationId = @ApplicationID; " +
            $" UPDATE Apply set GatewayReviewStatus = 'New' , Applicationstatus = 'Submitted' WHERE UKPRN = '10047117' " ;

            SqlDatabaseConnectionHelper.ExecuteSqlCommand(_applyDatabaseConnectionString, GateWayResetQuery);
        }
    }
}
