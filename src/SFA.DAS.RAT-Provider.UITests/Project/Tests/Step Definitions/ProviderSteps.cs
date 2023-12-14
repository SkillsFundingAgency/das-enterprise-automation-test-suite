using SFA.DAS.RAT_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Step_Definitions
{
    [Binding]
    public class ProviderSteps(ScenarioContext context)
    {
        private readonly ProviderStepsHelper _providerStepsHelper = new ProviderStepsHelper(context);

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();

        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();

        [Then(@"Provider can view the refered vacancy")]
        public void ThenProviderCanViewTheReferedVacancy() => _providerStepsHelper.ViewReferVacancy();
    }
}
