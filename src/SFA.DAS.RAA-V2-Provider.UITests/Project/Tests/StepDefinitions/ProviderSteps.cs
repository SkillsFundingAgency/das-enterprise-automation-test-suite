using SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

        [Then(@"Provider can make the application successful")]
        public void ThenProviderCanMakeTheApplicationSuccessful() => _providerStepsHelper.ApplicantSucessful();

        [Then(@"Provider can make the application unsuccessful")]
        public void ThenProviderCanMakeTheApplicationUnsuccessful() => _providerStepsHelper.ApplicantUnsucessful();

        [Then(@"the Provider verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type|Set As Competitive)' the wage option selected in the Preview page")]
        public void ThenTheProviderVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _providerStepsHelper.VerifyWageType(wageType);

        [Then(@"Provider can view the refered vacancy")]
        public void ThenProviderCanViewTheReferedVacancy() => _providerStepsHelper.ViewReferVacancy();
    }
}
