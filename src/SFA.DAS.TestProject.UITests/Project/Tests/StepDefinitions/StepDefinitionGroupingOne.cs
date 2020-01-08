using SFA.DAS.TestProject.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.TestProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionGroupingOne
    {
        #region Private Variables
        private readonly TestProjectConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        #endregion

        public StepDefinitionGroupingOne(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _configuration = context.GetTestProjectConfig<TestProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [Given(@"the User navigates to GOV.UK home page")]
        public void NavigateToGovUkHomePage()
        {
            var url = _configuration.TP_BaseUrl;
            TestContext.Progress.WriteLine("Navigating to Gov.uk home page");
            _webDriver.Url = url; 
        }

        [When(@"the User searches for (.*)")]
        public void SearchForText(string searchText)
        {
            var welcomePage = new WelcomePage(_context);
            TestContext.Progress.WriteLine($"Searching for {searchText}");
            _objectContext.Set("searchText", searchText);
            welcomePage.EnterSearchTextAndSubmit(searchText);
        }

        [Then(@"the User should be on DFE home page")]
        public void ShouldBeOnDfeHomePage()
        {
            TestContext.Progress.WriteLine($"Verifying Page title");
            new HomePage(_context);
        }
    }
}