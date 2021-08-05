using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsApprenticeSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private BrowseApprenticeshipPage _findAnApprenticeshipPage;
        private ApprenticeHubPage _apprenticeHubPage;

        public CampaignsApprenticeSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Then(@"the apprentice sub headings are displayed")]
        public void ThenTheApprenticeSubHeadingsAreDisplayed() => _apprenticeHubPage.VerifySubHeadings();

        [Given(@"the user navigates to Become An Apprentice page")]
        public void GivenTheUserNavigatesToBecomeAnApprenticePage() => _apprenticeHubPage = GoToApprenticeshipHubPage();

        [Given(@"the user navigates to apprentice How do they work Page")]
        public void GivenTheUserNavigatesToApprenticeHowDoTheyWorkPage() => GoToApprenticeshipHubPage().NavigateToHowDoTheyWorkPage().VerifyHowDoTheyWorkPageSubHeadings();

        [Given(@"the user navigates to Getting started Page")]
        public void GivenTheUserNavigatesToGettingStartedPage() => GoToApprenticeshipHubPage().NavigateToGettingStarted();

        [Given(@"the user navigates to Are ApprenticeShip Right For You Page")]
        public void GivenTheUserNavigatesToAreApprenticeShipRightForYouPage() => GoToApprenticeshipHubPage().NavigateToAreApprenticeShipRightForMe().VerifyApprenticeAreTheyRightForYouPageSubHeadings();

        [Given(@"the user navigates to the browse apprenticeship page")]
        public void GivenTheUserNavigatesToBrowseApprenticeshipPage() => _findAnApprenticeshipPage = GoToApprenticeshipHubPage().NavigateToBrowseApprenticeshipPage();

        [Then(@"the user can search for an apprenticeship")]
        public void ThenTheUserCanSearchForAnApprenticeship() => _findAnApprenticeshipPage.SearchForAnApprenticeship().VerifySearchResults().SelectFirstSearchResult().VerifyVacancyTitle();

        [Given(@"the user navigates to the Set Up Service Account page")]
        public void GivenTheUserNavigatesToTheSetUpServiceAccountPage() => GoToApprenticeshipHubPage().NavigateToSetUpServiceAccountPage();

        [Given(@"the user navigates to the Site Map page")]
        public void GivenTheUserNavigatesToTheSiteMapPage() => GoToApprenticeshipHubPage().NavigateToSiteMapPage();
        
        private ApprenticeHubPage GoToApprenticeshipHubPage() => _stepsHelper.GoToApprenticeshipHubPage();
    }
}
