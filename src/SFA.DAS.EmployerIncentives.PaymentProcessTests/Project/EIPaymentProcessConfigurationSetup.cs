using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project
{
    [Binding]
    public class EIPaymentProcessConfigurationSetup(ScenarioContext context)
    {
        private readonly IConfigSection _configSection = context.Get<IConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpEIPPConfigConfiguration() => context.SetEIPaymentProcessConfig(_configSection.GetConfigSection<EIPaymentProcessConfig>());
    }
}
