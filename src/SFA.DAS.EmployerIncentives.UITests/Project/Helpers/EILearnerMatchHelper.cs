using System;
using System.Threading.Tasks;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EILearnerMatchHelper : EIFunctionAppHelper
    {
        public EILearnerMatchHelper(EIConfig config) : base(config)
        {
        }

        public async Task StartLearnerMatchOrchestrator()
        {
            await StartOrchestrator("api/orchestrators/LearnerMatchingOrchestrator");
        }

        public async Task WaitUntilComplete(TimeSpan? timeout = null)
        {
            await WaitUntilStatus("Completed", timeout ?? TimeSpan.FromMinutes(1));
        }
    }
}
