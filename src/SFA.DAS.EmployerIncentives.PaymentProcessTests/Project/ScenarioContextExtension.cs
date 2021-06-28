using TechTalk.SpecFlow;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string EIProjectConfigKey = "eiprojectconfigkey";
        #endregion

        #region Setters

        public static void SetEIPaymentProcessConfig<T>(this ScenarioContext context, T value) => context.Set(value, EIProjectConfigKey);
        #endregion

        #region Getters
        public static T GetEIPaymentProcessConfig<T>(this ScenarioContext context) => context.GetValue<T>(EIProjectConfigKey);
        #endregion
    }
}
