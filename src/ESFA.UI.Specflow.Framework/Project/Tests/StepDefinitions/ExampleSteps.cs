using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps
    {
        private readonly ConfigurationOptions _configuration;
        private readonly IWebDriver _webDriver;

        public ExampleSteps(IWebDriver webDriver, ConfigurationOptions configuration)
        {
            _configuration = configuration;
            _webDriver = webDriver;
        }

        [Given(@"I navigate to GOV.UK home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.BaseUrl;
            _webDriver.Url = url; 
        }

        [When(@"I search for (.*)")]
        public void SearchForText(string searchText)
        {
            var welcomeToGovUkPage = new WelcomeToGovUkPage(_webDriver);
            welcomeToGovUkPage.EnterSearchTextAndSubmit(searchText);
        }

        [When(@"I click on DFE link")]
        public void ClickOnDfeLink()
        {
            var searchResultsPage = new SearchResultsPage(_webDriver);
            searchResultsPage.ClickDfeLink();
        }

        [Then(@"I should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            var departmentForEducationHomePage = new DepartmentForEducationHomePage(_webDriver);
            departmentForEducationHomePage.IsPageHeadingMacthing();
        }
    }
}