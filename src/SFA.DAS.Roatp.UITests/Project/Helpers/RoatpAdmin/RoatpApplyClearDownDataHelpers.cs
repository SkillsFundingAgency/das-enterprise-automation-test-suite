using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin
{
    public class RoatpApplyClearDownDataHelpers : SqlDbHelper
    {
        public RoatpApplyClearDownDataHelpers(RoatpConfig roatpConfig) : base(roatpConfig.ApplyDatabaseConnectionString) { }

        public void GateWayClearDownDataFromApply(string ukprn)
        {
            var GateWayResetQuery = $" DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE [UKPRN] = {ukprn} " +
            $" DELETE FROM dbo.gatewayanswer WHERE ApplicationId = @ApplicationID; " +
            $" UPDATE Apply set GatewayReviewStatus = 'New' , Applicationstatus = 'Submitted' WHERE [UKPRN] = {ukprn} " +
            $" UPDATE Apply set FinancialReviewStatus = 'New' , FinancialGrade = NULL WHERE [UKPRN] = {ukprn} ";

            ExecuteSqlCommand(GateWayResetQuery);
        }

        public void FHAClearDwnDataFromApply(string ukprn)
        {
            var FhaResetQuery = $"UPDATE Apply set GatewayReviewStatus = 'Pass' , Applicationstatus = 'GatewayAssessed'," +
                $" FinancialReviewStatus = 'New', FinancialGrade = NULL WHERE [UKPRN] = {ukprn} ";

            ExecuteSqlCommand(FhaResetQuery);
        }
    }
}
