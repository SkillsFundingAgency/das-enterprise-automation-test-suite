using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmploymentChecks.APITests.Project
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string EmploymentChecksProjectConfigKey = "employmentchecksprojectconfigkey";
        #endregion

        #region Setters

        public static void SetEIPaymentProcessConfig<T>(this ScenarioContext context, T value) => context.Set(value, EmploymentChecksProjectConfigKey);
        #endregion

        #region Getters
        public static T GetEIPaymentProcessConfig<T>(this ScenarioContext context) => context.GetValue<T>(EmploymentChecksProjectConfigKey);
        #endregion
    }
}
