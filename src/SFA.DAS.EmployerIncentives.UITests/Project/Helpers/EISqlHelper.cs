using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EISqlHelper : SqlDbHelper
    {
        public EISqlHelper(EIConfig eIConfig) : base(eIConfig.EI_IncentivesDbConnectionString) { }

        public void DeleteIncentiveApplication(string accountid)
        {
            var query = $"DELETE FROM IncentiveApplicationApprenticeship WHERE IncentiveApplicationId IN (SELECT Id FROM IncentiveApplication WHERE AccountId = {accountid}); DELETE FROM IncentiveApplication WHERE AccountId = {accountid}";
            ExecuteSqlCommand(query);
        }
    }
}
