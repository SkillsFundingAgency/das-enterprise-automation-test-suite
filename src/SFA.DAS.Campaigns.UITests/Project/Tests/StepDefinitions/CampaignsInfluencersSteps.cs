using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "influencers")]
    public class CampaignsInfluencersSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        public CampaignsInfluencersSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to the browse apprenticeship page")]
        public void GivenTheUserNavigatesToTheBrowseApprenticeshipPage() => GoToInfluencersHubPage().NavigateToBrowseApprenticeshipPage();

        [Given(@"the user navigates to influencers How they work page")]
        public void GivenTheUserNavigatesToInfluencersHowTheyWorkPage() => GoToInfluencersHubPage().NavigateToHowDoTheyWorkPage().VerifyInfluencersHowTheyWorkPageSubHeadings();

        [Given(@"the user navigates to influencers Request support page")]
        public void GivenTheUserNavigatesToInfluencersRequestSupportPage() => GoToInfluencersHubPage().NavigateToRequestSupportPage().VerifySubHeadings();

        [Given(@"the user navigates to influencers Resource hub page")]
        public void GivenTheUserNavigatesToInfluencersResourceHubPage() => GoToInfluencersHubPage().NavigateToResourceHubPage().VerifySubHeadings();

        [Given(@"the user navigates to influencers Become an ambassador page")]
        public void GivenTheUserNavigatesToInfluencersBecomeAnAmbassadorPage() => GoToInfluencersHubPage().NavigateToBecomeAnAmbassadorPage().VerifyInfluencersBecomeAnAmbassadorPageSubHeadings();

        private InfluencersHubPage GoToInfluencersHubPage() => _stepsHelper.GoToInfluencersHubPage();
    }
}
