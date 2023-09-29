using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.APITests.Project
{
    public static class ScenarioContextExtension
    {
        private const string Ltmjobsconfigkey = "ltmjobsconfigkey";

        public static void SetTransferMatchingJobsConfig<T>(this ScenarioContext context, T value) => context.Set(value, Ltmjobsconfigkey);

        public static T GetTransferMatchingJobsConfig<T>(this ScenarioContext context) => context.GetValue<T>(Ltmjobsconfigkey);
    }
}
