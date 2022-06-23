using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    public static class ScenarioContextExtension
    {
        private const string ECProjectConfigKey = "ecprojectconfigkey";

        public static void SetEmploymentCheckPaymentProcessConfig<T>(this ScenarioContext context, T value) => context.Set(value, ECProjectConfigKey);

        public static T GetEmploymentCheckPaymentProcessConfig<T>(this ScenarioContext context) => context.GetValue<T>(ECProjectConfigKey);
    }
}
