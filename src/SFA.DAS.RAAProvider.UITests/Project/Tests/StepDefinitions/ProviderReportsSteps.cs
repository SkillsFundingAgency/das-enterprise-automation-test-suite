using SFA.DAS.RAAProvider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderReportsSteps (ScenarioContext context)
    {
        private readonly ProviderApiKeyStepsHelper _providerStepsHelper = new(context);

        [Given(@"the provider generates a report")]
        public void GivenTheProviderGeneratesAReport() => _providerStepsHelper.GenerateReports();
    }
}
