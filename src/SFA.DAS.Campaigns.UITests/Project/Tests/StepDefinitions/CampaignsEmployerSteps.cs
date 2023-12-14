using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding, Scope(Tag = "apprentice")]
    public class CampaignsEmployerSteps(ScenarioContext context)
    {
        private readonly CampaignsStepsHelper _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to Setting Up Page")]
        public void GivenTheUserNavigatesToSettingUpPage() => GoToEmployerHubPage().ClickSettingUpLink();

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
