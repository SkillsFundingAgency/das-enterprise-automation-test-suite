using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CampaignsFundingSteps(ScenarioContext context)


    {
        private readonly CampaignsStepsHelper _stepsHelper = new(context);

        private FundingAnApprenticeshipPage _fundingAnApprenticeshipPage;

        [Given(@"the user navigates to the funding an apprenticeship page")]
        public void GivenTheUserNavigatesToTheFundingAnApprenticeshipPage() => _fundingAnApprenticeshipPage = _stepsHelper.GoToEmployerHubPage().NavigateToFundingAnApprenticeshipPage();

        [Then(@"Employer selects Levy Paying and continues")]
        public void ThenEmployerSelectsLevyPayingAndContinues() => _fundingAnApprenticeshipPage.NavigateToLevyEmployerPage();

        [Then(@"Employer selects non Levy Paying and continues")]
        public void ThenEmployerSelectsNonLevyPayingAndContinues() => _fundingAnApprenticeshipPage.NavigateToNonLevyEmployerPage();

        [Then(@"Employer selects non sure Levy Paying and continues")]
        public void ThenEmployerSelectsNonSureLevyPayingAndContinues() => _fundingAnApprenticeshipPage.NavigateToNotSureLevyEmployerPage();
    }
}
