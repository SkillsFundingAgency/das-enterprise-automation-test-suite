using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsApprenticeSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private FindAnApprenticeshipPage _findAnApprenticeshipPage;
        private ApprenticeAreTheyRightForYouPage _apprenticeAreTheyRightForYouPage;
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
        public void GivenTheUserNavigatesToAreApprenticeShipRightForYouPage() => _apprenticeAreTheyRightForYouPage = GoToApprenticeshipHubPage()
            .NavigateToAreApprenticeShipRightForMe()
            .VerifyApprenticeAreTheyRightForYouPageSubHeadings();

        [Then(@"check that RealStories Page loads")]
        public void ThenCheckThatRealStoriesPageLoads() => _apprenticeAreTheyRightForYouPage.NavigateToRealStoriesPage();

        [Given(@"the user navigates to the find an apprenticeship page")]
        public void GivenTheUserNavigatesToTheFindAnApprenticeshipPage() => _findAnApprenticeshipPage = GoToApprenticeshipHubPage().NavigateToFindAnApprenticeshipPage();

        [Given(@"the user navigates to the assesment and certification page")]
        public void GivenTheUserNavigatesToTheAssesmentAndCertificationPage() => GoToApprenticeshipHubPage().NavigateToAssesmentAndCertificationPage();

        [Given(@"the user navigates to the your apprenticeship page")]
        public void GivenTheUserNavigatesToTheYourApprenticeshipPage() => GoToApprenticeshipHubPage().NavigateToYourApprenticeshipPage();

        [Given(@"the user navigates to the interview page")]
        public void GivenTheUserNavigatesToTheInterviewPage() => GoToApprenticeshipHubPage().NavigateToInterviewPage();

        [Given(@"the user navigates to the application page")]
        public void GivenTheUserNavigatesToTheApplicationPage() => GoToApprenticeshipHubPage().NavigateToApplicationPage();

        [Given(@"the user navigates to the what is an apprenticeship page")]
        public void GivenTheUserNavigatesToTheWhatIsAnApprenticeshipPage() => GoToApprenticeshipHubPage().NavigateToWhatIsAnApprenticeshipPage();

        [Given(@"the user navigates to the benefits of apprenticeship page")]
        public void GivenTheUserNavigatesToTheBenefitsOfApprenticeshipPage() => GoToApprenticeshipHubPage().NavigateToBenefitsofApprenticeshipPage();

        [Given(@"the user navigates to the real stories page")]
        public void GivenTheUserNavigatesToTheRealStoriesPage() => GoToApprenticeshipHubPage().NavigateToRealStoriesPage();

        [Then(@"the user can search for an apprenticeship")]
        public void ThenTheUserCanSearchForAnApprenticeship() => _findAnApprenticeshipPage.SearchForAnApprenticeship().VerifySearchResults().SelectFirstSearchResult().VerifyVacancyTitle();

        [Given(@"the user navigates to the Advice for Parent  page")]
        public void GivenTheUserNavigatesToTheAdviceForParentPage() => GoToApprenticeshipHubPage().NavigateToAdviceForParentPage();

        [Given(@"the user navigates to the Browse By Interest Page page")]
        public void GivenTheUserNavigatesToTheBrowseByInterestPagePage() => GoToApprenticeshipHubPage().NavigateToBrowseInterestPage();

        [Given(@"the user navigates to the Set Up Service Account page")]
        public void GivenTheUserNavigatesToTheSetUpServiceAccountPage() => GoToApprenticeshipHubPage().NavigateToSetUpServiceAccountPage();

        [Given(@"the user navigates to the Site Map page")]
        public void GivenTheUserNavigatesToTheSiteMapPage() => GoToApprenticeshipHubPage().NavigateToSiteMapPage();
        
        private ApprenticeHubPage GoToApprenticeshipHubPage() => _stepsHelper.GoToApprenticeshipHubPage();
    }
}
