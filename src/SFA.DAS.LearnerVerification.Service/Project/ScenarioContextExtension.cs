using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.LearnerVerification.Service.Project
{
    public static class ScenarioContextExtension
    {
        private const string LVProjectConfigKey = "lvprojectconfigkey";

        public static void SetLearnerVerificationProcessConfig<T>(this ScenarioContext context, T value) => context.Set(value, LVProjectConfigKey);

        public static T GetLearnerVerificationProcessConfig<T>(this ScenarioContext context) => context.GetValue<T>(LVProjectConfigKey);
    }
}
