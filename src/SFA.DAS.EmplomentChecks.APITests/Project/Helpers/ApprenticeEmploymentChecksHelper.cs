
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers
{
    public class ApprenticeEmploymentChecksHelper : EmploymentChecksFunctionAppHelper
    {
        public ApprenticeEmploymentChecksHelper(EmploymentChecksProcessConfig config) : base(config)
        {
        }

        public async Task StartEmploymentCheckOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/EmploymentCheckOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(2), false, "Completed");
        }

        public async Task WaitUntilStopped(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(5), true, "Completed", "Failed");
        }
    }
}
