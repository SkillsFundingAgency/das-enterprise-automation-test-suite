using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentOpportunitySteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;

        public AssessmentOpportunitySteps(ScenarioContext context) : base(context) => _context = context;

        [When(@"the User visits the Assessment Opportunity Application")]
        public void WhenTheUserVisitsTheAssessmentOpportunityApplication()
        {
            tabHelper.GoToUrl(ePAOConfig.AssessmentServiceUrl, ePAOConfig.AssessmentOpportunityFinderPath);
            homePage = new AO_HomePage(_context);
        }

        [Then(@"the Approved tab is displayed and selected")]
        public void ThenTheApprovedTabIsDisplayedAndSelected() => homePage.VerifyApprovedTab();

        [When(@"the User clicks on one of the standards listed under 'Approved' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderTab() => homePage.ClickOnAbattoirWorkerApprovedStandardLink();

        [When(@"clicks on 'Apply to assess this Standard'")]
        public void WhenTheUserClicksOnApplyToAssessThisStandard() => new AO_ApprovedStandardDetailsPage(_context).ClickApplyToThisStandardButton();

        [Then(@"the User is redirected to 'Assessment Service' application")]
        public void ThenTheUserIsRedirectedToAssessmentServiceApplication() => new AS_LandingPage(_context).VerifyAS_LandingPage();

        [When(@"the User clicks on one of the standards listed under 'In-development' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderInDevelopmentTabToViewIt() => homePage.ClickInDevelopmentTab().ClickOnInDevelopmentStandardLink();

        [Then(@"the selected In-development standard detail page is displayed")]
        public void ThenTheSelectedInDevelopmentStandardDetailPageIsDisplayed() => new AO_InDevelopmentStandardDetailsPage(_context).IsInDevelopmentStandardDetailsPageDisplayed();

        [When(@"the User clicks on one of the standards listed under 'Proposed' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderProposedTabToViewIt() => homePage.ClickInProposedTab().ClickOnAProposedStandard();

        [Then(@"the selected Proposed standard detail page is displayed")]
        public void ThenTheSelectedProposedStandardDetailPageIsDisplayed() => new AO_ProposedStandardDetailsPage(_context).IsProposedStandardDetailsPageDisplayed();
    }
}
