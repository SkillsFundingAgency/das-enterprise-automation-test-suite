using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests
{
    public static class ScenarioContextExtension
    {
        private const string EmployerAccountsApiConfig = "employeraccountsapiconfig";

        public static void SetEmployerAccountsApiConfig<T>(this ScenarioContext context, T value) => context.Set(value, EmployerAccountsApiConfig);

        public static T GetEmployerAccountsApiConfig<T>(this ScenarioContext context) => context.GetValue<T>(EmployerAccountsApiConfig);
    }
}
