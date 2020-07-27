using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsApprenticeSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private FindAnApprenticeshipPage _findAnApprenticeshipPage;

        public CampaignsApprenticeSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

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

        private ApprenticeHubPage GoToApprenticeshipHubPage() => GoToFireItUpHomePage().NavigateToApprenticeshipHubPage();

        private FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();
    }
}
