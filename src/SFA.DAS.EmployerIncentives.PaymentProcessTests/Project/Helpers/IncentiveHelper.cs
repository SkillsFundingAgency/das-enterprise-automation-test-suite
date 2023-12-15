using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class IncentiveHelper(ScenarioContext context)
    {
        private readonly EISqlHelper _sqlHelper = context.Get<EISqlHelper>();
        private readonly StopWatchHelper _stopWatchHelper = context.Get<StopWatchHelper>();

        public async Task Delete(IncentiveApplication application)
        {
            _stopWatchHelper.Start("DeleteIncentiveData");
            foreach (var apprenticeship in application.Apprenticeships)
            {
                await Delete(application.AccountId, apprenticeship.ApprenticeshipId);
            }
            _stopWatchHelper.Stop("DeleteIncentiveData");
        }

        public async Task Delete(long accountId, long apprenticeshipId)
        {
            _stopWatchHelper.Start("DeleteIncentive");
            await _sqlHelper.DeleteIncentiveData(accountId, apprenticeshipId);
            _stopWatchHelper.Stop("DeleteIncentive");
        }
    }
}
