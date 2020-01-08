using NUnit.Framework;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentOpportunity;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class AssessmentOpportunitySteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _ePAOConfig;
        private readonly TabHelper _tabHelper;
        private AO_HomePage _homePage;

        public AssessmentOpportunitySteps(ScenarioContext context)
        {
            _context = context;
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _tabHelper = context.Get<TabHelper>();
        }

        [When(@"the User visits the Assessment Opportunity Application")]
        public void WhenTheUserVisitsTheAssessmentOpportunityApplication()
        {
            _tabHelper.GoToUrl(_ePAOConfig.EPAOAssessmentOpportunityFinderUrl);
            _homePage = new AO_HomePage(_context);
        }

        [Then(@"the Approved tab is displayed and selected")]
        public void ThenTheApprovedTabIsDisplayedAndSelected()
        {
            _homePage.IsApprovedTabDisplayed();
            Assert.AreEqual("Approved Standards", _homePage.GetApprovedTabHeaderText());
        }

        [When(@"the User clicks on one of the standards listed under 'Approved' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderTab()
        {
            _homePage.ClickOnAbattoirWorkerApprovedStandardLink();
        }

        [When(@"clicks on 'Apply to assess this Standard'")]
        public void WhenTheUserClicksOnApplyToAssessThisStandard()
        {
            new AO_ApprovedStandardDetailsPage(_context).ClickApplyToThisStandardButton();
        }

        [Then(@"the User is redirected to 'Assessment Service' application")]
        public void ThenTheUserIsRedirectedToAssessmentServiceApplication()
        {
            _tabHelper.SwitchToTheNewTab();
            new AS_LandingPage(_context).VerifyAS_LandingPage();
        }

        [When(@"the User clicks on one of the standards listed under 'In-development' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderInDevelopmentTabToViewIt()
        {
            _homePage.ClickInDevelopmentTab()
                .ClickOnBlacksmithInDevelopmentStandardLink();
        }

        [Then(@"the selected In-development standard detail page is displayed")]
        public void ThenTheSelectedInDevelopmentStandardDetailPageIsDisplayed()
        {
            new AO_InDevelopmentStandardDetailsPage(_context).IsInDevelopmentStandardDetailsPageDisplayed();
        }

        [When(@"the User clicks on one of the standards listed under 'Proposed' tab to view it")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderProposedTabToViewIt()
        {
            _homePage.ClickInProposedTab()
                .ClickOnEquineAthleteProposedStandard();
        }

        [Then(@"the selected Proposed standard detail page is displayed")]
        public void ThenTheSelectedProposedStandardDetailPageIsDisplayed()
        {
            new AO_ProposedStandardDetailsPage(_context).IsProposedStandardDetailsPageDisplayed();
        }
    }
}
