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
        private CampaingnsBasePage _campaingnsBasePage;

        public CampaignsSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user can navigate to the calling page")]
        public void GivenTheUserCanNavigateToTheCallingPage() => _campaingnsBasePage = GoToFireItUpHomePage().NavigateToTheCallingPage();

        [Given(@"the user can navigate to the find an apprenticeship page")]
        public void GivenTheUserCanNavigateToTheFindAnApprenticeshipPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToFindAnApprenticeshipPage();

        [Given(@"the user can navigate to the assesment and certification page")]
        public void GivenTheUserCanNavigateToTheAssesmentAndCertificationPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToAssesmentAndCertificationPage();

        [Given(@"the user can navigate to the your apprenticeship page")]
        public void GivenTheUserCanNavigateToTheYourApprenticeshipPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToYourApprenticeshipPage();

        [Given(@"the user can navigate to the interview page")]
        public void GivenTheUserCanNavigateToTheInterviewPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToInterviewPage();

        [Given(@"the user can navigate to the application page")]
        public void GivenTheUserCanNavigateToTheApplicationPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToApplicationPage();

        [Given(@"the user can navigate to the what is an apprenticeship page")]
        public void GivenTheUserCanNavigateToTheWhatIsAnApprenticeshipPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToWhatIsAnApprenticeshipPage();

        [Given(@"the user can navigate to the benefits of apprenticeship page")]
        public void GivenTheUserCanNavigateToTheBenefitsOfApprenticeshipPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToBenefitsofApprenticeshipPage();

        [Given(@"the user can navigate to the real stories page")]
        public void GivenTheUserCanNavigateToTheRealStoriesPage() => _campaingnsBasePage = GoToApprenticeshipHubPage().NavigateToRealStoriesPage();

        [When(@"the user navigates to the parent page")]
        public void WhenTheUserNavigatesToTheParentPage() => _campaingnsBasePage = GoToFireItUpHomePage().NavigateToHelpShapeTheirCareerPage();

        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => _campaingnsBasePage.VerifyLinks();

        [Then(@"the video links are not broken")]
        public void ThenTheVideoLinksAreNotBroken() => _campaingnsBasePage.VerifyVideoLinks();

        [Then(@"an apprentice registers interest")]
        public void ThenAnApprenticeRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnEmployer().VerifyDetail();

        private FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();

        private ApprenticeshipHubPage GoToApprenticeshipHubPage() => GoToFireItUpHomePage().NavigateToApprenticeshipHubPage();

    }
}
