using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class AssessmentOpportunitySteps
    {
        private readonly ScenarioContext _context;
        private readonly EPAOConfig _ePAOConfig;
        private readonly IWebDriver _webDriver;

        private AS_AchievementDatePage _achievementDatePage;

        public AssessmentOpportunitySteps(ScenarioContext context)
        {
            _context = context;
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _webDriver = context.GetWebDriver();
        }

        [When(@"the User visits the Assessment Opportunity Application")]
        public void WhenTheUserVisitsTheAssessmentOpportunityApplication()
        {
            NavigateToAssessmentOpportunityApplication();
        }

        [Then(@"the Approved tab is displayed")]
        public void ThenTheApprovedTabIsDisplayed()
        {

        }

        [When(@"the User clicks on one of the standards listed under '(.*)' tab")]
        public void WhenTheUserClicksOnOneOfTheStandardsListedUnderTab(string p0)
        {
            
        }

        [Then(@"the respective standard details page is displayed")]
        public void ThenTheRespectiveStandardDetailsPageIsDisplayed()
        {
            
        }

        [When(@"the User clicks on '(.*)'")]
        public void WhenTheUserClicksOn(string p0)
        {
            
        }

        [Then(@"the User is redirected to '(.*)' application")]
        public void ThenTheUserIsRedirectedToApplication(string p0)
        {
            
        }

        private void NavigateToAssessmentOpportunityApplication() => _webDriver.Navigate().GoToUrl(_ePAOConfig.EPAOAssessmentOpportunityFinderUrl);
    }
}
