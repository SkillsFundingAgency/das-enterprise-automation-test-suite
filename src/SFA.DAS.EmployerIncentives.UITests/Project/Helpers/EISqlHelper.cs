using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        public EISqlHelper(EIConfig eIConfig) : base(eIConfig.EI_IncentivesDbConnectionString) { }

        public void DeleteIncentiveApplication(string accountid)
        {
            var nullValue = "NULL";
            var query =
                $"DELETE FROM[incentives].[Payment]  where AccountId = {accountid};" +
                $"DELETE FROM[incentives].[PendingPaymentValidationResult] where PendingPaymentId in (SELECT Id FROM[incentives].[PendingPayment] where AccountId = {accountid});"+
                $"DELETE FROM [incentives].[PendingPayment] WHERE AccountId = {accountid};" +
                $"DELETE FROM [incentives].[ApprenticeshipIncentive] WHERE AccountId = {accountid};" +
                $"DELETE FROM [dbo].[IncentiveApplicationApprenticeship] WHERE IncentiveApplicationId IN (SELECT Id FROM IncentiveApplication WHERE AccountId = {accountid});" +
                $"DELETE FROM [dbo].[IncentiveApplication] WHERE AccountId = {accountid};" +
                $"UPDATE [dbo].[Accounts] SET VrfVendorId = {nullValue}, VrfCaseId = {nullValue}, VrfCaseStatus = {nullValue}, VrfCaseStatusLastUpdatedDateTime = {nullValue} WHERE Id = {accountid}";
            ExecuteSqlCommand(query);
        }
    }
}
