using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps 
    {
        private readonly ConfigurationOptions _configuration;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;

        public ExampleSteps(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<ConfigurationOptions>();
        }

        [Given(@"I navigate to GOV.UK home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.BaseUrl;
            NUnit.Framework.TestContext.Progress.WriteLine("Naivgating to Gov.uk home page");
            _webDriver.Url = url; 
        }

        [When(@"I search for (.*)")]
        public void SearchForText(string searchText)
        {
            var welcomeToGovUkPage = new WelcomeToGovUkPage(_context);
            NUnit.Framework.TestContext.Progress.WriteLine($"Searching for {searchText}");
            welcomeToGovUkPage.EnterSearchTextAndSubmit(searchText);
        }

        [When(@"I click on (.*) link")]
        public void ClickOnDfeLink(string searchText)
        {
            var searchResultsPage = new SearchResultsPage(_context);
            NUnit.Framework.TestContext.Progress.WriteLine($"Naivgating to {searchText} page");
            searchResultsPage.ClickDfeLink(searchText);
        }

        [Then(@"I should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            var departmentForEducationHomePage = new DepartmentForEducationHomePage(_context);
            NUnit.Framework.TestContext.Progress.WriteLine($"Verifying Page title");
            departmentForEducationHomePage.IsPageHeadingMacthing();
        }
    }
}