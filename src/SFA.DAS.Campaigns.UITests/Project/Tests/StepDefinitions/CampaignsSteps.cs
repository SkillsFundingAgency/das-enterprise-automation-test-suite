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
        private HelpShapeTheirCareerPage _helpShapeTheirCareerPage;

        public CampaignsSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user can navigate to the parents page")]
        public void GivenTheUserCanNavigateToTheParentsPage() => _helpShapeTheirCareerPage = GoToFireItUpHomePage().NavigateToHelpShapeTheirCareerPage();

        [Then(@"the links on the parents page should not be broken")]
        public void ThenTheLinksOnTheParentsPageShouldNotBeBroken() => _helpShapeTheirCareerPage.VerifyLinks();

        [Then(@"an apprentice can register interest")]
        public void ThenAnApprenticeCanRegisterInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnApprentice();

        [Then(@"the employer can register interest")]
        public void ThenTheEmployerCanRegisterInterest() => GoToFireItUpHomePage().NavigateToRegisterInterest().RegisterInterestAsAnEmployer().VerifyDetail();

        private FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();

    }
}
