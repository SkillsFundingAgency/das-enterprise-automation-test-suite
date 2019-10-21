using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionYourResultsPage
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private YourResultsPage yourResultsPage;
        #endregion

        public StepDefinitionYourResultsPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
            yourResultsPage = new YourResultsPage(_context);
        }

        [Then(@"I click on first search result")]
        public void ClickOnFirstSearchResult()
        {
            yourResultsPage.VerifyResultsPageHeader();
            TestContext.Progress.WriteLine("Navigating to Apprenticeship Summary page");
            yourResultsPage.ClickOnAnySerachResult();
        }

        [Then(@"I can verify the content of no matching results page")]
        public void VerifyContentInNoMatchingResultsPage()
        {
            yourResultsPage.VerifyResultsPageHeader();
            yourResultsPage.VerifyTheNoMatchResultsPageContent();
        }

    }
}