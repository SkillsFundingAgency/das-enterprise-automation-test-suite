using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsEmployerSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        private EmployerHubPage _employerHubPage;
        private EndPointAssessmentPage _endPointAssessmentPage;

        public CampaignsEmployerSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to Setting Up Page")]
        public void GivenTheUserNavigatesToSettingUpPage() => GoToEmployerHubPage().ClickSettingUpLink();

        [Then(@"the employer sub headings are displayed")]
        public void ThenTheEmployerSubHeadingsAreDisplayed() => _employerHubPage.VerifySubHeadings();

        [Given(@"the user navigates to Hire An Apprentice hub Page")]
        public void GivenTheUserNavigatesToHireAnApprenticeHubPage() => _employerHubPage = GoToEmployerHubPage();

        [Given(@"the user navigates to employer How do they work page")]
        public void GivenTheUserNavigatesToEmployerHowDoTheyWorkPage() => GoToEmployerHubPage().ClickHowDoTheyWorkLink().VerifyHowDoTheyWorkPageSubHeadings();

        [Given(@"the user navigates to Are they right for you Page")]
        public void GivenTheUserNavigatesToAreTheyRightForYouPage() => GoToEmployerHubPage().NavigateToAreTheyRightForYouPage().VerifyApprenticeHowDoTheyWorkPageSubHeadings();

        [Given(@"the user navigates to hiring an apprentice page")]
        public void GivenTheUserNavigatesToHiringAnApprenticePage() => GoToEmployerHubPage();

        [Given(@"the user navigates to search for an apprenticeship page")]
        public void GivenTheUserNavigatesToSearchForAnApprenticeshipPage() => GoToEmployerHubPage().NavigateToFindAnApprenticeshipPage();

        private EmployerHubPage GoToEmployerHubPage() => _stepsHelper.GoToEmployerHubPage();
    }
}
