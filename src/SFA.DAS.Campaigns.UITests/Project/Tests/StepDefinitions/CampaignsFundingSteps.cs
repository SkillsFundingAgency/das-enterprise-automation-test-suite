using SFA.DAS.Campaigns.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CampaignsFundingSteps(ScenarioContext context)
    {
        private readonly CampaignsStepsHelper _stepsHelper = new(context);

        [Given(@"the user navigates to the Understanding Apprentice benefit and funding page make selection under three million")]
        public void GivenTheUserNavigatesToTheUnderstandingApprenticeBenefitAndFundingPage() => _stepsHelper.GoToEmployerHubPage().NavigateToUnderstandingApprenticeshipBenefitsAndFunding().SelectUnder3Million();

        [Given(@"the user navigates to the Understanding Apprentice benefit and funding page make selection over three million")]
        public void GivenTheUserNavigatesToTheUnderstandingApprenticeBenefitAndFundingPageMakeSelectionOverThreeMillion() => _stepsHelper.GoToEmployerHubPage().NavigateToUnderstandingApprenticeshipBenefitsAndFunding().SelectOver3Million();

    }
}
