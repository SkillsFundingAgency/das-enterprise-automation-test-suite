using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class EmploymentCheckHelper(ScenarioContext context)
    {
        private readonly EISqlHelper _sqlHelper = context.Get<EISqlHelper>();

        public async Task CompleteEmploymentCheck(Guid apprenticeshipIncentiveId, EmploymentCheckType checkType, bool result)
        {
            var employmentCheck = _sqlHelper.GetAllFromDatabase<Models.EmploymentCheck>()
                .Single(x => x.ApprenticeshipIncentiveId == apprenticeshipIncentiveId && x.CheckType == checkType);

            var id = employmentCheck.Id;
            await _sqlHelper.SetEmploymentCheckResult(id, result);
        }
    }
}
