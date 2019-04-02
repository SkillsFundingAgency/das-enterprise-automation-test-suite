using ESFA.UI.Specflow.Framework.Project.Tests.Pages;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps : BaseTest
    {
        private readonly ConfigurationOptions _configuration;

        public ExampleSteps(ConfigurationOptions options)
        {
            _configuration = options;
        }

        [Given(@"I navigate to GOV.UK home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.BaseUrl;
            WebDriver.Url = url; 
        }

        [When(@"I search for (.*)")]
        public void SearchForText(string searchText)
        {
            var welcomeToGovUkPage = new WelcomeToGovUkPage(WebDriver);
            welcomeToGovUkPage.EnterSearchTextAndSubmit(searchText);
        }

        [When(@"I click on DFE link")]
        public void ClickOnDfeLink()
        {
            var searchResultsPage = new SearchResultsPage(WebDriver);
            searchResultsPage.ClickDfeLink();
        }

        [Then(@"I should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            var departmentForEducationHomePage = new DepartmentForEducationHomePage(WebDriver);
            departmentForEducationHomePage.IsPageHeadingMacthing();
        }
    }
}