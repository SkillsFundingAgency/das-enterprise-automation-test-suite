using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers;
using SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AedSteps
    {
        private readonly AedStepsHelper _aEDStepsHelper;
        private GetHelpWithFindingATrainingProviderPage _getHelpWithFindingATrainingProviderPage;
        private AedIndexPage _aedIndexPage;

        public AedSteps(ScenarioContext context) => _aEDStepsHelper = new AedStepsHelper(context);

        [Given(@"the employer has shared interest")]
        public void GivenTheEmployerHasSharedInterest() => _aEDStepsHelper.RegisterInterest(0);

        [Given(@"the user selects get help with finding a training provider")]
        public void GivenTheUserSelectsGetHelpWithFindingATrainingProvider() => _getHelpWithFindingATrainingProviderPage = _aEDStepsHelper.GetHelpWithFindingATrainingProvider();

        [Given(@"the user selects share interest with finding a training provider")]
        public void GivenTheUserSelectsShareInterestWithFindingATrainingProvider() => _getHelpWithFindingATrainingProviderPage = _aEDStepsHelper.GetHelpWithFindingATrainingProviderViaShortlistPage(_aedIndexPage);

        [Given(@"the user has navigated to shortlist page")]
        public void GivenTheUserHasNavigatedToShortlistPage() => _aedIndexPage = _aEDStepsHelper.NavigateToShareYourInterestWithTrainingProvidersPageViaShortlistPage();

        [Then(@"the user can register interest without apprentices")]
        public void ThenTheUserCanRegisterInterestWithoutApprentices() => RegisterInterest(0);
        
        [Then(@"the user can register interest with apprentices")]
        public void ThenTheUserCanRegisterInterestWithApprentices() => RegisterInterest(2);

        private void RegisterInterest(int noOfApprentices) => _aEDStepsHelper.RegisterInterest(noOfApprentices, _getHelpWithFindingATrainingProviderPage);
    }
}
