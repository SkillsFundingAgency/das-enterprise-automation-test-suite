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

        [Given(@"the user can navigate to the real stories page")]
        public void GivenTheUserCanNavigateToTheRealStoriesPage() => _campaingnsBasePage = GoToFireItUpHomePage().NavigateToWhatIsAnApprenticeshipPage().NavigateToRealStoriesPage();

        [When(@"the user navigates to the parent page")]
        public void WhenTheUserNavigatesToTheParentPage() => _campaingnsBasePage = GoToFireItUpHomePage().NavigateToHelpShapeTheirCareerPage();

        [Then(@"the links are not broken")]
        public void ThenTheLinksAreNotBroken() => _campaingnsBasePage.VerifyLinks();

        [Then(@"an apprentice registers interest")]
        public void ThenAnApprenticeRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Then(@"an employer registers interest")]
        public void ThenAnEmployerRegistersInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnEmployer().VerifyDetail();

        private FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();

    }
}
