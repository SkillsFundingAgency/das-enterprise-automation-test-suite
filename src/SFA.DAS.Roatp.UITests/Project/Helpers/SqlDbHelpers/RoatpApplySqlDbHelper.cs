using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers
{
    public class RoatpApplySqlDbHelper : SqlDbHelper
    {
        public RoatpApplySqlDbHelper(RoatpConfig roatpConfig) : base(roatpConfig.ApplyDatabaseConnectionString) { }

        public void GateWayClearDownDataFromApply(string ukprn)
        {
            var GateWayResetQuery = $" DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE [UKPRN] = {ukprn} " +
            $" DELETE FROM dbo.gatewayanswer WHERE ApplicationId = @ApplicationID; " +
            $" DELETE FROM dbo.AssessorPageReviewOutcome WHERE ApplicationId =  @ApplicationID; " +
            $" DELETE FROM dbo.ModeratorPageReviewOutcome WHERE ApplicationId =  @ApplicationID; " +
            $" UPDATE Apply set GatewayReviewStatus = 'New' , Applicationstatus = 'Submitted' WHERE [UKPRN] = {ukprn} " +
            $" UPDATE Apply set FinancialReviewStatus = 'New' , FinancialGrade = NULL WHERE [UKPRN] = {ukprn} " +
            $" Update dbo.Apply set  [Assessor1UserId] = null, [Assessor2UserId] = null, [Assessor1Name] = null, [Assessor2Name] = null," +
            $" [Assessor1ReviewStatus] = null, [Assessor2ReviewStatus] = null, [ModerationStatus] = 'New', " +
            $" [OversightStatus] = 'New', [ApplicationDeterminedDate] = null where ApplicationId = @ApplicationID";


            ExecuteSqlCommand(GateWayResetQuery);
        }

        public void FHAClearDownDataFromApply(string ukprn)
        {
            var FhaResetQuery = $"DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE [UKPRN] = {ukprn} " +
            $"UPDATE Apply set GatewayReviewStatus = 'Pass' , Applicationstatus = 'GatewayAssessed'," +
            $" FinancialReviewStatus = 'New', FinancialGrade = null," +
            $" [Assessor1UserId] = null, [Assessor2UserId] = null, [Assessor1Name] = null, [Assessor2Name] = null," +
            $" [Assessor1ReviewStatus] = null, [Assessor2ReviewStatus] = null, [ModerationStatus] = 'New', " +
            $" [OversightStatus] = 'New', [ApplicationDeterminedDate] = null  WHERE ApplicationId =  @ApplicationID; " +
            $" DELETE FROM dbo.AssessorPageReviewOutcome WHERE   ApplicationId =  @ApplicationID; " +
            $" DELETE FROM dbo.ModeratorPageReviewOutcome WHERE  ApplicationId =  @ApplicationID";

            ExecuteSqlCommand(FhaResetQuery);
        }

        public void AssessorClearDownDataFromApply(string ukprn)
        {
            var AssessorResetQuery = $" DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE [UKPRN] = {ukprn} " +
            $" DELETE FROM dbo.AssessorPageReviewOutcome WHERE ApplicationId = @ApplicationID; " +
            $" DELETE FROM dbo.ModeratorPageReviewOutcome WHERE ApplicationId =  @ApplicationID; " +
            $" Update dbo.Apply set  [Assessor1UserId] = null, [Assessor2UserId] = null, [Assessor1Name] = null, [Assessor2Name] = null," +
            $" [Assessor1ReviewStatus] = null, [Assessor2ReviewStatus] = null, [ModerationStatus] = 'New', " +
            $" [OversightStatus] = 'New', [ApplicationDeterminedDate] = null where ApplicationId = @ApplicationID";

            ExecuteSqlCommand(AssessorResetQuery);
        }

        public void ModeratorClearDownDataFromApply(string ukprn)
        {
            var ModeratorResetQuery = $" DECLARE @ApplicationID UNIQUEIDENTIFIER; " +
            $" SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE [UKPRN] = {ukprn} " +
            $" Update dbo.ModeratorPageReviewOutcome set [ModeratorReviewStatus] = null, [ModeratorReviewComment] = null, " +
            $" [UpdatedAt] = null, [UpdatedBy] = null WHERE ApplicationId =  @ApplicationID; " +
            $" Update dbo.Apply set [ModerationStatus] = 'New', " +
            $" [OversightStatus] = 'New', [ApplicationDeterminedDate] = null where ApplicationId = @ApplicationID";

            ExecuteSqlCommand(ModeratorResetQuery);
        }

        public void ClarificationClearDownFromApply(string ukprn)
        {
            var ClarificationResetQuery = $"DECLARE @ApplicationID UNIQUEIDENTIFIER; SELECT @ApplicationID = ApplicationId FROM dbo.apply WHERE[UKPRN] = {ukprn};" +
                $"UPDATE Apply set[ModerationStatus] = 'Clarification Sent', [OversightStatus] = 'New', [ApplicationDeterminedDate] = NULL  WHERE ApplicationId = @ApplicationID;" +
                $"UPDATE ModeratorPageReviewOutcome set ClarificationUserId = NULL, ClarificationStatus = NULL, ClarificationComment = NULL, " +
                $"ClarificationResponse = NULL, ClarificationUpdatedAt = NULL WHERE ApplicationId = @ApplicationID ";
            
            ExecuteSqlCommand(ClarificationResetQuery);
            //, ClarificationFile = NULL
        }
    }
}
