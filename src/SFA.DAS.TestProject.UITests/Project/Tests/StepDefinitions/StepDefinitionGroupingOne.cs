using SFA.DAS.TestProject.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.TestProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionGroupingOne
    {
        #region Private Variables
        private readonly ProjectSpecificConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        #endregion

        public StepDefinitionGroupingOne(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _configuration = context.GetConfigSection<ProjectSpecificConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"I navigate to GOV.UK home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.TP_BaseUrl;
            TestContext.Progress.WriteLine("Navigating to Gov.uk home page");
            _webDriver.Url = url; 
        }

        [When(@"I search for (.*)")]
        public void SearchForText(string searchText)
        {
            var welcomePage = new WelcomePage(_context);
            TestContext.Progress.WriteLine($"Searching for {searchText}");
            _objectContext.Set("searchText", searchText);
            welcomePage.EnterSearchTextAndSubmit(searchText);
        }

        [When(@"I click on (.*) link")]
        public void ClickOnDfeLink(string searchText)
        {
            var searchResultsPage = new SearchResultsPage(_context);
            TestContext.Progress.WriteLine($"Navigating to {searchText} page");
            searchResultsPage.OpenDesiredPage(searchText);
        }

        [Then(@"I should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            TestContext.Progress.WriteLine($"Verifying Page title");
            new HomePage(_context);
        }
    }
}