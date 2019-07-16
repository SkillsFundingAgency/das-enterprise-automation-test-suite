using SFA.DAS.TestProject.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TestContext = NUnit.Framework.TestContext;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExampleSteps1
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ExampleSteps1(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"I click the same link")]
        public void WhenIClickTheSameLink()
        {
            var searchResultsPage = new SearchResultsPage(_context);
            var searchText = _objectContext.Get("searchText");
            TestContext.Progress.WriteLine($"Naivgating to {searchText} page");
            searchResultsPage.ClickDfeLink(searchText);
        }
    }
}
