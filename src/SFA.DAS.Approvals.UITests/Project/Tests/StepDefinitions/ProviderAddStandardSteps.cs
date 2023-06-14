using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderAddStandardSteps
    {
        private readonly ProviderAddStandardStepsHelper _providerAddStandardStepsHelper;

        public ProviderAddStandardSteps(ScenarioContext context) => _providerAddStandardStepsHelper = new ProviderAddStandardStepsHelper(context);

        [Given(@"Provider can add standards to its list of standards offered")]
        public void GivenProviderCanAddStandardsToItsListOfStandardsOffered()
        {
            var _providerManageTheStandardsYouDeliverPage = _providerAddStandardStepsHelper.GoToManageStandardPage();

            for (int i = 0; i < 1; i++) _providerManageTheStandardsYouDeliverPage = _providerAddStandardStepsHelper.AddStandard(_providerManageTheStandardsYouDeliverPage, true);
        }
    }
}

