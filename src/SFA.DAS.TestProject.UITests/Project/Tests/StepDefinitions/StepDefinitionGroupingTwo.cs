using SFA.DAS.TestProject.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TestContext = NUnit.Framework.TestContext;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionGroupingTwo
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        public StepDefinitionGroupingTwo(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [When(@"clicks the same link")]
        public void ClicksTheSameLink()
        {
            var searchResultsPage = new SearchResultsPage(_context);
            var searchText = _objectContext.Get("searchText");
            TestContext.Progress.WriteLine($"Navigating to {searchText} page");
            searchResultsPage.OpenDesiredPage(searchText);
        }
    }
}
