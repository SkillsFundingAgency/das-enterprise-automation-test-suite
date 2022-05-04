using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Helpers.AzureDurableFunctions
{
    public class EmploymentCheckOutputInterfaceHelper : EmploymentCheckFunctionAppHelper
    {
        public EmploymentCheckOutputInterfaceHelper(EmploymentCheckProcessConfig config) : base(config)
        {
        }

        public async Task StartResponseEmploymentChecksOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/ResponseOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(2), false,"Completed");
        }

        public async Task WaitUntilStopped(TimeSpan? timeout = null)
        {
            await WaitUntilStatus(timeout ?? TimeSpan.FromMinutes(5), true, "Completed", "Failed");
        }
    }
}
