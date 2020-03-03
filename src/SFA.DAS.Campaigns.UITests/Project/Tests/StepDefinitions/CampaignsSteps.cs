using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private CampaingnsBasePage _page;
        private FindAnApprenticeshipPage _findAnApprenticeshipPage;

        public CampaignsSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to the calling page")]
        public void GivenTheUserNavigatesToTheCallingPage() => _page = GoToFireItUpHomePage().NavigateToTheCallingPage();

        [Given(@"the user navigates to the find an apprenticeship page")]
        public void GivenTheUserNavigatesToTheFindAnApprenticeshipPage()
        {
            _findAnApprenticeshipPage = GoToApprenticeshipHubPage().NavigateToFindAnApprenticeshipPage();
            _page = _findAnApprenticeshipPage;
        }

        [Given(@"the user navigates to the assesment and certification page")]
        public void GivenTheUserNavigatesToTheAssesmentAndCertificationPage() => _page = GoToApprenticeshipHubPage().NavigateToAssesmentAndCertificationPage();

        [Given(@"the user navigates to the your apprenticeship page")]
        public void GivenTheUserNavigatesToTheYourApprenticeshipPage() => _page = GoToApprenticeshipHubPage().NavigateToYourApprenticeshipPage();

        [Given(@"the user navigates to the interview page")]
        public void GivenTheUserNavigatesToTheInterviewPage() => _page = GoToApprenticeshipHubPage().NavigateToInterviewPage();

        [Given(@"the user navigates to the application page")]
        public void GivenTheUserNavigatesToTheApplicationPage() => _page = GoToApprenticeshipHubPage().NavigateToApplicationPage();

        [Given(@"the user navigates to the what is an apprenticeship page")]
        public void GivenTheUserNavigatesToTheWhatIsAnApprenticeshipPage() => _page = GoToApprenticeshipHubPage().NavigateToWhatIsAnApprenticeshipPage();

        [Given(@"the user navigates to the benefits of apprenticeship page")]
        public void GivenTheUserNavigatesToTheBenefitsOfApprenticeshipPage() => _page = GoToApprenticeshipHubPage().NavigateToBenefitsofApprenticeshipPage();

        [Given(@"the user navigates to the real stories page")]
        public void GivenTheUserNavigatesToTheRealStoriesPage() => _page = GoToApprenticeshipHubPage().NavigateToRealStoriesPage();

        [When(@"the user navigates to the parent page")]
        public void WhenTheUserNavigatesToTheParentPage() => _page = GoToFireItUpHomePage().NavigateToHelpShapeTheirCareerPage();

        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => _page.VerifyLinks();

        [Then(@"the video links are not broken")]
        public void ThenTheVideoLinksAreNotBroken() => _page.VerifyVideoLinks();

        [Then(@"an apprentice registers interest")]
        public void ThenAnApprenticeRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnEmployer().VerifyDetail();

        [Then(@"the user can search for an apprenticeship")]
        public void ThenTheUserCanSearchForAnApprenticeship() => _findAnApprenticeshipPage.SearchForAnApprenticeship().VerifySearchResults().SelectFirstSearchResult().VerifyVacancyTitle();

        private FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();

        private ApprenticeshipHubPage GoToApprenticeshipHubPage() => GoToFireItUpHomePage().NavigateToApprenticeshipHubPage();

    }
}
