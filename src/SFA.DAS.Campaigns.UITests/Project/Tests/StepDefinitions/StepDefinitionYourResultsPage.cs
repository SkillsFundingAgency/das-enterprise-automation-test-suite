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
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private FireItUpHomePage fireItUpHomePage;
        private FindAnApprenticeShipPage findAnApprenticeShipPage;
        private YourResultsPage yourResultsPage;
        private ApprenticeshipSummaryPage apprenticeshipSummaryPage;
        #endregion

        public StepDefinitionYourResultsPage(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"I click on first search result")]
        public void clickOnFirstSearchResult()
        {
            yourResultsPage = new YourResultsPage(_context);
            yourResultsPage.clickOnFirstSearchResult();
        }
    }
}