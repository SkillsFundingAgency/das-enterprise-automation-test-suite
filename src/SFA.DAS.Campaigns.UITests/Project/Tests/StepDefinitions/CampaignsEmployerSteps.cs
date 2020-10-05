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
        public void GivenTheUserNavigatesToEmployerHowDoTheyWorkPage() => GoToEmployerHubPage().ClickHowDoTheyWorkLink();

        [Given(@"the user navigates to Are they right for you Page")]
        public void GivenTheUserNavigatesToAreTheyRightForYouPage() => GoToEmployerHubPage().NavigateToAreTheyRightForYouPage();

        [Given(@"the user navigates to employer real stories page")]
        public void GivenTheUserNavigatesToEmployerRealStoriesPage() => GoToEmployerHubPage().NavigateToRealStoriesPage();

        [Given(@"the user navigates to the benefits of your organisation page")]
        public void GivenTheUserNavigatesToTheBenefitsOfYourOrganisationPage() => GoToEmployerHubPage().NavigateToEmpBenefitsPage();

        [Given(@"the user navigates to hiring an apprentice page")]
        public void GivenTheUserNavigatesToHiringAnApprenticePage() => GoToEmployerHubPage();

        [Given(@"the user navigates to Upskilling Your Current Staff page")]
        public void GivenTheUserNavigatesToUpskillingYourCurrentStaffPage() => GoToEmployerHubPage().NavigateToUpSkillingYourCurrentStaffPage();

        [Given(@"the user navigates to the end point assessments page")]
        public void GivenTheUserNavigatesToTheEndPointAssessmentsPage() => _endPointAssessmentPage = GoToEmployerHubPage().NavigateToEndPointAssesmentPage();

        [Then(@"the end point assessments sub headings are displayed")]
        public void ThenTheEndPointAssessmentsSubHeadingsAreDisplayed() => _endPointAssessmentPage.VerifyEndPointAssessmentPageSubHeadings();

        [Given(@"the user navigates to the training your apprentice page")]
        public void GivenTheUserNavigatesToTheTrainingYourApprenticePage() => GoToEmployerHubPage().NavigateToTrainingYourApprenticePage();

        [Given(@"the user navigates to choose the right apprenticeship page")]
        public void GivenTheUserNavigatesToChooseTheRightApprenticeshipPage() => GoToEmployerHubPage().NavigateToChooseTheRightApprenticeshipPage();

        [Given(@"the user navigates to choose a training provider page")]
        public void GivenTheUserNavigatesToChooseATrainingProviderPage() => GoToEmployerHubPage().NavigateToChooseTheTrainingProviderPage();

        [Given(@"the user navigates to search for an apprenticeship page")]
        public void GivenTheUserNavigatesToSearchForAnApprenticeshipPage() => GoToEmployerHubPage().NavigateToFindAnApprenticeshipPage();

        [Given(@"the user navigates to Employer Guide Page")]
        public void GivenTheUserNavigatesToEmployerGuidePage() => GoToEmployerHubPage().NavigateEmployerGuidePage();

        private EmployerHubPage GoToEmployerHubPage() => _stepsHelper.GoToEmployerHubPage();
    }
}
