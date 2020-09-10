using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsEmployerSteps
    {
        private readonly CampaignsStepsHelper _stepsHelper;

        public CampaignsEmployerSteps(ScenarioContext context) => _stepsHelper = new CampaignsStepsHelper(context);

        [Given(@"the user navigates to employer real stories page")]
        public void GivenTheUserNavigatesToEmployerRealStoriesPage() => GoToEmployerHubPage().NavigateToRealStoriesPage();

        [Given(@"the user navigates to the benefits of your organisation page")]
        public void GivenTheUserNavigatesToTheBenefitsOfYourOrganisationPage() => GoToEmployerHubPage().NavigateToEmpBenefitsPage();

        [Given(@"the user navigates to hiring an apprentice page")]
        public void GivenTheUserNavigatesToHiringAnApprenticePage() => GoToEmployerHubPage();
      
        [Given(@"the user navigates to the funding an apprenticeship page")]
        public void GivenTheUserNavigatesToTheFundingAnApprenticeshipPage() => GoToEmployerHubPage().NavigateToFundingAnApprenticeshipPage();

        //[Given(@"the user navigates to hiring an apprentice page")]
        //public void GivenTheUserNavigatesToHiringAnApprenticePage() => GoToEmployerHubPage().NavigateToHireAnApprenticePage();

        [Given(@"the user navigates to Upskilling Your Current Staff page")]
        public void GivenTheUserNavigatesToUpskillingYourCurrentStaffPage() => GoToEmployerHubPage().NavigateToUpSkillingYourCurrentStaffPage();

        [Given(@"the user navigates to the end point assessments page")]
        public void GivenTheUserNavigatesToTheEndPointAssessmentsPage() => GoToEmployerHubPage().NavigateToEndPointAssesmentPage();

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

        public FireItUpHomePage GoToFireItUpHomePage() => _stepsHelper.GoToFireItUpHomePage();

        public EmployerHubPage GoToEmployerHubPage() => GoToFireItUpHomePage().NavigateToEmployerHubPage();
    }
}
